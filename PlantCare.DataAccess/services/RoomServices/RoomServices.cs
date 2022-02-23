using System.Data.SqlClient;

namespace PlantCare.DataAccess.services
{
    public class RoomServices : IRoomServices
    {
        private SqlConnection _conn;
        private void OpenConnection()
        {
            string connectionString = Helper.GetConnString();
            _conn = new SqlConnection(connectionString);

            try
            {
                _conn.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Whoops we have an error : {e}");
            }
        }

        public void GetRooms()
        {

        }

    }
}
