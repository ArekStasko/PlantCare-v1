using PlantCare.DataAccess.models;

namespace PlantCare.Controllers
{
    public interface IRoomControllers
    {
        public List<Room> GetRooms();
        public void DeleteRoom(Guid Id);
        public void CreateRoom(List<string> roomData);
    }
}
