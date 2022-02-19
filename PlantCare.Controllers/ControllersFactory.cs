

namespace PlantCare.Controllers
{
    public static class ControllersFactory
    {
        public static IPlantControllers GetPlantControlers()
        {
            return new PlantControllers();
        }

        public static IRoomControllers GetRoomControllers()
        {
            return new RoomControllers();
        }
    }
}