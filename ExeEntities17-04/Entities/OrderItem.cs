using System;
using System.Collections.Generic;
using System.Text;

namespace ExeEntities17_04.Entities
{
    class OrderItem
    {

        public int Quantity { get; set; }
        public double Price { get; set; }
        public Product Products { get; set; }

        public OrderItem()
        {

        }

        public OrderItem(int quantity, double price, Product products)
        {
            Quantity = quantity;
            Price = price;
            Products = products;
        }

        public double SubTotal()
        {
            double sum = Products.Price;

            sum *= Quantity;

            return sum;
        }
    }
}
