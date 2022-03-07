using NUnit.Framework;
using FluentAssertions;
using PlantCare.DataAccess.models;
using System;
using System.Linq;

namespace PlantCare.DataAccess.Tests
{
    public class RoomTests
    {

        [SetUp]
        public void Setup()
        {
            var plantServices = DataAccessFactory.GetPlantServicesInstance();
            var roomServices = DataAccessFactory.GetRoomServicesInstance();


            var plants = plantServices.GetPlants();
            foreach (var plant in plants)
            {
                plantServices.DeletePlant(plant.Id);
            }

            var rooms = roomServices.GetRooms();
            if(rooms.Count > 0)
            {
                foreach (var room in rooms)
                {
                    roomServices.DeleteRoom(room.Id);
                }
            }
        }

        [Test]
        public void DeleteRoom_ShouldDelete_OneRoom()
        {
            var roomToInsert = new Room()
            {
                RoomName = "Test Room",
                RoomLocation = "First floor",
                PlantsCount = 12,
                RoomInsolation = 56,
                LastVisit = new DateTime(2022, 02, 22, 22, 22, 22),
                ImageSource = "https://images.unsplash.com/photo-1505691938895-1758d7feb511?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80"
            };

            var roomServices = DataAccessFactory.GetRoomServicesInstance();
            roomServices.InsertRoom(roomToInsert);

            var roomToDelete = roomServices.GetRooms().Single(room => room.RoomName == roomToInsert.RoomName); 
            roomServices.DeleteRoom(roomToDelete.Id);
            
            var rooms = roomServices.GetRooms();
            rooms.Should().NotContain(room => room.RoomName == roomToDelete.RoomName);
        }

        [Test]
        public void InsertRoom_ShouldInsert_OneRoom()
        {
            var roomToInsert = new Room()
            {
                RoomName = "Test Room",
                RoomLocation = "First floor",
                PlantsCount = 12,
                RoomInsolation = 56,
                LastVisit = new DateTime(2022, 02, 22, 22, 22, 22),
                ImageSource = "https://images.unsplash.com/photo-1505691938895-1758d7feb511?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80"
            };

            var roomServices = DataAccessFactory.GetRoomServicesInstance();
            roomServices.InsertRoom(roomToInsert);

            var rooms = roomServices.GetRooms();
            rooms.Should().NotBeEmpty();
        }

        [Test]
        public void UpdateRoom_ShouldUpdate_OneRoom()
        {
            var roomToInsert = new Room()
            {
                RoomName = "Test Room",
                RoomLocation = "First floor",
                PlantsCount = 12,
                RoomInsolation = 56,
                LastVisit = new DateTime(2022, 02, 22, 22, 22, 22),
                ImageSource = "https://images.unsplash.com/photo-1505691938895-1758d7feb511?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80"
            };

            var roomServices = DataAccessFactory.GetRoomServicesInstance();
            roomServices.InsertRoom(roomToInsert);

            var roomToUpdate = roomServices.GetRooms().Single(room => room.RoomName == roomToInsert.RoomName);
            roomToUpdate.RoomName = "Updated Room";
            roomToUpdate.RoomLocation = "Updated Location";
            roomToUpdate.PlantsCount = 3;
            roomToUpdate.RoomInsolation = 10;
            roomToUpdate.LastVisit = new DateTime(2022, 03, 23, 23, 23, 23);

            roomServices.UpdateRoom(roomToUpdate);
            var updatedRoom = roomServices.GetRoom(roomToUpdate.Id);
            updatedRoom.RoomName.Should().Be("Updated Room");
        }

        [Test]
        public void GetRoom_ShouldReturn_OneRoom()
        {
            var roomToInsert = new Room()
            {
                RoomName = "Test Room",
                RoomLocation = "First floor",
                PlantsCount = 12,
                RoomInsolation = 56,
                LastVisit = new DateTime(2022, 02, 22, 22, 22, 22),
                ImageSource = "https://images.unsplash.com/photo-1505691938895-1758d7feb511?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80"
            };

            var roomServices = DataAccessFactory.GetRoomServicesInstance();
            roomServices.InsertRoom(roomToInsert);

            var insertedRoom = roomServices.GetRooms().Single(room => room.RoomName == roomToInsert.RoomName);

            var room = roomServices.GetRoom(insertedRoom.Id);
            room.RoomName.Should().Be("Test Room");
        }
    }
}