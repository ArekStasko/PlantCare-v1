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
using PlantCare.Controllers;
using PlantCare.DataAccess.models;

namespace PlantCare.WPF
{

    public partial class MainWindow : Window, IView
    {
        private IRoomControllers _roomControllers;
        private List<Room> _rooms;
        public List<Room> Rooms
        {
            get => _rooms;
            set => _rooms = value;
        }

        public MainWindow()
        {
            InitializeComponent();
            _roomControllers = ControllersFactory.GetRoomControllers(this);
        }

        public void LoadElements()
        {
            Rooms = _roomControllers.GetRooms();
            icRooms.ItemsSource = Rooms;
        }
        private void icRooms_Loaded(object sender, RoutedEventArgs e) => LoadElements();

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

        private void DeleteRoom(Guid Id)
        {
            _roomControllers.DeleteRoom(Id);
            LoadElements();
        } 
        
        private void DeleteRoom_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            DeleteRoom((Guid)button.Tag);
        }

        private void AddRoom_Click(object sender, RoutedEventArgs e)
        {
            var addRoomView = new AddRoomWindow(this);
            addRoomView.Show();
        }

        private void UpdateRoom_Click(object sender, RoutedEventArgs e)
        {
            Button? btn = sender as Button;
            var Id = (Guid)btn.Tag;
            var updateRoomView = new UpdateRoomWindow(this, Id);
            updateRoomView.Show();
        }
    }
}
