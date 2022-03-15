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
            var roomToAdd = DataAccessFactory.GetRoomInstance();
            SetDate(roomToAdd, roomData[5], roomData[6], roomData[7]);
            CheckRoomInsolation(roomToAdd, roomData[3]);
        }

        private void SetDate(IRoom room, string day, string month, string year)
        {
            try
            {
                var todayDate = DateTime.Now;
                var date = new DateTime(Int32.Parse(year), Int32.Parse(month), Int32.Parse(day));
                if (date > todayDate) throw new Exception();
                room.LastVisit = date;
            }
            catch (Exception)
            {
                _view.DisplayErrorMessage("You provided wrong date");
                return;
            }
        }

        private void CheckRoomInsolation(IRoom room, string insolation)
        {
            try
            {
                int ins = Int32.Parse(insolation);
                if(ins > 100 || ins < 0) throw new Exception();
                room.RoomInsolation = ins;
            }
            catch (Exception)
            {
                _view.DisplayErrorMessage("You provided wrong insolation, it has to be between 0 and 100");
                return;
            }
        }
    }
}
