using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VA
{
    public class Vector
    {
        public string LineColor { get; set; }
        public double Angle { get; set; }
        private double _Length { get; set; }
        public double Length
        {
            get { return _Length; }
            set
            {
                if (value < 0)
                {
                    _Length = 0;
                    Console.WriteLine("Length can`t be < 0");
                }
                else { _Length = value; }
            }
        }
        public Vector(string color, double angle, double length)
        {
            LineColor = color;
            Angle = angle;
            Length = length;
        }
        public void Decrease(int times) {
            if (times > 0) { 
            Length = Length / times; }
            else { Console.WriteLine("Can`t be reduced by {times} times"); }
        }
        public void DisplayInfo()
        {
            Console.WriteLine($"Colour: {LineColor}");
            Console.WriteLine($"Angle: {Angle}°");
            Console.WriteLine($"Length: {Length}");
        }
        public override string ToString()
        {
            return $"Vector (Colour: {LineColor}, Angle: {Angle}°, Length: {Length})";
        }

        public void Increase (int times) { Length = Length * times; }
    }
}
