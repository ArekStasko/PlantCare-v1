using PlantCare.DataAccess.models;

namespace PlantCare.DataAccess.services
{
    public interface IRoomServices
    {
        public List<Room> GetRooms();
        public void InsertRoom(Room room);
        public void DeleteRoom(Room room);
    }
}
