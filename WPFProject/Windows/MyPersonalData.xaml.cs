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

namespace WPFProject.Windows
{
    /// <summary>
    /// Логика взаимодействия для MyPersonalData.xaml
    /// </summary>
    public partial class MyPersonalData : Window
    {
        public MyPersonalData(string userType, string firstName, string secondName, string thirdName, string phoneNumber, string eMail/*, string password*/)
        {
            InitializeComponent();
            labelUserType.Content = userType;
            labelFirstName.Content = firstName;
            labelSecondName.Content = secondName;
            labelThirdName.Content = thirdName;
            labelPhoneNumber.Content = phoneNumber;
            labelEMail.Content = eMail;

            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

    }
}
