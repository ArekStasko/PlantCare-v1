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

namespace PlantCare.WPF
{
    /// <summary>
    /// Interaction logic for UpdateRoomWindow.xaml
    /// </summary>
    public partial class UpdateRoomWindow : Window, IView
    {
        private MainWindow _mainWindow;
        private IRoomControllers _roomControllers;
        private Room _room;
        public Room room { get => _room; }

        public UpdateRoomWindow(MainWindow mainWindow, Guid Id)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            _roomControllers = ControllersFactory.GetRoomControllers(this);
            _room = _roomControllers.GetRoom(Id);
            this.DataContext = room;
        }


        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            var data = new List<string>()
            {
                RoomName.Text,
                RoomLocation.Text,
                PlantsCount.Text,
                RoomInsolation.Text,
                ImageSource.Text,
                Day.Text,
                Month.Text,
                Year.Text
            };

            _roomControllers.UpdateRoom(data, room.Id);
            _mainWindow.LoadElements();
            this.Close();
        }

        private void ChangeUrl_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                ImageInfo.Text = "";
                RoomImage.Source = new BitmapImage(new Uri(ImageSource.Text));
            }
            catch (Exception)
            {
                ImageSource.Text = "";
                RoomImage.Source = null;
                ImageInfo.Text = "Wrong image url";
            }
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
