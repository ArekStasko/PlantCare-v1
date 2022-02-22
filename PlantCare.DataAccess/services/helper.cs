using System;
using System.Data.SqlClient;


namespace PlantCare.DataAccess.services
{
    public static class Helper
    {
        public static void ConnectToDB()
        {
            string dataSource = @"DESKTOP-7M8BP42";
            string db = "PlantCare";

            string connString = @"Data Source =" + dataSource + ";Initial Catalog ="
                + db + ";Persist Security Info=True";

            SqlConnection conn = new SqlConnection(connString);

            try
            {
                Console.WriteLine("Opening Connection...");
                conn.Open();
                Console.WriteLine("Connection open");
            }
            catch(Exception e)
            {
                Console.WriteLine($"Whoops we have an error : {e}");
            }
        }
    }
}
