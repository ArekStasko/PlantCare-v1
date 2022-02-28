﻿using System.Data.SqlClient;
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
                return connection.Query<Room>("dbo.spGetRoom").First();
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
            using(IDbConnection connection = _conn)
            {
                connection.Execute("dbo.spInsertRoom",
                    new
                    {
                        RoomName = room.RoomName,
                        RoomLocation = room.RoomLocation,
                        PlantsCount = room.PlantsCount,
                        RoomInsolation = room.RoomInsolation,
                        LastVisit = room.LastVisit
                    },
                    commandType: CommandType.StoredProcedure
                    );
            }
        }

        public void DeleteRoom(Room room)
        {
            OpenConnection();
            using(IDbConnection connection = _conn)
            {
                connection.Query("dbo.spDeleteRoom", new { RoomID = room.Id }, commandType: CommandType.StoredProcedure);
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
                         RoomName = room.RoomName,
                         RoomLocation = room.RoomLocation,
                         PlantsCount = room.PlantsCount,
                         RoomInsolation = room.RoomInsolation,
                         LastVisit = room.LastVisit
                     },
                    commandType: CommandType.StoredProcedure
                    );
            }
        }

    }
}