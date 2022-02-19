using PlantCare.Plants;
using PlantCare.Rooms;

namespace PlantCare
{
    public static class ViewFactory
    {
        public static IPlantsView GetPlantsViewInstance()
        {
            return new PlantsView();
        }

        public static IRoomsView GetRoomsViewInstance()
        {
            return new RoomsView();
        }
    }
}
