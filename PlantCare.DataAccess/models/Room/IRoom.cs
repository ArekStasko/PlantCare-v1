

namespace PlantCare.DataAccess.models
{
    public interface IRoom
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public int PlantsCount { get; set; }
        public int RoomInsolation { get; set; }
        public DateTime LastVisit { get; set; }
    }
}
