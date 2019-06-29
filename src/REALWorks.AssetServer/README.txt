1. Generate class from existing database:

(PM Console, choose the project)   Scaffold-DbContext "Server=.\SQLEXPRESS;Database=REALAsset;UID=real;PWD=1234567;" Microsoft.EntityFrameworkCore.SqlServer -f -Project REALWorks.AssetServer -OutputDir Models


(Powershell, change to the project directory)   dotnet ef dbcontext scaffold "Server=.\;Database=AdventureWorksLT2012;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -o Model

code first: dotnet ef migrations add <xxxxx>

2. Ref: https://www.codeproject.com/Articles/1259484/CRUD-Operation-in-ASP-NET-Core-Web-API-with-Entity

When testing file upload with Postman, KEY field of file upload control must be EMPTY!!! Also, make sure the in the controller, input data must [FromForm]!!!