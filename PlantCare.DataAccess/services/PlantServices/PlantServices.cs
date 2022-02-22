
namespace PlantCare.DataAccess.services
{
    public class PlantServices : IPlantServices
    {
        private void OpenConnection()
        {
            Helper.ConnectToDB();
        }

        public void TestConnection()
        {
            OpenConnection();
        }
    }
}
