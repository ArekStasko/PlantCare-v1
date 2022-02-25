using PlantCare.Controllers;

namespace PlantCare 
{
    public class Program
    {
        static void Main(string[] args)
        {
            var view = new View();
        }
    }

    public class View
    {

        public void DisplayMessage(string msg)
        {
            Console.WriteLine($"{msg}");
        }

        public void DisplayErrorMessage(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{msg}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}