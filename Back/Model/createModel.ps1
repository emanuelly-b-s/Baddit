$strconn = "Data Source=CT-C-0013M\SQLEXPRESS" + $args[0] + ";Initial Catalog=Baddit" + $args[1] + ";Integrated Security=True;TrustServerCertificate=true"

dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet tool install --global dotnet-ef
dotnet ef dbcontext scaffold $strconn Microsoft.EntityFrameworkCore.SqlServer --force -o Model

#localhost\SQLEXPRESS" / Baddit