
namespace PlantCare.DataAccess.models
{
    public class Room : IRoom
    {
        public string Name { get; set; } = "No Name";
        public string Location { get; set; } = "No Location";
        public int PlantsCount { get; set; }
        public int RoomInsolation { get; set; }
        public DateTime LastVisit { get; set; }
    }
}
