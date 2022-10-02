using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03
{
    class Chicken
    {
        private void ChickenResult(string name,int age) {
            Console.WriteLine("Chicken {0} (age {1}) can produce 1 eggs per day.",name,age);
        }
        public void ChickenInput(string name,int age)
        {
            if(name == null)
            {
                Console.WriteLine("Name cannot be empty.");
            }else if (age < 0 | age > 15)
            {
                Console.WriteLine("Age should be between 0 and 15.");
            }
            else
            {
                ChickenResult(name, age);
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string name=Console.ReadLine();
            int age=int.Parse(Console.ReadLine());
            Chicken chicken=new Chicken();
            chicken.ChickenInput(name, age);
        }
    }
}
