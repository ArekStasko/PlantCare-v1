using PlantCare.DataAccess.models;

namespace PlantCare.Controllers
{
    public interface IRoomControllers
    {
        public List<Room> GetRooms();
        public Room GetRoom(Guid Id);
        public void DeleteRoom(Guid Id);
        public void CreateRoom(List<string> roomData);
        public void UpdateRoom(List<string> roomData, Guid Id);
    }
}
