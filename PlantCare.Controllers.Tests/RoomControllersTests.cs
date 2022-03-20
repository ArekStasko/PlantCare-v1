using NUnit.Framework;
using FluentAssertions;
using PlantCare.Controllers;
using PlantCare.DataAccess.models;
using PlantCare.DataAccess.services;
using PlantCare.DataAccess;
using System.Collections.Generic;
using System.Linq;

namespace PlantCare.Controllers.Tests
{
    public class Tests
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
            if (rooms.Count > 0)
            {
                foreach (var room in rooms)
                {
                    roomServices.DeleteRoom(room.Id);
                }
            }
        }

        [Test]
        public void CreateRoom_ShouldCreate_OneRoom()
        {
            var roomData = new List<string>()
            {
                "Test room name",
                "Test room location",
                "13",
                "77",
                "https://images.unsplash.com/photo-1505691938895-1758d7feb511?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80",
                "03",
                "03",
                "2022"
            };
            var roomControllers = ControllersFactory.GetRoomControllers(new MockView());
            roomControllers.CreateRoom(roomData);
            var rooms = roomControllers.GetRooms();
            rooms.Should().Contain(room => room.RoomName == roomData[0]);
        }

        [Test]
        public void UpdateRoom_ShouldEdit_OneRoom()
        {
            var roomData = new List<string>()
            {
                "Test room name",
                "Test room location",
                "13",
                "77",
                "https://images.unsplash.com/photo-1505691938895-1758d7feb511?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80",
                "03",
                "03",
                "2022"
            };
            var roomControllers = ControllersFactory.GetRoomControllers(new MockView());
            roomControllers.CreateRoom(roomData);
            var room = roomControllers.GetRooms().Single(room => room.RoomName == roomData[0]);

            var updateData = new List<string>()
            {
                "Updated room name",
                "Updated room location",
                "14",
                "80",
                "https://images.unsplash.com/photo-1505691938895-1758d7feb511?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80",
                "10",
                "03",
                "2022"
            };

            roomControllers.UpdateRoom(updateData, room.Id);
            var roomToAssert = roomControllers.GetRoom(room.Id);
            roomToAssert.RoomName.Should().Be(updateData[0]);
        }

        [Test]
        public void DeleteRoom_ShouldDelete_OneRoom()
        {
            var roomData = new List<string>()
            {
                "Test room name",
                "Test room location",
                "13",
                "77",
                "https://images.unsplash.com/photo-1505691938895-1758d7feb511?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80",
                "03",
                "03",
                "2022"
            };
            var roomControllers = ControllersFactory.GetRoomControllers(new MockView());
            roomControllers.CreateRoom(roomData);
            var room = roomControllers.GetRooms().Single(room => room.RoomName == roomData[0]);
            roomControllers.DeleteRoom(room.Id);
            roomControllers.GetRooms().Should().NotContain(item => item.Id == room.Id);
        }
    }
}