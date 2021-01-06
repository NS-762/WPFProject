using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;


namespace WPFProject.Additional_classes
{
    class WorkWithXML
    {
        private static XmlSerializer xml = new XmlSerializer(typeof(List<User>)); //десериализация
        public static void DeSerializeXML()
        {
            using (FileStream fs = new FileStream("Users.xml", FileMode.Open))
            {
                Users.listUsers = (List<User>)xml.Deserialize(fs);
            }
        }

        public static void SerializeXML() //сериализация
        {
            using (FileStream fs = new FileStream("Users.xml", FileMode.Create))
            {
                xml.Serialize(fs, Users.listUsers);
            }
        }

        public static void SerializeAdminXML() //сериализация админа
        {
            using (FileStream fs = new FileStream("Users.xml", FileMode.Create))
            {
                User admin = new User(
                "Администратор", "Иван", "Иванов", "Иванович", "55-55-55", "1", "1" ); //создание пользователя и заполнение его полей

                Users.listUsers.Add(admin); //добавление пользователя в список пользователей
                xml.Serialize(fs, Users.listUsers);
            }
        }

    }
}
