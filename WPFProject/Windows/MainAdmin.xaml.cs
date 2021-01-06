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
        public string UserType { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string PhoneNumber { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }

        public MainAdmin(string userType, string firstName, string secondName, string thirdName, string phoneNumber, string eMail, string password)
        {
            InitializeComponent();
            AllWindows.mainAdmin = this; //запись окна в класс, где хранятся ссылки на все окна


            UserType = userType;
            FirstName = firstName;
            SecondName = secondName;
            ThirdName = thirdName;
            PhoneNumber = phoneNumber;
            EMail = eMail;
            Password = password;

            FillDGUsers();
            
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void ButtonMyData_Click(object sender, RoutedEventArgs e) //вызов окна с данными пользователя
        {
            MyPersonalData myPersonalData = new MyPersonalData(UserType, FirstName, SecondName, ThirdName, PhoneNumber, EMail);
            myPersonalData.Show();
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e) //вызов основного окна, выход из личного кабинета
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
            MessageBox.Show("Вы вышли из личного кабинета");

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
