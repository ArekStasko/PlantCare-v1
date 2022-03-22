using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PlantCare.DataAccess.models;
using PlantCare.Controllers;

namespace PlantCare.WPF.plantViews
{
    /// <summary>
    /// Interaction logic for PlantsView.xaml
    /// </summary>
    public partial class PlantsView : Page, IView
    {
        private IPlantControllers _plantControllers;
        private Guid _roomID;
        private List<Plant> _plants;
        public List<Plant> Plants {
            get => _plants;
            set => _plants = value;
        }

        public PlantsView(Guid roomID)
        {
            InitializeComponent();
            _roomID = roomID;   
            _plantControllers = ControllersFactory.GetPlantControlers(this);
        }

        public void Load_Elements()
        {
            Plants = _plantControllers.GetRoomPlants(_roomID);
            icPlants.ItemsSource = Plants;
        }

        private void icPlants_Loaded(object sender, RoutedEventArgs e) => Load_Elements();

        private void AddPlant_Click(object sender, RoutedEventArgs e)
        {
            var addPlantView = new AddPlantWindow();
            addPlantView.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        public void DisplayMessage(string msg)
        {
            string caption = "Info";
            MessageBoxButton btn = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Information;
            MessageBox.Show(msg, caption, btn, icon);
        }

        public void DisplayErrorMessage(string msg)
        {
            string caption = "Error";
            MessageBoxButton btn = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Error;
            MessageBox.Show(msg, caption, btn, icon);
        }
    }
}
