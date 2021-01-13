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
        private int orderPrice = 0;

        public Cart(BindingList<Product> listProducts) //если окно вызвано из MainWindow (без авторизации)
        {
            InitializeComponent();
            AllWindows.Cart = this; //запись окна в класс, где хранятся ссылки на все окна
            this.listProducts = listProducts;
            FillDGProducts(); //заполнить список 
            WindowStartupLocation = WindowStartupLocation.CenterScreen; //чтобы окно было по центру экрана
        }        
        
        public Cart(User user, BindingList<Product> listProducts) //если окно вызвано из MainClient (авторизированный пользователь)
        {
            InitializeComponent();
            AllWindows.Cart = this; //запись окна в класс, где хранятся ссылки на все окна
            this.user = user;
            this.listProducts = listProducts;
            FillDGProducts();
            WindowStartupLocation = WindowStartupLocation.CenterScreen; //чтобы окно было по центру экрана
        }

        public void IncreaseOrderPrice(Product product) //увеличить сумму заказа (при добавлении нового товара)
        {
            orderPrice += product.Price;
            labelOrderPrice.Text = "Сумма заказа: " + orderPrice + " руб.";
        }

        public void FillDGProducts()
        {
            dgProducts.ItemsSource = listProducts;
            if (user != null) //для вошедших в учетную запись
            {
                labelUserCash.Text = "На вашем счету: " + user.Cash + " руб.";
            }
            else //для не вошедших в учетную запись
            {
                labelUserCash.Text = "На вашем счету: 0 руб.";
            }
            

            foreach (var item in listProducts) //расчет суммы заказа
            {
                orderPrice += item.Price * item.Quantity;
            }
            labelOrderPrice.Text = "Сумма заказа: " + orderPrice + " руб.";
        }        


        
        public void UpdateDGProducts()
        {
            dgProducts.ItemsSource = null;
            dgProducts.ItemsSource = listProducts;
        }

        public void DeletedProduct(Product product)
        {
            listProducts.Remove(product);
            orderPrice -= product.Price * product.Quantity;
            labelOrderPrice.Text = "Сумма заказа:" + orderPrice + "руб.";
        }


        private void ButtonBuy_Click(object sender, RoutedEventArgs e) //кнопка покупки
        {
            if (user == null) 
            {
                MessageBox.Show("Для совершения покупки необходимо войти в учетную запись");
            }
            else
            {
                if (listProducts.Count != 0)
                {
                    if (orderPrice <= user.Cash) //хвататет денег на счету пользователя
                    {
                        MessageBox.Show("Покупка совершена успешно");
                        listProducts.Clear();
                        user.Cash -= orderPrice;
                        labelOrderPrice.Text = "Сумма заказа: 0 руб.";
                        orderPrice = 0;
                        labelUserCash.Text = "На вашем счету: " + user.Cash + " руб.";

                        Random x = new Random();
                        int randomNumberOrder = x.Next(1, 1000);
                        Orders.listOrders.Add(new Order(Convert.ToString(randomNumberOrder), user.FirstName, user.SecondName, user.ThirdName, user.EMail));
                    }
                    else
                    {
                        MessageBox.Show("На вашем счету недостаточно средств");
                    }
                } 
                else
                {
                    MessageBox.Show("Ваша корзина пуста");
                }
            }
        }
        
        private void ButtonAddFunds_Click(object sender, RoutedEventArgs e) //кнопка покупки
        {
            if (user == null) 
            {
                MessageBox.Show("Для пополнения счета необходимо войти в учетную запись");
            }
            else
            {
                user.Cash += 2000;
                labelUserCash.Text = "На вашем счету: " + user.Cash + " руб.";
                WorkWithXML.SerializeXML();
            }
        }

    }
}
