using System.Data.SqlClient;
using System.Data;
using PlantCare.DataAccess.models;
using Dapper;

namespace PlantCare.DataAccess.services
{
    public class RoomServices : IRoomServices
    {
        private SqlConnection _conn = new SqlConnection(Helper.GetConnString());
        private void OpenConnection()
        {
            try
            {
                _conn.Open();
            }
            catch (Exception)
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

        public void InsertRoom(Room room)
        {
            OpenConnection();
            var values = new
            {
                RoomName = room.Name,
                RoomLocation = room.Location,
                PlantsCount = room.PlantsCount,
                RoomInsolation = room.RoomInsolation,
                LastVisit = room.LastVisit
            };
            using(IDbConnection connection = _conn)
            {

                connection.Query("dbo.spInsertRoom", values);
            }
        }

        public void DeleteRoom(Room room)
        {
            OpenConnection();
            var values = new { RoomID = room.Id };
            using(IDbConnection connection = _conn)
            {
                connection.Query("dbo.spDeleteRoom", values);
            }
        }

    }
}