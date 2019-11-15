using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var basket = new Basket();
            
            //Shirt (TShirt)

            var tshirt_1 = new TShirt();
            tshirt_1.Name = "DC Comics";
            tshirt_1.Size = "m";
            basket.Shirts.Add(tshirt_1);

            //Shirt (Golfer) using custom constructor and .addShirt method

            var tshirt_2 = new Golfer("S", "Polo");
            basket.addShirt(tshirt_2);

            //Pants (Jeans)

            var pants_1 = new Jeans();
            pants_1.Name = "Mr. Price";
            pants_1.Size = "L";
            basket.Shirts.Add(pants_1);

            //Pants (FormalPants) using custom constructor and .addPants method

            var pants_2 = new FormalPants("s", "Stone Harbor");
            basket.addPants(pants_2);

            //Basket total price

            Console.WriteLine($"Your total price is {basket.GetTotalPrice()}");
            Console.Read();
        }

        //Basket class

        public class Basket
        {

            //Shirt and Pants lists to store Product objects

            public List<Product> Shirts = new List<Product>();
            public List<Product> Pants = new List<Product>();

            //constructor

            public Basket()
            {

            }

            //custom method to insert shirt into basket

            public void addShirt(Product s)
            {
                Shirts.Add(s);
            }

            //custom method to insert pants into basket

            public void addPants(Product p)
            {
                Pants.Add(p);
            }

            /*method to calculate total price of basket by iterating through each lists entries and
            calling the abstract price method to retrieve price of product iterated*/ 

            public int GetTotalPrice()
            {

                int total = 0;

                foreach(Product shirt in Shirts)
                {
                    total += shirt.getPrice();
                }

                foreach (Product pants in Pants)
                {
                    total += pants.getPrice();
                }

                return total;

            }

        }

        //abstract class product

        public abstract class Product
        {
            //default prices of products

            public int default_S = 10;
            public int default_M = 20;
            public int default_L = 30;

            /* method that can be used by any product to retrieve their 
            default price based on their size */

            public int getDefPrice(String size)
            {
                if (size == "s" || size == "S")
                {
                    return default_S;
                }

                else if (size == "m" || size == "M")
                {
                    return default_M;
                }

                else if (size == "l" || size == "L")
                {
                    return default_L;
                }

                else
                {
                    return 0;
                }
            }

            /* abstract method that is overiden by each product to perform
            their unique calculation of the final price of the product */

            public abstract int getPrice();

        }

        //Shirt (TShirt) product class

        public class TShirt : Product
        {
            public string Size;
            public string Name;
            int extra = 1;          //the multiplier to the price of the shirt


            //default constructor

            public TShirt() {}

            //custom constructor

            public TShirt(string s, string n)
            {
                Size = s;
                Name = n;
            }

            //overriden abstract method

            public override int getPrice()
            {

                return getDefPrice(Size) * extra;

            }
        }

        //Shirt (Golfer) product class

        public class Golfer : Product
        {
            public string Size;
            public string Name;
            int extra = 2;        //the multiplier to the price of the shirt


            //default constructor

            public Golfer() { }

            //custom constructor

            public Golfer(string s, string n)
            {
                Size = s;
                Name = n;
            }

            //overriden abstract method

            public override int getPrice()
            {

                return getDefPrice(Size) * extra;

            }
        }

        //Pants (Jeans) product class

        public class Jeans : Product
        {

            public string Size;
            public string Name;
            int extra = 0;         //additive to the price of the pants


            //default constructor

            public Jeans() { }

            //custom constructor

            public Jeans(string s, string n)
            {
                Size = s;
                Name = n;
            }

            //overriden abstract method

            public override int getPrice()
            {

                return getDefPrice(Size) + extra;

            }
        }

        //Pants (FormalPants) product class

        public class FormalPants : Product
        {

            public string Size;
            public string Name;
            int extra = 30;         //additive to the price of the pants


            //default constructor

            public FormalPants() { }

            //custom constructor

            public FormalPants(string s, string n)
            {
                Size = s;
                Name = n;
            }

            //overriden abstract method

            public override int getPrice()
            {

                return getDefPrice(Size) + extra;

            }
        }

    }



}
