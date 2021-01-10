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
    /// Логика взаимодействия для Authentication.xaml
    /// </summary>
    public partial class Authentication : Window
    {
        public Authentication()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;  //чтобы окно было по центру экрана
        }

        private void ButtonAuthentication_Click(object sender, RoutedEventArgs e)
        {
            if (!textBoxEMail.Text.Equals("") && !textBoxPassword.Password.Equals("")) //проверка, есть ли пустые поля
            {
                string eMail = textBoxEMail.Text; //считывание полей
                string password = textBoxPassword.Password;

                WorkWithXML.DeSerializeXML(); //провести десериализацию ()

                foreach (var item in Users.listUsers) //поиск по списку, есть ли пользователь с соответствующим емейлом и паролем
                {
                    if (item.EMail.Equals(eMail) && item.Password.Equals(password))
                    {
                        MessageBox.Show("Вы успешно вошли в личный кабинет");


                        if (item.UserType.Equals("Администратор"))  //если тип пользователя - админ, то открыть окно, предназначенное для админа
                        {
                            MainAdmin mainAdmin = new MainAdmin(item);
                            mainAdmin.Show();
                        }
                        else if (item.UserType.Equals("Сотрудник"))  //если тип пользователя - сотрудник, то открыть окно, предназначенное для сотрудника
                        {
                            MainEmployee mainEmployee = new MainEmployee(item);
                            mainEmployee.Show();
                            
                        }
                        else if (item.UserType.Equals("Клиент")) //если тип пользователя - клиент, то открыть окно, предназначенное для клиента
                        {
                            MainClient mainClient = new MainClient(item);
                            mainClient.Show();
                        }
                        AllWindows.mainWindow.Close();
                        this.Close();
                        return;
                    }
                }
                MessageBox.Show("Не удалось войти в личный кабинет");
            }
            else
            {
                MessageBox.Show("Поля не должны быть пустыми");
            }
        }

        private void ButtonRegistration_Click(object sender, RoutedEventArgs e) //вызов окна
        {
            Registration reg1 = new Registration("Клиент");
            reg1.Show();
        }
    }
}