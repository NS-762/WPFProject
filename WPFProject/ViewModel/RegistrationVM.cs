using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WPFProject.Additional_classes;

namespace WPFProject.ViewModel
{
    public class RegistrationVM
    {


        public string FirstName { get; set; } = "";
        public string SecondName { get; set; } = "";
        public string ThirdName { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public string EMail { get; set; } = "";


        public ICommand RegistrationCommand
        {
            get
            {
                return new ActionCommand<object>((parametr) =>
                {
                    ButtonRegistration_Click(parametr);
                });
            }
        }

        private void ButtonRegistration_Click(Object parametr) //кнопка регистрации
        {
            var passwordBox = parametr as PasswordBox;

            if (!FirstName.Equals("") && !SecondName.Equals("") && !ThirdName.Equals("") //проверка, есть ли пустые поля
                && !PhoneNumber.Equals("") && !EMail.Equals("") && !passwordBox.Password.Equals(""))
            {

                foreach (var item in Users.listUsers) //сравнить введенный емейл с другими емейлами пользователей 
                {
                    if (EMail == item.EMail)
                    {
                        MessageBox.Show("Данный E-mail уже используется");
                        return;
                    }
                } //если емейл не занят, идем дальше

                User user = new User(
                AllWindows.Registration.UserType,
                FirstName,
                SecondName,
                ThirdName,
                PhoneNumber,
                EMail,
                passwordBox.Password); //создание пользователя и заполнение его полей

                Users.listUsers.Add(user); //добавление пользователя в список пользователей

                WorkWithXML.SerializeXML(); //вызов метода сериализации для списка пользователей, они запишутся в файл XML
                MessageBox.Show("Регистрация прошла успешно");


                if (AllWindows.MainAdmin != null)
                {
                    AllWindows.MainAdmin.AddItemDGUsers(user);
                }

                AllWindows.Registration.Close();

            }
            else
            {
                MessageBox.Show("Поля не должны быть пустыми");
                //FirstName = "";
                //SecondName = "";
                //ThirdName = "";
                //PhoneNumber = "";
                //EMail = "";
                passwordBox = null;
            }
        }
    }

}

