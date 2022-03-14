using PlantCare.DataAccess.models;
using PlantCare.DataAccess.services;
using PlantCare.DataAccess;

namespace PlantCare.Controllers
{
    public class RoomControllers : IRoomControllers
    {
        private IView _view;
        private IRoomServices roomServices;

        public RoomControllers(IView view)
        {
            _view = view;
            roomServices = DataAccessFactory.GetRoomServicesInstance();
        }

        public List<Room> GetRooms() => roomServices.GetRooms();
        public void DeleteRoom(Guid Id) => roomServices.DeleteRoom(Id);
        public void CreateRoom(List<string> roomData)
        {
            if (!Int32.TryParse(roomData[2], out int n) || !Int32.TryParse(roomData[3], out int p))
            {
                _view.DisplayErrorMessage("Plants count and room insolation have to be numbers");
                return;
            }
            var roomToAdd = DataAccessFactory.GetRoomInstance();
            
        }
    }
}
