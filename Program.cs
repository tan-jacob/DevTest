using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;

namespace Dev_Test_Nov_2021
{
    //Jacob

    public class apiObject
    {
        public string name { get; set; }
        public int age { get; set; }
        public int count { get; set; }
    }

    class Program
    {
        static HttpClient client = new HttpClient();

        
        static async Task getName(string path)
        {
            string s = null;
            try
            {
                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    s = await response.Content.ReadAsStringAsync();
                }
                JObject o = JObject.Parse(s);
                Console.WriteLine("Name: " + o.Property("name").Value
                                + "Age: " + o.Property("age").Value
                                + "Count: " + o.Property("count").Value);
            }
            catch(HttpRequestException e)
            {
                Console.WriteLine(e.Message);
            }

            return;
        }
        

        public class Order
        {
            public int id { get; set; }
            public double value { get; set; }
            public string customer { get; set; }
        }

        public static void sortedList(List<Order> list)
        {
            List<Order> SortedList = list.OrderBy(o => o.value).ToList();
            foreach(Order o in SortedList)
            {
                Console.WriteLine(o.id + "    " + o.value + "    " + "    " + o.customer);
            }
        }

        public async static Task Main(string[] args)
        {
            //Part 1
            /*
            try
            {
                HttpResponseMessage response = await client.GetAsync("https://api.agify.io/?name=jacob");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseBody);
            }
            catch(HttpRequestException e)
            {
                Console.WriteLine(e.Message);
            }
            */
            await getName("https://api.agify.io/?name=jacob");





            //Part 2
            List<Product> products = new List<Product> {
                new Product {Id = "B091NE9K3", Price =59.96, Quantity = 5},
                new Product {Id = "B091NEGU3", Price =7.05, Quantity = 10},
                new Product {Id = "B091NEEC3", Price =6.38, Quantity = 15},
                new Product {Id = "B091NE9S3", Price =13.25, Quantity = 23},
                new Product {Id = "B091NE9K4", Price =99.96, Quantity = 2},
                new Product {Id = "B091NEGU4", Price =22.83, Quantity = 150},
                new Product {Id = "B091NEEC4", Price =19.18, Quantity = 45},
                new Product {Id = "B091NE9S4", Price =28.88, Quantity = 345},
                new Product {Id = "B091NE9K5", Price =49.99, Quantity = 589},
                new Product {Id = "B091NEGU5", Price =12.05, Quantity = 25},
            };

            double average = 0;
            foreach (Product p in products)
            {
                average += p.Price;

                if (p.Quantity < 10)
                {
                    Console.WriteLine(p.Id + '$' + p.Price);
                }
            }
            Console.WriteLine("Average price is: " + Math.Round(average / products.Count, 2));

            //B091NE9K4 
            foreach (Product p in products)
            {
                if(p.Id == "B091NE9K4")
                {
                    p.Price = p.Price * 0.7;
                }
                Console.WriteLine(p.Id + " $" + p.Price);
            }

            //Part 3 
            int[] ordersIds = { 1, 2, 3, 4 , 5};
            double[] ordersValues = { 25.5, 92.5, 78.23, 12.95, 83.67 };
            string[] ordersCustomers = { "Tracy Erkut", "Arvin Aitken", "Ryan Mae", "Sherri Smith", "Adam Weller" };

            List<Order> unsortedList = new List<Order>();

            for (int i = 0; i < 5; i++)
            {
                Order o = new Order();
                o.id = ordersIds[i];
                o.customer = ordersCustomers[i];
                o.value = ordersValues[i];
                unsortedList.Add(o);
            }

            sortedList(unsortedList);
            return;
        }
    }

    class Product
    {
        public string Id { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }
    }
}
