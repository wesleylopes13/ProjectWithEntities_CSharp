using ExeEntities17_04.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExeEntities17_04.Entities
{
    class Order
    {
        public DateTime Momment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Clients { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public Order()
        {

        }

        public Order(DateTime moment, OrderStatus status, Client clients)
        {
            Momment = moment;
            Status = status;
            Clients = clients;
        }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            Items.Remove(item);
        }

        public double Total()
        {
            double total = 0;
            foreach (OrderItem item in Items)
            {
                total += item.SubTotal();
            }

            return total;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("\n\nOrder Summary: ");
            sb.AppendLine("Order moment: " + Momment.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.AppendLine("Order status: " + Status);
            sb.AppendFormat("Client: " + Clients.Name + " " + Clients.BirthDate.ToString("dd/MM/yyyy") + " - " + Clients.Email);
            sb.AppendLine("\nOrder items:");

            foreach (OrderItem list in Items)
            {
                sb.AppendLine(list.Products.Name + ", $" + list.Price + ", Quantity: " + list.Quantity + ", SubTotal: " + list.SubTotal());
            }

            sb.AppendLine("Total price: $" + Total());

            return sb.ToString();
        }
    }
}
