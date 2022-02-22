using PlantCare.DataAccess.models;
using PlantCare.DataAccess.services;

namespace PlantCare.DataAccess
{
    public static class DataAccessFactory
    {
        public static IPlant GetPlantInstance()
        {
            return new Plant();
        }

        public static IRoom GetRoomInstance()
        {
            return new Room();
        }

        public static IPlantServices GetPlantServicesInstance()
        {
            return new PlantServices();
        }

        public static IRoomServices GetRoomServicesInstance()
        {
            return new RoomServices();
        }
    }
}