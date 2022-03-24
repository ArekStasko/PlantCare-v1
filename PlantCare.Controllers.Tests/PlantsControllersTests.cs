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
    public class PlantTests
    {
        [SetUp]
        public void Setup()
        {

            var plantServices = DataAccessFactory.GetPlantServicesInstance();

            var plants = plantServices.GetPlants();
            foreach (var plant in plants)
            {
                plantServices.DeletePlant(plant.Id);
            }

            var roomServices = DataAccessFactory.GetRoomServicesInstance();

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
        public void CreatePlant_ShouldCreate_OnePlant()
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

            var plantData = new List<string>()
            {
                "TestName",
                "TestDescription",
                "Needed hydration",
                true.ToString(),
                "https://images.unsplash.com/photo-1505691938895-1758d7feb511?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80",
                "03",
                "03",
                "2022",
            };
            var plantControllers = ControllersFactory.GetPlantControlers(new MockView());
            plantControllers.CreatePlant(plantData, room.Id);
            var plants = plantControllers.GetPlants();
            plants.Should().Contain(plant => plant.PlantName == plantData[0]);
        }

        [Test]
        public void UpdatePlant_ShouldUpdate_OnePlant()
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

            var plantData = new List<string>()
            {
                "TestName",
                "TestDescription",
                "Needed hydration",
                true.ToString(),
                "https://images.unsplash.com/photo-1505691938895-1758d7feb511?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80",
                "03",
                "03",
                "2022",
            };
            var plantControllers = ControllersFactory.GetPlantControlers(new MockView());
            plantControllers.CreatePlant(plantData, room.Id);
            var plant = plantControllers.GetPlants().Single(plant => plant.PlantName == plantData[0]);
            var updateData = new List<string>()
            {
                "UpdateName",
                "UpdateDescription",
                "UpdateNeeded hydration",
                true.ToString(),
                "https://images.unsplash.com/photo-1505691938895-1758d7feb511?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80",
                "03",
                "03",
                "2022",
            };
            plantControllers.UpdatePlant(updateData, plant.Id);
            plantControllers.GetPlant(plant.Id).PlantName.Should().Be("UpdateName");
        }

        [Test]
        public void DeletePlant_ShouldDelete_OnePlant()
        {
            var roomData = new List<string>()
            {
                "Test room name",
                "Test room location",
                "0",
                "77",
                "https://images.unsplash.com/photo-1505691938895-1758d7feb511?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80",
                "03",
                "03",
                "2022"
            };
            var roomControllers = ControllersFactory.GetRoomControllers(new MockView());
            roomControllers.CreateRoom(roomData);
            var room = roomControllers.GetRooms().Single(room => room.RoomName == roomData[0]);

            var plantData = new List<string>()
            {
                "TestName",
                "TestDescription",
                "Needed hydration",
                true.ToString(),
                "https://images.unsplash.com/photo-1505691938895-1758d7feb511?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80",
                "03",
                "03",
                "2022",
            };
            var plantControllers = ControllersFactory.GetPlantControlers(new MockView());
            plantControllers.CreatePlant(plantData, room.Id);
            var plant = plantControllers.GetPlants().Single(plant => plant.PlantName == plantData[0]);
            plantControllers.DeletePlant(plant.Id, room.Id);
            room = roomControllers.GetRooms().Single(room => room.RoomName == roomData[0]);
            plantControllers.GetPlants().Should().NotContain(pnt => pnt.Id == plant.Id);
            room.PlantsCount.Should().Be(0);
        }
    }
}