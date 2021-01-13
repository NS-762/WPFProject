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
        private User user;

        public MainEmployee(User user)
        {
            InitializeComponent();
            AllWindows.MainEmployee = this; //запись окна в класс, где хранятся ссылки на все окна

            this.user = user;

            FillDGOrders();

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

        public void FillDGOrders()
        {
            dgOrders.ItemsSource = Orders.listOrders;
        }

        public void DeletedOrder(Order order)
        {
            Orders.listOrders.Remove(order);
        }

        private void ButtonPromotion_Click(object sender, RoutedEventArgs e) //вызов основного окна, выход из личного кабинета
        {
            Promotion promotion = new Promotion();
            promotion.Show();
        }
    }
}
