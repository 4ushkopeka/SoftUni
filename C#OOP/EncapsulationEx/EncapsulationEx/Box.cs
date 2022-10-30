using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncapsulationEx
{
    public class Box
    {
        public double Length 
        {
            get {return length; }
            private set 
            {
                try
                {
                    if (value <= 0) throw new ArgumentException();
                    else length = value;
                }
                catch (Exception)
                {
                    Console.WriteLine($"Length cannot be zero or negative.");
                    System.Environment.Exit(1);
                }
            } 
        }
        public double Width 
        {
            get { return width; }
            private set
            {
                try
                {
                    if (value <= 0) throw new ArgumentException();
                    else width = value;
                }
                catch (Exception)
                {
                    Console.WriteLine($"Width cannot be zero or negative.");
                    System.Environment.Exit(1);
                }
            }
        }
        public double Height 
        {
            get { return height; }
            private set
            {
                try
                {
                    if (value <= 0) throw new ArgumentException();
                    else height = value;
                }
                catch (Exception)
                {
                    Console.WriteLine($"Height cannot be zero or negative.");
                    System.Environment.Exit(1);
                }
            }
        }
        private double height;
        private double width;
        private double length;
        public Box(double leg, double wid, double hei)
        {
            
                Length = leg;
                Width = wid;
                Height = hei;
        }
        public double SurfaceArea()
        {
            return 2*(Length*Height + Length*Width + Height*Width);
        }
        public double LateralSurfaceArea()
        {
            return 2*Height*(Width+Length);
        }
        public double Volume()
        {
            return Length * Height * Width;
        }
    }
}
