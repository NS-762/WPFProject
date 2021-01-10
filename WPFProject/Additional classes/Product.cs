using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace WPFProject.Additional_classes
{
    
    public class Product
    {
        private bool _delete;

        public string ProductName { get; set; }
        public string Price { get; set; }
        public int Quantity { get; set; } = 1;
        public bool Delete
        {
            get { return _delete; }
            set
            {
                if (_delete == value)
                    return;
                _delete = value;

                AllWindows.cart.DeletedProduct(this); //если поменять статус заказа, он удалится из списка заказов
            }
        }


        public Product(string productName, string price)
        {
            ProductName = productName;
            Price = price;
        }
    }
}
