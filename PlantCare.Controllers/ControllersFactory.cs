

namespace PlantCare.Controllers
{
    public static class ControllersFactory
    {
        public static IPlantControllers GetPlantControlers(this IView view)
        {
            return new PlantControllers(view);
        }

        public static IRoomControllers GetRoomControllers(this IView view)
        {
            return new RoomControllers(view);
        }
    }
}