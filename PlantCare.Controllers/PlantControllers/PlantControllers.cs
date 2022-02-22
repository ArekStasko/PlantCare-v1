using PlantCare.DataAccess.services;
using PlantCare.DataAccess;

namespace PlantCare.Controllers
{
    public class PlantControllers : IPlantControllers
    {
        public void TestServiceConnection()
        {
            IPlantServices plantServices = DataAccessFactory.GetPlantServicesInstance();
            plantServices.TestConnection();
        }
    }
}
