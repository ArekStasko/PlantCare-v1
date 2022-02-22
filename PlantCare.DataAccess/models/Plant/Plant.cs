
namespace PlantCare.DataAccess.models
{
    public class Plant : IPlant
    {
        public string Name { get; set; } = "No Name";
        public string Description { get; set; } = "No Description";
        public string HydrationNeeded { get; set; } = "No info";
        public int HowManyDaysToHydration { get; set; }
        public bool IsSunNeeded { get; set; }
        public DateTime LastHydration { get; set; }
    }
}
