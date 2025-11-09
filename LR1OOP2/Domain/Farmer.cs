using System;

namespace Domain
{
    public class Farmer : Person
    {
        public override void PerformAction()
        {
            Farm(); 
        }
        public void Farm()
        {
            Console.WriteLine($"Farmer {FirstName} {LastName} is working on the farm");
        }
        public void Swim()
        {
            Console.WriteLine($"Farmer {FirstName} {LastName} is swimming");
        }
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine("Profession: Farmer");
        }
    }
}