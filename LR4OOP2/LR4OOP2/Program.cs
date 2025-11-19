using System;

class Program
{
    public delegate bool[] ArrayComparer(int[] arr1, int[] arr2);

    static void Main(string[] args)
    {
        Console.WriteLine("--- Task 1: Delegate and Lambda ---");

        ArrayComparer comparer = (arr1, arr2) =>
        {
            // Перевірка, щоб уникнути помилок
            if (arr1.Length != arr2.Length)
            {
                Console.WriteLine("Arrays have different lengths!");
                return new bool[0]; // Повертаємо порожній масив
            }

            bool[] results = new bool[arr1.Length];
            for (int i = 0; i < arr1.Length; i++)
            {
                // Порівнюємо відповідні значення
                results[i] = (arr1[i] == arr2[i]);
            }
            return results;
        };

        int[] arrayA = { 1, 5, 10, 20 };
        int[] arrayB = { 1, 5, 12, 20 };

        bool[] comparisonResults = comparer(arrayA, arrayB);

        Console.WriteLine("Comparison results:");
        for (int i = 0; i < comparisonResults.Length; i++)
        {
            Console.WriteLine($"Index {i} ({arrayA[i]} == {arrayB[i]}): {comparisonResults[i]}");
        }

        Console.WriteLine("\n--- Task 2 & 3: Events ---");

        // --- Завдання 3: Використання компонента та обробка події ---

        InternetService service = new InternetService(100);

        service.TrafficExceeded += Service_TrafficExceeded;

        // 3. Імітуємо використання
        service.UseInternet(40); // Все ок
        service.UseInternet(50); // Все ок (Всього 90)

        // Цей виклик має спричинити подію
        service.UseInternet(30); // Перевищення! (Всього 120)

        service.UseInternet(20); // Ще використання (Всього 140)
    }

    // --- Завдання 3: Метод-обробник події ---

    private static void Service_TrafficExceeded(object sender, EventArgs e)
    {
        // 'sender' - це об'єкт, який відправив подію (тобто наш 'service')
        // 'e' - це аргументи події (зараз вони порожні)

        Console.WriteLine("!!! EVENT HANDLER TRIGGERED !!!");
        Console.WriteLine("Notification: Traffic limit has been exceeded.");

        // Ми можемо отримати інформацію про ініціатора події
        if (sender is InternetService)
        {
            InternetService service = (InternetService)sender;
            Console.WriteLine($"Event source details: Limit={service.TrafficLimit}, Current={service.CurrentTraffic}");
        }
    }
}