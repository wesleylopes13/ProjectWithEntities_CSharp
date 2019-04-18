using ExeEntities17_04.Entities;
using ExeEntities17_04.Entities.Enum;
using System;
using System.Globalization;

namespace ExeEntities17_04
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter client data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Birth date (DD/MM//YYY): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter order data: ");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());

            // Inserindo valores nas classes
            Client client = new Client(name, email, birthDate);
            Order order = new Order(DateTime.Now, status, client);


            Console.Write("How many items to this order? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} item data:");
                Console.Write("Product name: ");
                string nameProd = Console.ReadLine();

                Console.Write("Product price: ");
                double priceProd = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.Write("Quantity: ");
                int qtd = int.Parse(Console.ReadLine());

                Product prod = new Product(nameProd, priceProd);
                OrderItem orderItem = new OrderItem(qtd, prod.Price, prod);

                order.AddItem(orderItem);
               
            }
            
            Console.WriteLine("\n\nOrder Summary");
            Console.WriteLine("Order moment: " + order.Momment.ToString("dd/MM/yyyy HH:mm:ss"));
            Console.WriteLine("Order status:" + order.Status);
            Console.WriteLine("Client: " + order.Clients.Name + " " + order.Clients.BirthDate.ToString("dd/MM/yyyy") + " - " + order.Clients.Email);
            Console.WriteLine("Order items: ");
            foreach (OrderItem list in order.Items)
            {
                Console.WriteLine(list.Products.Name + ", $" + list.Price + ", Quantity: " + list.Quantity + ", SubTotal: " + list.SubTotal());
            }

            Console.WriteLine("Total price: $" + order.Total());
            

            
            Console.ReadLine();


            }
    }
}
