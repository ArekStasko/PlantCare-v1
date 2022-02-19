using PlantCare.DataAccess.models;

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
    }
}