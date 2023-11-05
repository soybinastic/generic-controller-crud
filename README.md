# generic-controller-crud
A generic controller CRUD with AutoMapper


Found limitations:
 - You can't customize route ex. You have ProductController, then the default route of that is "api/product". You cannot change it to "api/products" or what ever you want route names.
 - When you have many to many and one to many entity relationships, you cannot join or include their property navigation. 
