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
        public void EditRoom(List<string> newData, Guid Id)
        {
            var editedRoom = roomServices.GetRoom(Id);
            SetDate(editedRoom, newData[5], newData[6], newData[7]);
            SetRoomInsolation(editedRoom, newData[3]);
            SetPlantsCount(editedRoom, newData[2]);
            editedRoom.RoomName = newData[0];
            editedRoom.RoomLocation = newData[1];
            editedRoom.ImageSource = newData[4];

            try
            {
                roomServices.UpdateRoom(editedRoom);
                _view.DisplayMessage("Successfully updated room");
            }
            catch (Exception)
            {
                _view.DisplayErrorMessage("An error has occured");
                return;
            }
        }
        public void CreateRoom(List<string> roomData)
        {
            var roomToAdd = DataAccessFactory.GetRoomInstance();
            SetDate(roomToAdd, roomData[5], roomData[6], roomData[7]);
            SetRoomInsolation(roomToAdd, roomData[3]);
            SetPlantsCount(roomToAdd, roomData[2]);
            roomToAdd.RoomName = roomData[0];
            roomToAdd.RoomLocation = roomData[1];
            roomToAdd.ImageSource = roomData[4];

            try
            {
                roomServices.InsertRoom(roomToAdd);
                _view.DisplayMessage("Successfully inserted room");
            }
            catch (Exception)
            {
                _view.DisplayErrorMessage("An error has occured");
            }
        } 

        public void AddPlantToRoom(Guid Id)
        {
            var room = roomServices.GetRoom(Id);
            room.PlantsCount++;
            roomServices.UpdateRoom(room);
        }

        public void RemovePlantFromRoom(Guid Id)
        {
            var room = roomServices.GetRoom(Id);
            room.PlantsCount--;
            roomServices.UpdateRoom(room);
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

        private void SetRoomInsolation(IRoom room, string insolation)
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

        private void SetPlantsCount(IRoom room, string plantsCount)
        {
            try
            {
                room.PlantsCount = Int32.Parse(plantsCount);
            }
            catch (Exception)
            {
                _view.DisplayErrorMessage("You provided wrong plants count, it has to be a number");
                return;
            }
        }
    }
}
