
namespace PlantCare.DataAccess.models
{
    public interface IPlant
    {
        public Guid Id { get; set; }
        public Guid RoomID { get; set; }
        public string PlantName { get; set; }
        public string PlantDescription { get; set; }
        public string HydrationNeeded { get; set; }
        public int HowManyDaysToHydration { get; set; }
        public bool IsSunNeeded { get; set; }
        public DateTime LastHydration { get; set; }
        public string ImageSource { get; set; }

        public string[] ConvertToDataRow();
    }
}
