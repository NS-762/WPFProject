using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFProject.Additional_classes
{

    [Serializable]
    public class Orders
    {
        public static BindingList<Order> listOrders = new BindingList<Order>();
    }

    [Serializable]
    public class Order  /*INotifyPropertyChanged*/
    {


        private bool _orderStatus = false;

        public string OrderNumber { get; set; }
        public bool OrderStatus
        {
            get { return _orderStatus; }
            set
            {
                if (_orderStatus == value)
                    return;
                _orderStatus = value;
                
                AllWindows.mainEmployee.DeletedOrder(this); //если поменять статус заказа, он удалится из списка заказов
                
                //OnPropertyChanged("_orderStatus");
            }
        }
        

        public string СustomerFirstName { get; set; }
        public string СustomerSecondName { get; set; }
        public string CustomerThirdName { get; set; }
        public string CustomerEMail { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;

        public Order() { }

        public Order(string orderNumber, string customerFirstName, string customerSecondName,
            string customerThirdName, string customerEMail)
        {
            OrderNumber = orderNumber;
            СustomerFirstName = customerFirstName;
            СustomerSecondName = customerSecondName;
            CustomerThirdName = customerThirdName;
            CustomerEMail = customerEMail;
        }

        //public event PropertyChangedEventHandler PropertyChanged;

        //protected virtual void OnPropertyChanged(string propertyName = "")
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
    }
}
