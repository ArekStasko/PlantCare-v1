using System.Data.SqlClient;
using System.Data;
using PlantCare.DataAccess.models;
using Dapper;

namespace PlantCare.DataAccess.services
{
    public class RoomServices : IRoomServices
    {
        private SqlConnection? _conn;
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
                return;
            }
        }

        public List<Room> GetRooms()
        {
            OpenConnection();
            using (IDbConnection connection = _conn)
            {
                return connection.Query<Room>("dbo.spGetRooms").ToList();
            }
        }

    }
}
