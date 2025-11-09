using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Domain;

namespace FileOperations
{
    public class FileService : IFileService
    {
        public void WriteToFile(string filePath, Person person)
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                if (person is Student student)
                {
                    WriteStudentToFile(writer, student);
                }
                else if (person is Painter painter)
                {
                    WritePainterToFile(writer, painter);
                }
                else if (person is Farmer farmer)
                {
                    WriteFarmerToFile(writer, farmer);
                }

                writer.WriteLine();
            }
        }

        public List<Person> ReadFromFile(string filePath)
        {
            List<Person> persons = new List<Person>();

            if (!File.Exists(filePath))
            {
                return persons;
            }

            try
            {
                string[] lines = File.ReadAllLines(filePath);
                Person currentPerson = null;
                bool inObject = false;

                for (int i = 0; i < lines.Length; i++)
                {
                    string line = lines[i].Trim();

                    if (string.IsNullOrEmpty(line))
                        continue;

                    if (line.StartsWith("Student") && !inObject)
                    {
                        currentPerson = new Student();
                        inObject = true;
                    }
                    else if (line.StartsWith("Painter") && !inObject)
                    {
                        currentPerson = new Painter();
                        inObject = true;
                    }
                    else if (line.StartsWith("Farmer") && !inObject)
                    {
                        currentPerson = new Farmer();
                        inObject = true;
                    }
                    else if (line == "{" && inObject)
                    {
                        continue;
                    }
                    else if (line == "};" && inObject)
                    {
                        if (currentPerson != null)
                        {
                            persons.Add(currentPerson);
                            currentPerson = null;
                        }
                        inObject = false;
                    }
                    else if (inObject && currentPerson != null)
                    {
                        ParseAttribute(line, ref currentPerson);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"File reading error: {ex.Message}");
            }

            return persons;
        }

        public void ClearFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.WriteAllText(filePath, string.Empty);
            }
        }

        private void WriteStudentToFile(StreamWriter writer, Student student)
        {
            writer.WriteLine($"Student {student.FirstName}{student.LastName}");
            writer.WriteLine("{");
            writer.WriteLine($"  \"firstname\": \"{student.FirstName}\",");
            writer.WriteLine($"  \"lastname\": \"{student.LastName}\",");
            writer.WriteLine($"  \"studentId\": \"{student.StudentId}\",");
            writer.WriteLine($"  \"course\": \"{student.Course}\",");
            writer.WriteLine($"  \"birthdate\": \"{student.BirthDate}\"");
            writer.WriteLine("};");
        }

        private void WritePainterToFile(StreamWriter writer, Painter painter)
        {
            writer.WriteLine($"Painter {painter.FirstName}{painter.LastName}");
            writer.WriteLine("{");
            writer.WriteLine($"  \"firstname\": \"{painter.FirstName}\",");
            writer.WriteLine($"  \"lastname\": \"{painter.LastName}\"");
            writer.WriteLine("};");
        }

        private void WriteFarmerToFile(StreamWriter writer, Farmer farmer)
        {
            writer.WriteLine($"Farmer {farmer.FirstName}{farmer.LastName}");
            writer.WriteLine("{");
            writer.WriteLine($"  \"firstname\": \"{farmer.FirstName}\",");
            writer.WriteLine($"  \"lastname\": \"{farmer.LastName}\"");
            writer.WriteLine("};");
        }

        private void ParseAttribute(string line, ref Person person)
        {
            Match match = Regex.Match(line, @"^\s*""([^""]+)"":\s*""([^""]*)""");

            if (match.Success)
            {
                string attribute = match.Groups[1].Value;
                string value = match.Groups[2].Value;

                switch (attribute)
                {
                    case "firstname":
                        person.FirstName = value;
                        break;
                    case "lastname":
                        person.LastName = value;
                        break;
                    case "studentId":
                        if (person is Student student)
                            student.StudentId = value;
                        break;
                    case "course":
                        if (person is Student studentCourse && int.TryParse(value, out int course))
                            studentCourse.Course = course;
                        break;
                    case "birthdate":
                        if (person is Student studentBirth)
                            studentBirth.BirthDate = value;
                        break;
                }
            }
        }
    }
}