using System.Data.SqlClient;
using System.Data;
using PlantCare.DataAccess.models;
using Dapper;

namespace PlantCare.DataAccess.services
{
    public class PlantServices : IPlantServices
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

        public List<Plant> GetPlants()
        {
            OpenConnection();
            using (IDbConnection connection = _conn)
            {
                return connection.Query<Plant>("dbo.spGetPlants").ToList();
            }
        }
    }
}
