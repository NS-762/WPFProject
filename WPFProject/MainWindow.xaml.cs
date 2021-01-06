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

namespace WPFProject
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //private Windows.Registration reg1 = new Windows.Registration(); если есть это поле, то окно не закрывается?
        //private AllWindows allWindows;
        public MainWindow()
        {
            InitializeComponent();
            //allWindows = new AllWindows();  //запись окна в класс, где хранятся ссылки на все окна
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

