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
using WPFProject.Additional_classes;

namespace WPFProject.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainEmployee.xaml
    /// </summary>
    public partial class MainEmployee : Window
    {
        public string UserType { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string PhoneNumber { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }

        public MainEmployee(string userType, string firstName, string secondName, string thirdName, string phoneNumber, string eMail, string password)
        {
            InitializeComponent();
            AllWindows.mainEmployee = this; //запись окна в класс, где хранятся ссылки на все окна


            UserType = userType;
            FirstName = firstName;
            SecondName = secondName;
            ThirdName = thirdName;
            PhoneNumber = phoneNumber;
            EMail = eMail;
            Password = password;

            //FillDGOrders();

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

        public void FillDGOrders()
        {
            Orders.listOrders.Add(new Order("10", "10", "10", "10", "10"));
            dgOrders.ItemsSource = Orders.listOrders;
        }

        public void UpdateDGOrderss()
        {
            dgOrders.ItemsSource = null;
            dgOrders.ItemsSource = Orders.listOrders;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Orders.listOrders.Add(new Order("10", "10", "10", "10", "10"));
            Orders.listOrders.Add(new Order("20", "20", "20", "20", "20"));
            Orders.listOrders.Add(new Order("101", "101", "101", "101", "101"));
            dgOrders.ItemsSource = Orders.listOrders;


            //Orders.listOrders.ListChanged += ListOrders_ListChanged;
        }

        //private void ListOrders_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        //{
        //    switch (e.ListChangedType)
        //    {
        //        case System.ComponentModel.ListChangedType.Reset:
        //            break;
        //        case System.ComponentModel.ListChangedType.ItemAdded:
        //            break;
        //        case System.ComponentModel.ListChangedType.ItemDeleted:
        //            break;
        //        case System.ComponentModel.ListChangedType.ItemMoved:
        //            break;
        //        case System.ComponentModel.ListChangedType.ItemChanged:
        //            break;
        //        case System.ComponentModel.ListChangedType.PropertyDescriptorAdded:
        //            break;
        //        case System.ComponentModel.ListChangedType.PropertyDescriptorDeleted:
        //            break;
        //        case System.ComponentModel.ListChangedType.PropertyDescriptorChanged:
        //            break;
        //        default:
        //            break;
        //    }
        //}

        public void DeletedOrder(Order order)
        {
            Orders.listOrders.Remove(order);
            //UpdateDGOrderss();
        }
    }
}
