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
using System.Windows.Shapes;
using PlantCare.Controllers;
using PlantCare.DataAccess.models;

namespace PlantCare.WPF.plantViews
{
    /// <summary>
    /// Interaction logic for AddPlantWindow.xaml
    /// </summary>
    public partial class AddPlantWindow : Window, IView
    {

        private IPlantControllers _plantControllers;
        public AddPlantWindow()
        {
            InitializeComponent();
            _plantControllers = ControllersFactory.GetPlantControlers(this);
        }

        private void AddPlant_Click(object sender, RoutedEventArgs e)
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

        private void ChangeUrl_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                ImageInfo.Text = "";
                PlantImage.Source = new BitmapImage(new Uri(ImageSource.Text));
            }
            catch (Exception)
            {
                ImageSource.Text = "";
                PlantImage.Source = null;
                ImageInfo.Text = "Wrong image url";
            }
        }
    }
}
