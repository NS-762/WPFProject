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

using System.ComponentModel;

namespace WPFProject.Windows
{
    /// <summary>
    /// Логика взаимодействия для Cart.xaml
    /// </summary>
    public partial class Cart : Window
    {

        private BindingList<Product> listProducts;
        private User user = null;

        public Cart(BindingList<Product> listProducts) //если окно вызвано из MainWindow (без авторизации)
        {
            InitializeComponent();
            AllWindows.cart = this; //запись окна в класс, где хранятся ссылки на все окна
            this.listProducts = listProducts;
            FillDGProducts(); //заполнить список 
            WindowStartupLocation = WindowStartupLocation.CenterScreen; //чтобы окно было по центру экрана
        }        
        
        public Cart(User user, BindingList<Product> listProducts) //если окно вызвано из MainClient (авторизированный пользователь)
        {
            InitializeComponent();
            AllWindows.cart = this; //запись окна в класс, где хранятся ссылки на все окна
            this.user = user;
            this.listProducts = listProducts;
            FillDGProducts();
            WindowStartupLocation = WindowStartupLocation.CenterScreen; //чтобы окно было по центру экрана
        }

        public void FillDGProducts()
        {
            dgProducts.ItemsSource = listProducts;
        }        
        
        public void UpdateDGProducts()
        {
            dgProducts.ItemsSource = null;
            dgProducts.ItemsSource = listProducts;
        }

        public void DeletedProduct(Product product)
        {
            listProducts.Remove(product);
        }


        private void ButtonBuy_Click(object sender, RoutedEventArgs e) //кнопка покупки
        {
            if (user == null) 
            {
                MessageBox.Show("Для совершения покупки необходимо войти в учетную запись");
            }
            else
            {
                MessageBox.Show("Покупка совершена успешно");
                listProducts.Clear();
                AllWindows.mainEmployee.AddOrder(user);
            }
        }

    }
}
