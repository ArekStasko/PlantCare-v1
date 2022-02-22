using System.Data.SqlClient;

namespace PlantCare.DataAccess.services
{
    public class RoomServices : IRoomServices
    {
        private void OpenConnection()
        {
            string connectionString = Helper.GetConnString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                Console.WriteLine("Opening Connection...");
                conn.Open();
                Console.WriteLine("Connection open");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Whoops we have an error : {e}");
            }
        }

    }
}
