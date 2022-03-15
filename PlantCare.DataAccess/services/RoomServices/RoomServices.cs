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
            catch (Exception)
            {
                return;
            }
        }

        public Room GetRoom(Guid roomID)
        {
            OpenConnection();
            using(IDbConnection connection = _conn)
            {
                return connection.Query<Room>("dbo.spGetRoom", new { RoomID = roomID }, commandType: CommandType.StoredProcedure).First();
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

        public void InsertRoom(IRoom room)
        {
            OpenConnection();
            using(IDbConnection connection = _conn)
            {
                connection.Execute("dbo.spInsertRoom",
                    new
                    {
                        RoomName = room.RoomName,
                        RoomLocation = room.RoomLocation,
                        PlantsCount = room.PlantsCount,
                        RoomInsolation = room.RoomInsolation,
                        LastVisit = room.LastVisit,
                        ImageSource = room.ImageSource
                    },
                    commandType: CommandType.StoredProcedure
                    );
            }
        }

        public void DeleteRoom(Guid Id)
        {
            OpenConnection();
            using(IDbConnection connection = _conn)
            {
                connection.Query("dbo.spDeleteRoom", new { RoomID = Id }, commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdateRoom(Room room)
        {
            OpenConnection();
            using(IDbConnection connection = _conn)
            {
                connection.Execute("dbo.spUpdateRoom",
                     new
                     {
                         RoomID = room.Id,
                         RoomName = room.RoomName,
                         RoomLocation = room.RoomLocation,
                         PlantsCount = room.PlantsCount,
                         RoomInsolation = room.RoomInsolation,
                         LastVisit = room.LastVisit,
                         ImageSource = room.ImageSource
                     },
                    commandType: CommandType.StoredProcedure
                    ); 
            }
        }

    }
}