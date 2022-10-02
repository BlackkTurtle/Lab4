using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05
{
    class PizzaCalories
    {
        private string name="";
        private double totalcalories=0;
        private Dough dough=new Dough();
        private Topics topics=new Topics();
        private bool doughtypecheck=false;
        private int doughweight;
        private string[] topicscheck=new string[0];
        private string[] topicscheckweight=new string[0];
        private int numberoftopics = 0;
        private class Dough
        {
            public string[] flourtype=new string[2] {"White","Wholegrain"};
            public double[] flourtypecal=new double[2] {1.5,1};
            public string[] bakingtechnique=new string[3] {"Crispy","Chewy","Homemade"};
            public double[] bakingtechniquecal=new double[3] {0.9,1.1,1};
        }
        private class Topics
        {
            public string[] topicsname = new string[4] { "Meat", "Veggies", "Cheese", "Sauce" };
            public double[] topicscalories = new double[4] { 1.2, 0.8, 1.1, 0.9 };
        }
        public void PizzaCreate(string strarray)
        {
            string[] array1=strarray.Split(' ');
            name=array1[1];
        }
        public void DoughCreate(string strarray)
        {
            string[] array1 = strarray.Split(' ');
            int a=-1,b=-1;
            doughweight=Convert.ToInt32(array1[3]);
            for (int i = 0; i < 2; i++)
            {
                if (array1[1] == dough.flourtype[i])
                {
                    a=i;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                if (array1[2] == dough.bakingtechnique[i])
                {
                    b=i;
                }
            }
            if (a == -1|b==-1)
            {
                doughtypecheck = true;
            }
            else
            {
                totalcalories+= doughweight * 2 * dough.flourtypecal[a] * dough.bakingtechniquecal[b];
            }
        }
        public void TopicsCreate(string strarray)
        {
            string[] array1 = strarray.Split(' ');
            int a = -1;
            int b= Convert.ToInt32(array1[2]);
            numberoftopics++;
            for (int i = 0; i < 4; i++)
            {
                if (array1[1] == topics.topicsname[i])
                {
                    a = i;
                }
            }
            if (a == -1)
            {
                topicscheck = topicscheck.Append(array1[1]).ToArray();
            }
            else if (b > 50 | b < 1)
            {
                topicscheckweight = topicscheckweight.Append(array1[1]).ToArray();
            }
            else
            {
                totalcalories += b * 2 * topics.topicscalories[a];
            }
        }
        public void Finish()
        {
            int result = 0;
            if (doughtypecheck)
            {
                Console.WriteLine("Invalid Type of Dough");
                result=1;
            }
            if (doughweight > 200 | doughweight < 1)
            {
                result=1;
                Console.WriteLine("Dough weight should be in the range [1..200].");
            }
            if (topicscheck.Length > 0)
            {
                result= 1;
                for(int i = 0; i < topicscheck.Length; i++)
                {
                    Console.WriteLine("Cannot place "+topicscheck[i]+" on top of your pizza");
                }
            }
            if (topicscheckweight.Length > 0)
            {
                result = 1;
                for (int i = 0; i < topicscheckweight.Length; i++)
                {
                    Console.WriteLine(topicscheckweight[i] + " weight should be in the range [1..50].");
                }
            }
            if (name.Length > 15 | name.Length < 1)
            {
                Console.WriteLine("Pizza name should be between 1 and 15 symbols.");
                result = 1;
            }
            if (numberoftopics > 10 | numberoftopics < 0)
            {
                result = 1;
                Console.WriteLine("Number of toppings should be in range \r\n[0..10].\r\n");
            }
            if (result == 0)
            {
                Console.WriteLine("{0} - {1} Calories",name,totalcalories);
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string strarray = Console.ReadLine();
            PizzaCalories pizzacalories = new PizzaCalories();
            pizzacalories.PizzaCreate(strarray);
            string strarray1 = Console.ReadLine();
            pizzacalories.DoughCreate(strarray1);
            while (true)
            {
                string str = Console.ReadLine();
                if (str == "END")
                {
                    pizzacalories.Finish();
                    break;
                }
                else
                {
                    pizzacalories.TopicsCreate(str);
                }
            }
        }
    }
}
