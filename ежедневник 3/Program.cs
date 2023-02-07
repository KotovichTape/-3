using System.Reflection;
using Ежедневник;

//типданных название = значение

//типданных название = new типданных
Note zametka = new Note();
zametka.Name = "Сходить в мпт";
zametka.Description = "проснуться в 6:00, одеться и поехать в мпт";
zametka.Date = new DateTime(2023, 1, 9);

Note zametka1 = new Note();
zametka1.Name = "Сходить в больницу";
zametka1.Description = "проснуться в 10:00, одеться и поехать в больницу";
zametka1.Date = new DateTime(2023, 1, 10);

Note zametka2 = new Note();
zametka2.Name = "Сходить в кино";
zametka2.Description = "Покушать в 18:00, одеться и поехать в кино";
zametka2.Date = new DateTime(2023, 1, 11);

Note zametka3 = new Note();
zametka3.Name = "Приготовить покушать";
zametka3.Description = "Взять продукты и приготовить еду";
zametka3.Date = new DateTime(2023, 1, 9);

Note zametka4 = new Note();
zametka4.Name = "Помыться";
zametka4.Description = "Включить свет и помыться в ванной";
zametka4.Date = new DateTime(2023, 1, 9);

Note zametka5 = new Note();
zametka5.Name = "Выучить C#";
zametka5.Description = "Сесть за комп, открыть видео урок и выучить C#";
zametka5.Date = new DateTime(2023, 1, 12);

Note zametka6 = new Note();
zametka6.Name = "Позвонить Глебу";
zametka6.Description = "Зайти в телефонную книжку и набрать Глебу";
zametka6.Date = new DateTime(2023, 1, 13);

List<Note> allNotes = new List<Note>();

//TODO заметки должны браться из отдельного файла, чтобы добавленные в ходе программы сохранялись

allNotes.Add(zametka);
allNotes.Add(zametka1);
allNotes.Add(zametka2);
allNotes.Add(zametka3);
allNotes.Add(zametka4);
allNotes.Add(zametka5);
allNotes.Add(zametka6);

int position = 1;

DateTime currentDate = DateTime.Today;

while (true)
{
    Console.WriteLine($"Выбрана дата ({currentDate}) (для добавления новой записи нажмите alt+A - add)");

    int index = 1;

    List<Note> currentDateNotes = new List<Note>();

    foreach (var item in allNotes.Select((value, i) => new { i, value }))
    {

        if (currentDate.Date == item.value.Date)
        {
            currentDateNotes.Add(item.value);

            Console.WriteLine($"  {index}. {item.value.Name}");
            index++;
        }
    }

    if (currentDateNotes.Any())
    {
        Console.SetCursorPosition(0, position);
        Console.WriteLine("->");
    }

    ConsoleKeyInfo InputKey = Console.ReadKey();

    if (InputKey.Key == ConsoleKey.UpArrow && currentDateNotes.Any())
    {
        if (position != 1)
        {
            position--;
        }
    }
    else if (InputKey.Key == ConsoleKey.DownArrow && currentDateNotes.Any())
    {
        if (position != currentDateNotes.Count)
        {
            position++;
        }

    }
    else if (InputKey.Key == ConsoleKey.LeftArrow)
    {
        currentDate = currentDate.AddDays(-1);

        position = 1;
    }
    else if (InputKey.Key == ConsoleKey.RightArrow)
    {
        currentDate = currentDate.AddDays(1);

        position = 1;
    }
    else if (InputKey.Key == ConsoleKey.A && InputKey.Modifiers.HasFlag(ConsoleModifiers.Alt))
    {
        string taskName;
        string taskDescription;
        DateTime taskDate;

        Console.Clear();

        Console.WriteLine("Введите название задачи");

        taskName = Console.ReadLine();

        Console.WriteLine("Введите описание задачи");

        taskDescription = Console.ReadLine();

        Console.WriteLine("Введите дату задачи");

        taskDate = DateTime.Parse(Console.ReadLine());
        // TODO проверить корректность даты
        // или обработать исключение

        Note task = new Note();

        task.Name = taskName;
        task.Description = taskDescription;
        task.Date = taskDate;

        allNotes.Add(task);

        Console.WriteLine($"{task.Name}");
        Console.WriteLine("--------------------------------");
        Console.WriteLine($"описание: {task.Description}");
        Console.WriteLine($"дата: {task.Date}");

        Console.ReadKey();
    }
    else if (InputKey.Key == ConsoleKey.Enter && currentDateNotes.Any())
    {
        Console.Clear();
        Console.WriteLine($"{currentDateNotes[position - 1].Name}");
        Console.WriteLine("--------------------------------");
        Console.WriteLine($"Описание: {currentDateNotes[position - 1].Description}");
        Console.WriteLine($"Дата: {currentDateNotes[position - 1].Date}");
        Console.ReadKey();
        // TODO
        // обработка нажатия на ESC, а не на любую клавишу
    }
    else if (InputKey.Key == ConsoleKey.Escape)
    {
        return;
    }

    Console.Clear();
}