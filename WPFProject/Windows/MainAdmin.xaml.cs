using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using WPFProject.Additional_classes;

namespace WPFProject.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainAdmin.xaml
    /// </summary>
    public partial class MainAdmin : Window
    {

        private User user;

        public MainAdmin(User user)
        {
            InitializeComponent();
            AllWindows.MainAdmin = this; //запись окна в класс, где хранятся ссылки на все окна

            this.user = user;

            FillDGUsers();
            
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void ButtonMyData_Click(object sender, RoutedEventArgs e) //вызов окна с данными пользователя
        {
            MyPersonalData myPersonalData = new MyPersonalData(user.UserType, user.FirstName, user.SecondName, user.ThirdName, user.PhoneNumber, user.EMail);
            myPersonalData.Show();
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e) //вызов основного окна, выход из личного кабинета
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void ButtonAddEmployee_Click(object sender, RoutedEventArgs e) //вызов основного окна, выход из личного кабинета
        {
            Registration registration = new Registration("Сотрудник");
            registration.Show();
        }

        public void FillDGUsers()
        {
            dgUsers.ItemsSource = Users.listUsers;
        }        
        
        public void AddItemDGUsers(User user)
        {
            dgUsers.ItemsSource = null;
            dgUsers.ItemsSource = Users.listUsers;
        }
    }
}
