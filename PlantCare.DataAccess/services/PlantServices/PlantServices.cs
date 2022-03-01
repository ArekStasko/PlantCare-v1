﻿using System.Data.SqlClient;
using System.Data;
using PlantCare.DataAccess.models;
using Dapper;

namespace PlantCare.DataAccess.services
{
    public class PlantServices : IPlantServices
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

        public List<Plant> GetPlants()
        {
            OpenConnection();
            using (IDbConnection connection = _conn)
            {
                return connection.Query<Plant>("dbo.spGetPlants").ToList();
            }
        }

        public Plant GetPlant(Guid Id)
        {
            OpenConnection();
            using(IDbConnection connection = _conn)
            {
                return connection.Query<Plant>("dbo.spGetPlant").First();
            }
        }

        public void InsertPlant(Plant plant)
        {
            OpenConnection();
            using(IDbConnection connection = _conn)
            {
                connection.Execute("dbo.spInsertPlant", new
                {
                    RoomID = plant.RoomID,
                    PlantName = plant.PlantName,
                    PlantDescription = plant.PlantDescription,
                    HydrationNeeded = plant.HydrationNeeded,
                    HowManyDaysToHydration = plant.HowManyDaysToHydration,
                    IsSunNeeded = plant.IsSunNeeded,
                    LastHydration = plant.LastHydration,
                }, 
                commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdatePlant(Plant plant)
        {
            OpenConnection();
            using(IDbConnection connection = _conn)
            {
                connection.Execute("dbo.UpdatePlant", new
                {
                    PlantID = plant.Id,
                    RoomID = plant.RoomID,
                    PlantName = plant.PlantName,
                    PlantDescription = plant.PlantDescription,
                    HydrationNeeded = plant.HydrationNeeded,
                    HowManyDaysToHydration = plant.HowManyDaysToHydration,
                    IsSunNeeded = plant.IsSunNeeded,
                    LastHydration = plant.LastHydration,
                },
                commandType: CommandType.StoredProcedure);
            }
        }

        public void DeletePlant(Guid Id)
        {
            OpenConnection();
            using(IDbConnection connection = _conn)
            {
                connection.Execute("dbo.DeletePlant", new
                {
                    PlantID = Id,
                }, 
                commandType: CommandType.StoredProcedure);
            }
        }

    }
}
