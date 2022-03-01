
namespace PlantCare.DataAccess.models
{
    public class Plant : IPlant
    {
        public Guid Id { get; set; }
        public Guid RoomID { get; set; }
        public string PlantName { get; set; } = "No Name";
        public string PlantDescription { get; set; } = "No Description";
        public string HydrationNeeded { get; set; } = "No info";
        public int HowManyDaysToHydration { get; set; }
        public bool IsSunNeeded { get; set; }
        public DateTime LastHydration { get; set; }
    }
}
