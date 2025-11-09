using System;

namespace Domain
{
    public class Painter : Person
    {
        public override void PerformAction()
        {
            Paint();
        }

        public void Paint()
        {
            Console.WriteLine($"Painter {FirstName} {LastName} is painting");
        }

        public void Swim()
        {
            Console.WriteLine($"Painter {FirstName} {LastName} is swimming");
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine("Profession: Painter");
        }
    }
}