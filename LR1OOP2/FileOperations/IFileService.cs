using System;
using System.Collections.Generic;
using Domain;

namespace FileOperations
{
    public interface IFileService
    {
        void WriteToFile(string filePath, Person person);
        List<Person> ReadFromFile(string filePath);
        void ClearFile(string filePath);
    }
}