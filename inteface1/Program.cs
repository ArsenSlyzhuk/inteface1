using System;

// 1.1. Завдання: Керування автопарком

// Створення інтерфейсу IVehicle
public interface IVehicle
{
    void Start();
    void Stop();
    void Drive();
}

// Реалізація класів для різних видів транспортних засобів
public class Car : IVehicle
{
    public string Model { get; set; }
    public int Year { get; set; }

    public void Start() => Console.WriteLine($"Автомобіль {Model} запущено.");
    public void Stop() => Console.WriteLine($"Автомобіль {Model} зупинено.");
    public void Drive() => Console.WriteLine($"Автомобіль {Model} їде.");
}

public class Motorcycle : IVehicle
{
    public string Model { get; set; }
    public int Year { get; set; }

    public void Start() => Console.WriteLine($"Мотоцикл {Model} запущено.");
    public void Stop() => Console.WriteLine($"Мотоцикл {Model} зупинено.");
    public void Drive() => Console.WriteLine($"Мотоцикл {Model} їде.");
}

public class Truck : IVehicle
{
    public string Model { get; set; }
    public int Year { get; set; }

    public void Start() => Console.WriteLine($"Вантажівка {Model} запущена.");
    public void Stop() => Console.WriteLine($"Вантажівка {Model} зупинена.");
    public void Drive() => Console.WriteLine($"Вантажівка {Model} їде.");
}

// 1.2. Завдання: Менеджер завдань

// Створення інтерфейсу ITask
public interface ITask
{
    void Start();
    void Complete();
    string GetTaskInfo();
}

// Реалізація класів для різних типів завдань
public class WorkTask : ITask
{
    public string Title { get; set; }
    public string Description { get; set; }

    public void Start() => Console.WriteLine($"Розпочато завдання: {Title}");
    public void Complete() => Console.WriteLine($"Завдання {Title} виконано.");
    public string GetTaskInfo() => $"{Title}: {Description}";
}

public class PersonalTask : ITask
{
    public string Title { get; set; }
    public string Description { get; set; }

    public void Start() => Console.WriteLine($"Розпочато особисте завдання: {Title}");
    public void Complete() => Console.WriteLine($"Особисте завдання {Title} виконано.");
    public string GetTaskInfo() => $"{Title}: {Description}";
}

// 2.1. Завдання: Керування бібліотекою книг

// Інтерфейси IPrintable та IBorrowable
public interface IPrintable
{
    void Print();
}

public interface IBorrowable
{
    void BorrowItem();
    void ReturnItem();
    bool IsAvailable();
}

// Реалізація класу Book
public class Book : IPrintable, IBorrowable
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }
    private bool isAvailable = true;

    public void Print() => Console.WriteLine($"{Title} by {Author}, published in {Year}");

    public void BorrowItem()
    {
        if (isAvailable)
        {
            isAvailable = false;
            Console.WriteLine($"{Title} було взято.");
        }
        else
        {
            Console.WriteLine($"{Title} вже взято.");
        }
    }

    public void ReturnItem()
    {
        isAvailable = true;
        Console.WriteLine($"{Title} було повернуто.");
    }

    public bool IsAvailable() => isAvailable;
}

// 2.2. Завдання: Музичний програвач

// Інтерфейси IPlayable та IRecordable
public interface IPlayable
{
    void Play();
    void Pause();
    void Stop();
}

public interface IRecordable
{
    void Record();
}

// Реалізація класу MusicTrack
public class MusicTrack : IPlayable, IRecordable
{
    public string Title { get; set; }
    public string Artist { get; set; }
    public TimeSpan Duration { get; set; }

    public void Play() => Console.WriteLine($"Відтворення треку: {Title} - {Artist}");
    public void Pause() => Console.WriteLine($"Трек {Title} призупинено.");
    public void Stop() => Console.WriteLine($"Відтворення треку {Title} зупинено.");
    public void Record() => Console.WriteLine($"Запис треку: {Title}");
}

// 3. Завдання: Електронний пристрій інтернет-магазину

// Інтерфейси IProduct та IShoppable
public interface IProduct
{
    void DisplayInfo();
}

public interface IShoppable
{
    void AddToCart();
}

// Реалізація базового класу ElectronicDevice
public class ElectronicDevice : IProduct
{
    public string Name { get; set; }
    public string Manufacturer { get; set; }
    public decimal Price { get; set; }

    public void DisplayInfo()
    {
        Console.WriteLine($"Назва: {Name}, Виробник: {Manufacturer}, Ціна: {Price:C}");
    }
}

// Реалізація класів Smartphone та Laptop
public class Smartphone : ElectronicDevice, IShoppable
{
    public string OS { get; set; }

    public void AddToCart() => Console.WriteLine($"Смартфон {Name} додано до кошика.");
}

public class Laptop : ElectronicDevice, IShoppable
{
    public string Processor { get; set; }

    public void AddToCart() => Console.WriteLine($"Ноутбук {Name} додано до кошика.");
}

// Тестування всіх реалізацій
class Program
{
    static void Main()
    {
        // Тестування автопарку
        Console.WriteLine("Тестування автопарку:");
        IVehicle car = new Car { Model = "Toyota Camry", Year = 2021 };
        IVehicle motorcycle = new Motorcycle { Model = "Honda CBR600RR", Year = 2020 };
        IVehicle truck = new Truck { Model = "Volvo FH", Year = 2019 };

        car.Start();
        car.Drive();
        car.Stop();

        motorcycle.Start();
        motorcycle.Drive();
        motorcycle.Stop();

        truck.Start();
        truck.Drive();
        truck.Stop();

        Console.WriteLine();

        // Тестування менеджера завдань
        Console.WriteLine("Тестування менеджера завдань:");
        ITask workTask = new WorkTask { Title = "Завершити звіт", Description = "Завершити фінансовий звіт за місяць." };
        ITask personalTask = new PersonalTask { Title = "Купити продукти", Description = "Купити продукти на тиждень." };

        workTask.Start();
        Console.WriteLine(workTask.GetTaskInfo());
        workTask.Complete();

        personalTask.Start();
        Console.WriteLine(personalTask.GetTaskInfo());
        personalTask.Complete();

        Console.WriteLine();

        // Тестування бібліотеки книг
        Console.WriteLine("Тестування бібліотеки книг:");
        Book book1 = new Book { Title = "1984", Author = "George Orwell", Year = 1949 };
        book1.Print();

        Console.WriteLine($"Доступність: {book1.IsAvailable()}");
        book1.BorrowItem();
        Console.WriteLine($"Доступність: {book1.IsAvailable()}");
        book1.ReturnItem();
        Console.WriteLine($"Доступність: {book1.IsAvailable()}");

        Console.WriteLine();

        // Тестування музичного програвача
        Console.WriteLine("Тестування музичного програвача:");
        MusicTrack track = new MusicTrack
        {
            Title = "Imagine",
            Artist = "John Lennon",
            Duration = TimeSpan.FromMinutes(3.1)
        };

        track.Play();
        track.Pause();
        track.Stop();
        track.Record();

        Console.WriteLine();

        // Тестування електронних пристроїв
        Console.WriteLine("Тестування електронних пристроїв:");
        Smartphone smartphone = new Smartphone { Name = "iPhone 13", Manufacturer = "Apple", Price = 999.99M, OS = "iOS" };
        Laptop laptop = new Laptop { Name = "Dell XPS 13", Manufacturer = "Dell", Price = 1299.99M, Processor = "Intel i7" };

        smartphone.DisplayInfo();
        smartphone.AddToCart();

        laptop.DisplayInfo();
        laptop.AddToCart();
    }
}