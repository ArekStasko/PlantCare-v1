using PlantCare.Controllers;

namespace PlantCare 
{
    public class Program
    {
        static void Main(string[] args)
        {
            var view = new View();
            view.TestConnection();
        }
    }

    public class View
    {
        public void TestConnection()
        {
            IPlantControllers plantControllers = ControllersFactory.GetPlantControlers();
            plantControllers.TestServiceConnection();
        }
    }
}