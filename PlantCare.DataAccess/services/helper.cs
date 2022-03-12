
namespace PlantCare.DataAccess.services
{
    public static class Helper
    {
        public static string GetConnString()
        {
            string dataSource = @"DESKTOP-3JOII9M";
            string db = "PlantCare";

            string connString = $"Data Source ={dataSource};Initial Catalog={db};Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"; 
            return connString;

        }
    }
}
