using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WPFProject.Additional_classes;
using WPFProject.Windows;

namespace WPFProject.ViewModel
{
    public class AuthenticationVM
    {

        public string EMail { get; set; } = "";

        public ICommand AuthenticationCommand
        {
            get
            {
                return new ActionCommand<object>((parametr) =>
                {
                    ButtonAuthentication_Click(parametr);
                });
            }
        }
        
        public ICommand RegistrationCommand
        {
            get
            {
                return new ActionCommand<object>((parametr) =>
                {
                    ButtonRegistration_Click();
                });
            }
        }

        private void ButtonAuthentication_Click(Object parametr)
        {

            PasswordBox passwordBox = parametr as PasswordBox;

            if (!EMail.Equals("") && !passwordBox.Password.Equals("")) //проверка, есть ли пустые поля
            {
                string eMail = EMail; //считывание полей
                string password = passwordBox.Password;

                //WorkWithXML.DeSerializeXML(); //провести десериализацию ()

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
                        AllWindows.MainWindow.Close();

                        AllWindows.Authentication.Close();
                        return;
                    }
                }
                MessageBox.Show("Не удалось войти в личный кабинет");
            }
            else
            {
                MessageBox.Show("Поля не должны быть пустыми");
                passwordBox = null;
            }
        }

        private void ButtonRegistration_Click() //вызов окна
        {
            Registration reg1 = new Registration("Клиент");
            reg1.Show();
        }

    }
    
}
