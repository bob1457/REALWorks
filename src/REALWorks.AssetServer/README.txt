1. Generate class from existing database:

Scaffold-DbContext "Server=.\SQLEXPRESS;Database=REALAsset;UID=real;PWD=1234567;" Microsoft.EntityFrameworkCore.SqlServer -f -Project REALWorks.AssetServer -OutputDir Models

2. Ref: https://www.codeproject.com/Articles/1259484/CRUD-Operation-in-ASP-NET-Core-Web-API-with-Entity

When testing file upload with Postman, KEY filed of file upload control must be EMPTY!!!