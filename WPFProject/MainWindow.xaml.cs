using System;
using System.Collections.Generic;
using System.IO;
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
using WPFProject.Additional_classes;

using System.ComponentModel;

namespace WPFProject
{

    public partial class MainWindow : Window
    {

        private BindingList<Product> listProducts;
        private Windows.Cart cart;

        public MainWindow()
        {
            InitializeComponent();
            AllWindows.mainWindow = this;
            
            if (!File.Exists("Users.xml")) //проверить, есть ли файл с пользователями
            {
                WorkWithXML.SerializeAdminXML(); //если нет - создать и поместить туда админа
            }

            string[] content = File.ReadAllLines("Users.xml");

            if (content.Length == 0) //если файл существует, но пустой
            {
                WorkWithXML.SerializeAdminXML(); //поместить в него админа
            } 
            else //если файл не пустой
            {
                WorkWithXML.DeSerializeXML(); //провести десериализацию
            }

            listProducts = new BindingList<Product>(); //список опкупок


            WindowStartupLocation = WindowStartupLocation.CenterScreen; //чтобы окно было по центру экрана
        }

        private void ButtonRegistration_Click(object sender, RoutedEventArgs e) //вызов окна регистрации
        {
            Windows.Registration registration = new Windows.Registration("Клиент");
            registration.Show();

        }

        private void ButtonAuthentication_Click(object sender, RoutedEventArgs e) //вызов окна аутентификации
        {
            Windows.Authentication authentication = new Windows.Authentication();
            authentication.Show();
        }

        private void ButtonCart_Click(object sender, RoutedEventArgs e)
        {
            cart = new Windows.Cart(listProducts); //привязать корзину
            cart.Show();
        }

        private void AddProductOneInCart_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product("Мачете 2 МА-851", "2500 руб.");
            AddProductInCart(product); //вызов метода добавления продукта в корзину
        }

        private void AddProductTwoInCart_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product("Нож Ka-Bar 2221", "7500 руб.");
            AddProductInCart(product); //вызов метода добавления продукта в корзину
        }


        private void AddProductThreeInCart_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product("Топор Trench Hawk", "3450 руб.");
            AddProductInCart(product); //вызов метода добавления продукта в корзину
        }


        private void AddProductFourInCart_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product("Нож Fallkniven PRK Z", "10200 руб.");
            AddProductInCart(product); //вызов метода добавления продукта в корзину
        }

        private void AddProductInCart(Product product) //сюда передает объект типа продукт
        {
            foreach (var item in listProducts)
	        {
                if (item.ProductName == product.ProductName) //если такой продукт уже есть, то увеличить его количество на 1
                {
                    item.Quantity++;
                    if (cart != null) //если окно карзины есть, то список в окне обновить
                    {
                        cart.UpdateDGProducts();
                    }
                    return; //и выйти
                }
 	        }
            listProducts.Add(product); //если продукта такого нет, то создать
        }

    }
}

