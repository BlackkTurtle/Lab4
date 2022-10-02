using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04
{
    class ShoppingSpree
    {
        private Guest[] guests;
        private Product[] products;
        private class Guest
        {
            public string name;
            public int money;
            public string amount=null;
        }
        private class Product
        {
            public string name;
            public int price;
        }
        public void GuestsCreate(string strarray)
        {
            string[] array1 = strarray.Split(';','=');
            guests = new Guest[array1.Length/2];
            int a=0;
            for(int i = 0; i < array1.Length; i++)
            {
                if (i % 2 == 1)
                {
                    guests[a].money = Convert.ToInt32(array1[i]);
                    if (guests[a].money < 0)
                    {
                        Console.WriteLine("Money can t be negative");
                        continue;
                    }
                    a++;
                }
                else
                {
                    guests[a] = new Guest();
                    guests[a].name = array1[i];
                }
            }
        }
        public void ProductsCreate(string strarray)
        {
            string[] array1 = strarray.Split(';', '=');
            products = new Product[array1.Length / 2];
            int a = 0;
            for (int i = 0; i < array1.Length; i++)
            {
                if (i % 2 == 1)
                {
                    products[a].price = Convert.ToInt32(array1[i]);
                    a++;
                }
                else
                {
                    products[a] = new Product();
                    products[a].name = array1[i];
                }
            }
        }
        public void Buy(string str)
        {
            string[] array1 = str.Split(' ');
            string[] arrayGuests = new string[guests.Length];
            string[] arrayProducts = new string[products.Length];
            for (int i = 0; i < guests.Length; i++)
            {
                arrayGuests[i]=guests[i].name;
            }
            for (int i = 0; i < products.Length; i++)
            {
                arrayProducts[i]=products[i].name;
            }
            int indexGuests = Array.IndexOf(arrayGuests, array1[0]);
            int indexProducts = Array.IndexOf(arrayProducts, array1[1]);
            if (guests[indexGuests].money >= products[indexProducts].price)
            {
                Console.WriteLine(array1[0]+" bought " + array1[1]);
                guests[indexGuests].money -= products[indexProducts].price;
                if (guests[indexGuests].amount == null)
                {
                    guests[indexGuests].amount = array1[1];
                }
                else
                {
                    guests[indexGuests].amount += ", " + array1[1];
                }
            }
            else
            {
                Console.WriteLine(array1[0]+" Can t afford "+array1[1]);
            }
        }
        public void Finish()
        {
            for (int i = 0; i < guests.Length; i++)
            {
                if (guests[i].amount == null)
                {
                    Console.WriteLine(guests[i].name + " - Nothing Bought");
                }
                else
                {
                    Console.WriteLine(guests[i].name + " - " + guests[i].amount);
                }
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string strarray = Console.ReadLine();
            ShoppingSpree shoppingSpree = new ShoppingSpree();
            shoppingSpree.GuestsCreate(strarray);
            string strarray1 = Console.ReadLine();
            shoppingSpree.ProductsCreate(strarray1);
            while (true)
            {
                string str = Console.ReadLine();
                if (str == "End")
                {
                    shoppingSpree.Finish();
                    break;
                }
                else
                {
                    shoppingSpree.Buy(str);
                }
            }
        }
    }
}