using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Створення словника для зберігання об'єктів Airplane
        Dictionary<string, Airplane> flights = new Dictionary<string, Airplane>();

        // Додавання даних у словник
        Airplane flight1 = new Airplane
        {
            DepartureCity = "Київ",
            ArrivalCity = "Лондон",
            DepartureDate = new Date(2024, 12, 18, 10, 30),
            ArrivalDate = new Date(2024, 12, 18, 14, 50),
            DistanceKm = 2400
        };

        Airplane flight2 = new Airplane
        {
            DepartureCity = "Париж",
            ArrivalCity = "Берлін",
            DepartureDate = new Date(2024, 12, 20, 8, 00),
            ArrivalDate = new Date(2024, 12, 20, 9, 30),
            DistanceKm = 1050
        };

        if (!flights.ContainsKey("KY-LON")) flights.Add("KY-LON", flight1);
        if (!flights.ContainsKey("PAR-BER")) flights.Add("PAR-BER", flight2);

        // Виведення всіх рейсів
        Console.WriteLine("Список усіх рейсів:");
        foreach (var flight in flights)
        {
            Console.WriteLine($"\nКлюч: {flight.Key}");
            flight.Value.PrintAirplane();
        }

        // Пошук рейсу за ключем
        Console.Write("\nВведіть ключ рейсу для отримання інформації (наприклад, KY-LON): ");
        string searchKey = Console.ReadLine();

        if (flights.ContainsKey(searchKey))
        {
            Console.WriteLine($"\nІнформація про рейс {searchKey}:");
            flights[searchKey].PrintAirplane();
        }
        else
        {
            Console.WriteLine("Рейс із таким ключем не знайдено.");
        }
    }
}

class Airplane
{
    public string DepartureCity { get; set; }
    public string ArrivalCity { get; set; }
    public Date DepartureDate { get; set; }
    public Date ArrivalDate { get; set; }
    public double DistanceKm { get; set; }

    public void PrintAirplane()
    {
        Console.WriteLine($"Відправлення: {DepartureCity} ({DepartureDate})");
        Console.WriteLine($"Прибуття: {ArrivalCity} ({ArrivalDate})");
        Console.WriteLine($"Дальність польоту: {DistanceKm} км.");
    }
}

class Date
{
    public int Year { get; set; }
    public int Month { get; set; }
    public int Day { get; set; }
    public int Hours { get; set; }
    public int Minutes { get; set; }

    public Date(int year, int month, int day, int hours, int minutes)
    {
        Year = year;
        Month = month;
        Day = day;
        Hours = hours;
        Minutes = minutes;
    }

    public override string ToString()
    {
        return $"{Day:D2}/{Month:D2}/{Year} {Hours:D2}:{Minutes:D2}";
    }
}
