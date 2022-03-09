using PlantCare.DataAccess.models;
using PlantCare.DataAccess.services;
using PlantCare.DataAccess;

namespace PlantCare.Controllers
{
    public class PlantControllers : IPlantControllers
    {
        private IView _view;
        private IPlantServices plantServices;

        public PlantControllers(IView view)
        {
            _view = view;
            plantServices = DataAccessFactory.GetPlantServicesInstance();
        }

    }
}
