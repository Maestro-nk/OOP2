using System;

public class InternetService
{
    // Властивості для відстеження трафіку
    public int TrafficLimit { get; private set; }
    public int CurrentTraffic { get; private set; }

    public event EventHandler TrafficExceeded;

    // Конструктор
    public InternetService(int trafficLimit)
    {
        TrafficLimit = trafficLimit;
        CurrentTraffic = 0;
    }

    public void UseInternet(int trafficUsed)
    {
        Console.WriteLine($"Trying to use {trafficUsed} MB of traffic...");

        if (CurrentTraffic + trafficUsed > TrafficLimit && CurrentTraffic < TrafficLimit)
        {
            // Якщо трафік буде перевищено ЦІЄЮ операцією
            CurrentTraffic += trafficUsed;
            Console.WriteLine($"Traffic limit of {TrafficLimit} MB exceeded!");

            // Викликаємо подію, щоб сповістити всіх підписників
            OnTrafficExceeded();
        }
        else
        {
            CurrentTraffic += trafficUsed;
            Console.WriteLine($"Current total traffic: {CurrentTraffic} / {TrafficLimit} MB");
        }
    }

    // Захищений віртуальний метод для виклику події
    // (Це стандартна практика в C#)
    protected virtual void OnTrafficExceeded()
    {
        // Перевіряємо, чи є хтось, хто підписався на подію
        if (TrafficExceeded != null)
        {
            // Викликаємо подію. 
            // 'this' - це об'єкт, що ініціював подію.
            // 'EventArgs.Empty' - бо ми не передаємо додаткових даних.
            TrafficExceeded(this, EventArgs.Empty);
        }
    }
}