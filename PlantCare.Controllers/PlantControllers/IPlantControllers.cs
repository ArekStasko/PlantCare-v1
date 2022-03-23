using PlantCare.DataAccess.models;

namespace PlantCare.Controllers
{
    public interface IPlantControllers
    {
        public List<Plant> GetPlants();
        public List<Plant> GetRoomPlants(Guid Id);
        public Plant GetPlant(Guid Id);
        public void CreatePlant(List<string> plantData, Guid roomID);
    }
}
