using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01
{
    class Box
    {
        private bool BoxCheck(double a,double b,double c)
        {
            if (a <= 0)
            {
                return false;
            }else if (b <= 0)
            {
                return false;
            }else if (c <= 0) 
            { 
                return false; 
            }else
            {
                return true;
            }
        }
         private void BoxSurfaceArea(double l,double w,double h)
        {
            Console.WriteLine("Volume - "+(2*l*w+2*l*h+2*h*w));
        }
        private void BoxLateralArea(double l, double w, double h)
        {
            Console.WriteLine("Volume - " + (2 * l * h + 2 * h * w));
        }
        private void BoxVolume(double l,double w,double h)
        {
            Console.WriteLine("Volume - "+l*w*h);
        }
        public void BoxInput(double l,double w,double h)
        {
            if(BoxCheck(l, w, h))
            {
                BoxSurfaceArea(l,w,h);
                BoxLateralArea(l,w,h);
                BoxVolume(l,w,h);
            }
            else
            {
                Console.WriteLine("Width cannot be zero or negative.");
            };
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            double l=double.Parse(Console.ReadLine());
            double w=double.Parse(Console.ReadLine());
            double h=double.Parse(Console.ReadLine());
            Box box = new Box();
            box.BoxInput(l, w, h);
        }
    }
}
