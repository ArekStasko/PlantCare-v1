﻿
namespace PlantCare.DataAccess.models
{
    public class Plant : IPlant
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string HydrationNeeded { get; set; }
        public int HowManyDaysToHydration { get; set; }
        public bool IsSunNeeded { get; set; }
        public DateTime LastHydration { get; set; }
    }
}
