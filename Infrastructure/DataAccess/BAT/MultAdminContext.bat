Scaffold-DbContext "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MultAdmin;Integrated Security=True;" Microsoft.EntityFrameworkCore.SqlServer -contextDir Infrastructure\DataAccess\MultAdminContext  -OutputDir Domain\Entities\MultAdmin  -UseDatabaseNames -NoPluralize -Tables Users, Organizations  -f -Context MultAdminContext


