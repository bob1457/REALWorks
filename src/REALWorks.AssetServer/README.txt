1. Generate class from existing database:

Scaffold-DbContext "Server=.\SQLEXPRESS;Database=Blogs;UID=real;PWD=1234567;" Microsoft.EntityFrameworkCore.SqlServer -Project REALWorks.AssetServer -OutputDir Models

2. Ref: https://www.codeproject.com/Articles/1259484/CRUD-Operation-in-ASP-NET-Core-Web-API-with-Entity