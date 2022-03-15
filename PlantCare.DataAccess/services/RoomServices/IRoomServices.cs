using PlantCare.DataAccess.models;

namespace PlantCare.DataAccess.services
{
    public interface IRoomServices
    {
        public List<Room> GetRooms();
        public Room GetRoom(Guid roomID);
        public void InsertRoom(IRoom room);
        public void DeleteRoom(Guid Id);
        public void UpdateRoom(Room room);
    }
}
