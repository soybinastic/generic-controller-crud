
using AutoMapper;
using Inventory.API.Data;
using Inventory.API.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventory.API.Common;


[Route("api/[controller]")]
public class ModelBaseController<TModel, TEntityCreate, TEntityUpdate> : Controller where TModel : class
{   
    private readonly InventoryContext _db;
    private readonly IMapper _mapper;
    protected ModelBaseController(
        InventoryContext db,
        IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    [HttpPost]
    public virtual async Task<IActionResult> PerformCreate([FromBody]TEntityCreate data)
    {
        // var newEntity = await _db.Set<TModel>().AddAsync()
        if(!ModelState.IsValid)
        {
            return BadRequest(ApiResponse<TModel>.BadRequest("Invalid input", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList()));
        }

        var entity = _mapper.Map<TModel>(data);
        var newEntity = await _db.Set<TModel>().AddAsync(entity);
        await _db.SaveChangesAsync();
        return Ok(new ApiResponse<TModel> { Data = newEntity.Entity });
    }

    [HttpPut("{id}")]
    public virtual async Task<IActionResult> PerformUpdate([FromRoute]int id, [FromBody]TEntityUpdate data)
    {
        // TODO: fix update functionality, cause it's not yet functional.
        if(!ModelState.IsValid)
        {
            return BadRequest(ApiResponse<TModel>.BadRequest("Invalid input", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList()));
        }

        var updatedEntity = _mapper.Map<TModel>(data);
        var propInfo = updatedEntity.GetType().GetProperty("Id");

        if(propInfo is null)
        {
            return BadRequest(ApiResponse<TModel>.BadRequest("Id field not provided", new List<string>()));
        }

        propInfo.SetValue(updatedEntity, id, null);
        var queryEntity = await _db.Set<TModel>().FindAsync(id);

        if(queryEntity is null)
        {
            return NotFound(ApiResponse<TModel>.BadRequest("Not found", new List<string>()));
        }
        // var obj = updatedEntity as Product;
        _db.Set<TModel>().Entry(queryEntity).CurrentValues.SetValues(updatedEntity);
        await _db.SaveChangesAsync();
        return Ok(new ApiResponse<TModel> { Data = queryEntity });
    }

    [HttpDelete("{id}")]
    public virtual async Task<IActionResult> PerformDelete([FromRoute]int id)
    {
        var entity = await _db.Set<TModel>().FindAsync(id);

        if(entity is null)
        {
            return BadRequest(ApiResponse<TModel>.BadRequest("Not found", new List<string>()));
        }

        _db.Set<TModel>().Remove(entity);
        await _db.SaveChangesAsync();
        return Ok(new ApiResponse<TModel> { Message = "Succesfully deleted" });
    }

    [HttpGet]
    public virtual async Task<IActionResult> FindAll()
    {
        var data = await _db.Set<TModel>().ToListAsync();
        return Ok(new ApiResponse<IEnumerable<TModel>> { Data = data });
    }

    [HttpGet("{id}")]
    public virtual async Task<IActionResult> Find([FromRoute]int id)
    {
        var entity = await _db.Set<TModel>().FindAsync(id);
        return Ok(new ApiResponse<TModel> { Data = entity });
    }
}