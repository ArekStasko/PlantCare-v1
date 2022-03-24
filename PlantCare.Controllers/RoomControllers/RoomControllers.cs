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
        public Room GetRoom(Guid Id) => roomServices.GetRoom(Id);

        public void DeleteRoom(Guid Id)
        {
            var plantControllers = ControllersFactory.GetPlantControlers(_view);
            var plants = plantControllers.GetRoomPlants(Id);
            foreach(var plant in plants)
            {
                plantControllers.DeletePlant(plant.Id);
            }
            roomServices.DeleteRoom(Id);
        }

        public void UpdateRoom(List<string> roomData, Guid Id)
        {
            var roomToUpdate = roomServices.GetRoom(Id);
            FillRoomData(roomToUpdate, roomData);
            try
            {
                roomServices.UpdateRoom(roomToUpdate);
                _view.DisplayMessage("Successfully Updated room");
            }
            catch (Exception)
            {
                _view.DisplayErrorMessage("An error has occured");
            }
        }

        public void CreateRoom(List<string> roomData)
        {
            var roomToAdd = DataAccessFactory.GetRoomInstance();
            FillRoomData(roomToAdd, roomData);
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

        private void FillRoomData(IRoom room, List<string> roomData)
        {
            SetDate(room, roomData[5], roomData[6], roomData[7]);
            SetRoomInsolation(room, roomData[3]);
            SetPlantsCount(room, roomData[2]);
            room.RoomName = roomData[0];
            room.RoomLocation = roomData[1];
            room.ImageSource = roomData[4];
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
