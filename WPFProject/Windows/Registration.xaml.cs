using System.Windows;
using WPFProject.Additional_classes;

namespace WPFProject.Windows
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        private string userType;

        public Registration(string userType)
        {
            InitializeComponent();
            AllWindows.Registration = this;

            
            this.userType = userType; //кого добавлять: пользователя или сотрудника (админ добавляет сотрудников)

            WindowStartupLocation = WindowStartupLocation.CenterScreen; //чтобы окно было по центру экрана
        }

        private void ButtonRegistration_Click(object sender, RoutedEventArgs e) //кнопка регистрации
        {

            if (!textBoxFirstName.Text.Equals("") && !textBoxSecondName.Text.Equals("") && !textBoxThirdName.Text.Equals("") //проверка, есть ли пустые поля
                && !textBoxEMail.Text.Equals("") && !textBoxPhoneNumber.Text.Equals("") && !textBoxPassword.Password.Equals(""))
            {

                foreach (var item in Users.listUsers) //сравнить введенный емейл с другими емейлами пользователей 
                {
                    if (textBoxEMail.Text == item.EMail)
                    {
                        MessageBox.Show("Данный E-mail уже используется");
                        return;
                    }
                } //если емейл не занят, идем дальше

                User user = new User(
                userType,
                textBoxFirstName.Text,
                textBoxSecondName.Text,
                textBoxThirdName.Text,
                textBoxPhoneNumber.Text,
                textBoxEMail.Text,
                textBoxPassword.Password); //создание пользователя и заполнение его полей

                Users.listUsers.Add(user); //добавление пользователя в список пользователей

                WorkWithXML.SerializeXML(); //вызов метода сериализации для списка пользователей, они запишутся в файл XML
                MessageBox.Show("Регистрация прошла успешно");


                if (AllWindows.MainAdmin != null)
                {
                    AllWindows.MainAdmin.AddItemDGUsers(user);
                }

                this.Close();
                
            }
            else
            {
                MessageBox.Show("Поля не должны быть пустыми");
            }
        }


    }
}