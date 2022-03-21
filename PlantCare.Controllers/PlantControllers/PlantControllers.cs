using PlantCare.DataAccess.models;
using PlantCare.DataAccess.services;
using PlantCare.DataAccess;

namespace PlantCare.Controllers
{
    public class PlantControllers : IPlantControllers
    {
        private IView _view;
        private IPlantServices _plantServices;

        public PlantControllers(IView view)
        {
            _view = view;
            _plantServices = DataAccessFactory.GetPlantServicesInstance();
        }

        public List<Plant> GetPlants() => _plantServices.GetPlants();
        public List<Plant> GetRoomPlants(Guid Id)
        {
            var plants = _plantServices.GetPlants();
            return plants.Where(plant => plant.RoomID == Id).ToList();
        }
        public Plant GetPlant(Guid Id) => _plantServices.GetPlant(Id);
    }
}
