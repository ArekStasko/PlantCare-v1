
namespace PlantCare.DataAccess.models
{
    public class Room : IRoom
    {
        public Guid Id { get; set; }
        public string RoomName { get; set; } = "No Name";
        public string RoomLocation { get; set; } = "No Location";
        public int PlantsCount { get; set; }
        public int RoomInsolation { get; set; }
        public DateTime LastVisit { get; set; }
    }
}
