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
    /// Логика взаимодействия для MainClient.xaml
    /// </summary>
    /// 

    public partial class MainClient : Window
    {

        private User user;
        private Windows.Cart cart;
        private BindingList<Product> listProducts;


        public MainClient(User user)
        {
            InitializeComponent();
            AllWindows.MainClient = this; //запись окна в класс, где хранятся ссылки на все окна
            this.user = user;

            listProducts = new BindingList<Product>(); //список опкупок
            
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

        private void ButtonCart_Click(object sender, RoutedEventArgs e)
        {
            cart = new Windows.Cart(user, listProducts); //привязать корзину
            cart.Show();
        }

        private void AddProductOneInCart_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product("Мачете 2 МА-851", 2500);
            AddProductInCart(product); //вызов метода добавления продукта в корзину
            СhangeOrderPrice(product);
        }

        private void AddProductTwoInCart_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product("Нож Ka-Bar 2221", 7500);
            AddProductInCart(product); //вызов метода добавления продукта в корзину
            СhangeOrderPrice(product);
        }


        private void AddProductThreeInCart_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product("Топор Trench Hawk", 3450);
            AddProductInCart(product); //вызов метода добавления продукта в корзину
            СhangeOrderPrice(product);
        }


        private void AddProductFourInCart_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product("Нож Fallkniven PRK Z", 10200);
            AddProductInCart(product); //вызов метода добавления продукта в корзину
            СhangeOrderPrice(product);
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
        
        private void СhangeOrderPrice(Product product) //сюда передает объект типа продукт
        { 
            if (cart != null) //если окно карзины есть, то список в окне обновить
            {
                cart.IncreaseOrderPrice(product);
            }
        }

    }

    
}