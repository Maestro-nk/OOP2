using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using FileOperations;

namespace ConsoleApp
{
    public class ConsoleMenu
    {
        private readonly IFileService _fileService;
        private readonly string _filePath = "data.txt";

        public ConsoleMenu(IFileService fileService)
        {
            _fileService = fileService;
        }

        public void ShowMenu()
        {

            while (true)
            {
                Console.WriteLine("\n=== Main Menu ===");
                Console.WriteLine("1. Add student");
                Console.WriteLine("2. Add painter");
                Console.WriteLine("3. Add farmer");
                Console.WriteLine("4. Show all persons");
                Console.WriteLine("5. Find 2nd course students born in winter");
                Console.WriteLine("6. Clear file");
                Console.WriteLine("0. Exit");
                Console.Write("Select option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddStudent();
                        break;
                    case "2":
                        AddPainter();
                        break;
                    case "3":
                        AddFarmer();
                        break;
                    case "4":
                        ShowAllPersons();
                        break;
                    case "5":
                        FindWinterBornStudents();
                        break;
                    case "6":
                        ClearData();
                        break;
                    case "0":
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice! Try again.");
                        break;
                }
            }
        }

        private void AddStudent()
        {
            try
            {
                Console.WriteLine("\n--- Adding Student ---");

                Student student = new Student();

                Console.Write("Enter first name: ");
                student.FirstName = Console.ReadLine();

                Console.Write("Enter last name: ");
                student.LastName = Console.ReadLine();

                Console.Write("Enter student ID (format: XXXX): ");
                student.StudentId = Console.ReadLine();

                Console.Write("Enter course (1-4): ");
                string courseInput = Console.ReadLine();
                if (int.TryParse(courseInput, out int course))
                {
                    student.Course = course;
                }
                else
                {
                    Console.WriteLine("Error: course must be a number!");
                    return;
                }

                Console.Write("Enter birth date (format: YYYY MM DD): ");
                student.BirthDate = Console.ReadLine();

                _fileService.WriteToFile(_filePath, student);
                Console.WriteLine(" Student added successfully and saved to file!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Error: {ex.Message}");
            }
        }

        private void AddPainter()
        {
            try
            {
                Console.WriteLine("\n--- Adding Painter ---");

                Painter painter = new Painter();

                Console.Write("Enter first name: ");
                painter.FirstName = Console.ReadLine();

                Console.Write("Enter last name: ");
                painter.LastName = Console.ReadLine();

                _fileService.WriteToFile(_filePath, painter);
                Console.WriteLine(" Painter added successfully and saved to file!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Error: {ex.Message}");
            }
        }

        private void AddFarmer()
        {
            try
            {
                Console.WriteLine("\n--- Adding Farmer ---");

                Farmer farmer = new Farmer();

                Console.Write("Enter first name: ");
                farmer.FirstName = Console.ReadLine();

                Console.Write("Enter last name: ");
                farmer.LastName = Console.ReadLine();

                _fileService.WriteToFile(_filePath, farmer);
                Console.WriteLine(" Farmer added successfully and saved to file!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Error: {ex.Message}");
            }
        }

        private void ShowAllPersons()
        {
            try
            {
                Console.WriteLine("\n--- All records from file ---");

                List<Person> persons = _fileService.ReadFromFile(_filePath);

                if (persons.Count == 0)
                {
                    Console.WriteLine("File is empty.");
                    return;
                }

                Console.WriteLine($"Records found: {persons.Count}");
                Console.WriteLine("----------------------------");

                foreach (var person in persons)
                {
                    person.DisplayInfo();
                    person.PerformAction();
                    Console.WriteLine("----------------------------");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Error: {ex.Message}");
            }
        }

        private void FindWinterBornStudents()
        {
            try
            {
                Console.WriteLine("\n--- Finding 2nd course students born in winter ---");

                List<Person> persons = _fileService.ReadFromFile(_filePath);

                var winterStudents = persons.OfType<Student>()
                                          .Where(s => s.Course == 2 && s.IsBornInWinter())
                                          .ToList();

                if (winterStudents.Count == 0)
                {
                    Console.WriteLine("No students found.");
                    return;
                }

                Console.WriteLine($"Found students: {winterStudents.Count}");
                Console.WriteLine("----------------------------");

                foreach (var student in winterStudents)
                {
                    student.DisplayInfo();
                    Console.WriteLine("----------------------------");
                }

                Console.WriteLine($"Total: {winterStudents.Count} 2nd course student(s) born in winter");
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Error: {ex.Message}");
            }
        }

        private void ClearData()
        {
            try
            {
                Console.Write("Are you sure you want to clear the file? (y/n): ");
                string confirmation = Console.ReadLine();

                if (confirmation.ToLower() == "y")
                {
                    _fileService.ClearFile(_filePath);
                    Console.WriteLine(" File cleared successfully!");
                }
                else
                {
                    Console.WriteLine("Clearing cancelled.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Error: {ex.Message}");
            }
        }
    }
}