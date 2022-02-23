using System.Data.SqlClient;

namespace PlantCare.DataAccess.services
{
    public class PlantServices : IPlantServices
    {
        private SqlConnection _conn;
        private void OpenConnection()
        {
            string connectionString = Helper.GetConnString();
            _conn = new SqlConnection(connectionString);

            try
            {
                Console.WriteLine("Opening Connection...");
                _conn.Open();
                Console.WriteLine("Connection open");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Whoops we have an error : {e}");
            }
        }

        public void TestConnection()
        {
            OpenConnection();
        }

        public void GetPlants()
        {

        }
    }
}
