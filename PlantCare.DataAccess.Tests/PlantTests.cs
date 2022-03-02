using NUnit.Framework;
using FluentAssertions;
using PlantCare.DataAccess.models;
using System;
using System.Linq;

namespace PlantCare.DataAccess.Tests
{
    public class PlantTests
    {
        [SetUp]
        public void Setup()
        {
            var plantServices = DataAccessFactory.GetPlantServicesInstance();
            var roomServices = DataAccessFactory.GetRoomServicesInstance();

            var plants = plantServices.GetPlants();
            foreach(var plant in plants)
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
        public void UpdatePlant_ShouldUpdate_OnePlant()
        {
            var roomToInsert = new Room()
            {
                RoomName = "Test Room",
                RoomLocation = "First floor",
                PlantsCount = 12,
                RoomInsolation = 56,
                LastVisit = new DateTime(2022, 02, 22, 22, 22, 22)
            };

            var roomServices = DataAccessFactory.GetRoomServicesInstance();
            roomServices.InsertRoom(roomToInsert);

            var room = roomServices.GetRooms().First();

            var plantServices = DataAccessFactory.GetPlantServicesInstance();

            var plant = new Plant()
            {
                RoomID = room.Id,
                PlantName = "Test name",
                PlantDescription = "Test Description",
                HydrationNeeded = "A little",
                HowManyDaysToHydration = 2,
                IsSunNeeded = false,
                LastHydration = new DateTime(2022, 02, 22, 22, 22, 22)
            };

            plantServices.InsertPlant(plant);
            var insertedPlant = plantServices.GetPlants().Single(p => p.PlantName == plant.PlantName);
            insertedPlant.PlantName = "name Test";
            insertedPlant.PlantDescription = "Description Test";
            plantServices.UpdatePlant(insertedPlant);
            var updatedPlant = plantServices.GetPlant(insertedPlant.Id);
            updatedPlant.PlantName.Should().Be("name Test");
            updatedPlant.PlantDescription.Should().Be("Description Test");
        }

        [Test]
        public void DeletePlant_ShouldDelete_OnePlant()
        {
            var roomToInsert = new Room()
            {
                RoomName = "Test Room",
                RoomLocation = "First floor",
                PlantsCount = 12,
                RoomInsolation = 56,
                LastVisit = new DateTime(2022, 02, 22, 22, 22, 22)
            };

            var roomServices = DataAccessFactory.GetRoomServicesInstance();
            roomServices.InsertRoom(roomToInsert);

            var room = roomServices.GetRooms().First();

            var plantServices = DataAccessFactory.GetPlantServicesInstance();

            var plant = new Plant()
            {
                RoomID = room.Id,
                PlantName = "Test name",
                PlantDescription = "Test Description",
                HydrationNeeded = "A little",
                HowManyDaysToHydration = 2,
                IsSunNeeded = false,
                LastHydration = new DateTime(2022, 02, 22, 22, 22, 22)
            };

            plantServices.InsertPlant(plant);
            var insertedPlant = plantServices.GetPlants().Single(p => p.PlantName == plant.PlantName);
            plantServices.DeletePlant(insertedPlant.Id);
            var plants = plantServices.GetPlants();
            plants.Should().NotContain(p => p.Id == insertedPlant.Id);
        }

        [Test]
        public void GetRoomPlants_ShouldReturn_RoomPlants()
        {
            var roomToInsert = new Room()
            {
                RoomName = "Test Room",
                RoomLocation = "First floor",
                PlantsCount = 12,
                RoomInsolation = 56,
                LastVisit = new DateTime(2022, 02, 22, 22, 22, 22)
            };

            var roomServices = DataAccessFactory.GetRoomServicesInstance();
            roomServices.InsertRoom(roomToInsert);

            var room = roomServices.GetRooms().First();

            var plantServices = DataAccessFactory.GetPlantServicesInstance();

            var plant = new Plant()
            {
                RoomID = room.Id,
                PlantName = "Test name",
                PlantDescription = "Test Description",
                HydrationNeeded = "A little",
                HowManyDaysToHydration = 2,
                IsSunNeeded = false,
                LastHydration = new DateTime(2022, 02, 22, 22, 22, 22)
            };

            plantServices.InsertPlant(plant);
            var roomPlants = plantServices.GetRoomPlants(room.Id);
            roomPlants.Should().Contain(plt => plt.RoomID == room.Id);
        }


        [Test]
        public void InsertPlant_ShouldInsert_OnePlant()
        {
            var roomToInsert = new Room()
            {
                RoomName = "Test Room",
                RoomLocation = "First floor",
                PlantsCount = 12,
                RoomInsolation = 56,
                LastVisit = new DateTime(2022, 02, 22, 22, 22, 22)
            };

            var roomServices = DataAccessFactory.GetRoomServicesInstance();
            roomServices.InsertRoom(roomToInsert);

            var room = roomServices.GetRooms().First();

            var plantServices = DataAccessFactory.GetPlantServicesInstance();

            var plant = new Plant()
            {
                RoomID = room.Id,
                PlantName = "Test name",
                PlantDescription = "Test Description",
                HydrationNeeded = "A little",
                HowManyDaysToHydration = 2,
                IsSunNeeded = false,
                LastHydration = new DateTime(2022, 02, 22, 22, 22, 22)
            };

            plantServices.InsertPlant(plant);

            var plants = plantServices.GetPlants();
            plants.Should().Contain(p => p.PlantName == plant.PlantName);
        }

        [Test]
        public void GetPlant_ShouldReturn_OnePlant()
        {
            var roomToInsert = new Room()
            {
                RoomName = "Test Room",
                RoomLocation = "First floor",
                PlantsCount = 12,
                RoomInsolation = 56,
                LastVisit = new DateTime(2022, 02, 22, 22, 22, 22)
            };

            var roomServices = DataAccessFactory.GetRoomServicesInstance();
            roomServices.InsertRoom(roomToInsert);

            var room = roomServices.GetRooms().First();

            var plantServices = DataAccessFactory.GetPlantServicesInstance();

            var plant = new Plant()
            {
                RoomID = room.Id,
                PlantName = "Test name",
                PlantDescription = "Test Description",
                HydrationNeeded = "A little",
                HowManyDaysToHydration = 2,
                IsSunNeeded = false,
                LastHydration = new DateTime(2022, 02, 22, 22, 22, 22)
            };

            plantServices.InsertPlant(plant);
            plant = plantServices.GetPlants().Single(p => p.PlantName == plant.PlantName);
            var insertedPlant = plantServices.GetPlant(plant.Id);
            insertedPlant.Should().NotBeNull();
        }
    }
}
