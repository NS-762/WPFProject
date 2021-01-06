using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFProject.Additional_classes
{

    [Serializable]
    public class Users
    {
        public static List<User> listUsers = new List<User>();
    }

    [Serializable]
    public class User
    {
        public string UserType { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string PhoneNumber { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }

        public User() { }

        public User(string userType, string firstName, string secondName, string thirdName, string phoneNumber, string eMail, string password)
        {
            UserType = userType;
            FirstName = firstName;
            SecondName = secondName;
            ThirdName = thirdName;
            PhoneNumber = phoneNumber;
            EMail = eMail;
            Password = password;
        }
    }
}
