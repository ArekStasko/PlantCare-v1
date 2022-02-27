

namespace PlantCare.DataAccess.models
{
    public interface IRoom
    {
        public Guid Id { get; set; }
        public string RoomName { get; set; }
        public string RoomLocation { get; set; }
        public int PlantsCount { get; set; }
        public int RoomInsolation { get; set; }
        public DateTime LastVisit { get; set; }
    }
}
