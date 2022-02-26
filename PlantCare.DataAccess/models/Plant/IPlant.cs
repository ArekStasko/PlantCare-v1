
namespace PlantCare.DataAccess.models
{
    public interface IPlant
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string HydrationNeeded { get; set; }
        public int HowManyDaysToHydration { get; set; }
        public bool IsSunNeeded { get; set; }
        public DateTime LastHydration { get; set; }
    }
}
