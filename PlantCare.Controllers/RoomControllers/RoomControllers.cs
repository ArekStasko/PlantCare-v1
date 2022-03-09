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
    }
}
