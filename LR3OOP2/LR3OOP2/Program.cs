using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics.Tracing;
using System.Text.Json;

#pragma warning disable SYSLIB0011

namespace LR3OOP2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Vector> vectorsToSave = new List<Vector>{
             new Vector("Red", 45, 10),
             new Vector("Blue", 90, 5),
             new Vector("Green", 0, 15),
             new Vector("Black", 180, 8),
             new Vector("Yellow", 270, 12)
             };

         BinaryFormatter formatter = new BinaryFormatter();

         using (FileStream fs = new FileStream("Vector.bin", FileMode.Create))
         {
            formatter.Serialize(fs, vectorsToSave);
         }
            Console.WriteLine("Saved to Vector.bin");

            List<Vector> loadedVectors = null;
            BinaryFormatter loadFormatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("Vector.bin", FileMode.Open))
            {
                object loadedData = loadFormatter.Deserialize(fs);
                loadedVectors = loadedData as List<Vector>;
            }
            if (loadedVectors != null)
            {
                Console.WriteLine("\nDownloaded from Vector.bin:");
                foreach (var vector in loadedVectors)
                {
                    vector.DisplayInfo();
                }
            }
            else
            {
                Console.WriteLine("\nDownload error");
            }

            XmlSerializer xmlFormatter = new XmlSerializer(typeof(List<Vector>));

            using (FileStream fs = new FileStream("Vectors.xml", FileMode.Create))
            {
                xmlFormatter.Serialize(fs, vectorsToSave);
            }
            Console.WriteLine("\nSaved to Vectors.xml");

            List<Vector> loadedXmlVectors = null;

            XmlSerializer xmlLoader = new XmlSerializer(typeof(List<Vector>));

            using (FileStream fs = new FileStream("Vectors.xml", FileMode.Open))
            {
                loadedXmlVectors = (List<Vector>)xmlLoader.Deserialize(fs);
            }

            if (loadedXmlVectors != null)
            {
                Console.WriteLine("\nLoaded from Vectors.xml:");
                foreach (var vector in loadedXmlVectors)
                {
                    vector.DisplayInfo(); 
                    Console.WriteLine("---");
                }
            }
            else
            {
                Console.WriteLine("\nCan`t load from XML.");
            }
            Console.WriteLine("\nStarting JSON serialization...");

            var jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            using (FileStream fs = new FileStream("vectors.json", FileMode.Create))
            {
                JsonSerializer.Serialize(fs, vectorsToSave, jsonOptions);
            }

            Console.WriteLine("Objects saved to vectors.json");

            List<Vector> loadedJsonVectors = null;

            using (FileStream fs = new FileStream("vectors.json", FileMode.Open))
            {
                loadedJsonVectors = JsonSerializer.Deserialize<List<Vector>>(fs);
            }

            if (loadedJsonVectors != null)
            {
                Console.WriteLine("\nSuccessfully loaded from vectors.json:");
                foreach (var vector in loadedJsonVectors)
                {
                    vector.DisplayInfo();
                    Console.WriteLine("---");
                }
            }
            else
            {
                Console.WriteLine("\nFailed to load data from JSON.");
            }
        }
    }
}   