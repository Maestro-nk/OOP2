using System;

namespace Domain
{
    public abstract class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public abstract void PerformAction();
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Name:{FirstName}, LastName:{LastName}");
        }
    }
}
