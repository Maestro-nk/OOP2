using System;
using System.Text.RegularExpressions;

namespace Domain
{
    public class Student : Person
    {
        private string _studentId;
        private int _course;
        private string _birthDate;
        public string StudentId
        {
            get { return _studentId; }
            set { if (!Regex.IsMatch(value, @"\d{4}$"))
                    throw new ArgumentException("Must be XXXX");
                _studentId = value;
            }
        }
        public int Course
        {
            get { return _course; }
            set
            {
                if (value < 1 || value > 4)
                    throw new ArgumentException("Course 1-4");
                _course = value;
            }
        }
        public string BirthDate
        {
            get { return _birthDate; }
            set
            {
                if (!Regex.IsMatch(value, @"^\d{4} (0[1-9]|1[0-2]) (0[1-9]|[12][0-9]|3[01])$"))
                    throw new ArgumentException("Must be YYYY MM DD");
                _birthDate = value;
            }
        }
        public override void PerformAction()
        {
            Study();
        }
        public void Study()
        {
            Console.WriteLine($"Student {FirstName} {LastName} is studing on {Course} course");
        }
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"ID: {StudentId}, Course: {Course}, BD: {BirthDate}");
        }
        public bool IsBornInWinter()
        {
            if (string.IsNullOrEmpty(BirthDate))
                return false;

            string[] parts = BirthDate.Split(' ');
            if (parts.Length >= 2)
            {
                string month = parts[1];
                return month == "12" || month == "01" || month == "02";
            }
            return false;
        }
    }

}