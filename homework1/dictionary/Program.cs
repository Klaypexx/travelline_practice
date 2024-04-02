using System.Collections.Generic;

internal class Programm
{
    private static Dictionary<string, string> Dictionary { get; set; } = new();
    public static int Main()
    {
        while (true)
        {
            MenuText();

            string option = Console.ReadLine().Trim();
            if (option == "0") break;
            bool emptyDictonaryCondition = Dictionary.Count == 0 && (option == "2" || option == "3" || option == "4" || option == "6");

            if (emptyDictonaryCondition)
            {
                Console.WriteLine("Словарь пуст");
                Console.ReadLine();
                continue;
            }

            switchOption(option);

        }

        return 1;
    }

    public static void switchOption(string option) 
    {
            switch (option)
            {
                case "1":
                    AddTranslation();
                    break;
                case "2":
                    RemoveTranslation();
                    break;
                case "3":
                    ChangeTranslation();
                    break;
                case "4":
                    Translate();
                    break;
                case "5":
                    AddTranslationFromFile();
                    break;
                case "6":
                    Console.WriteLine("Ваш словарь:");
                    ShowAllDictionary();
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine($"Операции под номером {option} не существует");
                    Console.ReadLine();
                    break;
            }
    }

    public static void MenuText()
    {
        Console.WriteLine($"Выберите одну из команд:");
        Console.WriteLine("1 - AddTranslation");
        Console.WriteLine("2 - RemoveTranslation");
        Console.WriteLine("3 - ChangeTranslation");
        Console.WriteLine("4 - Translate");
        Console.WriteLine("5 - AddTranslateFromFile");
        Console.WriteLine("6 - ShowAllDictionary");
        Console.WriteLine("0 - Exit");
    }

    public static void ShowAllDictionary()
    {
        foreach (KeyValuePair<string, string> currentWord in Dictionary)
        {
            Console.WriteLine($"{currentWord.Key} - {currentWord.Value}");
        }
    }

    public static void AddTranslationFromFile()
    {
        while (true)
        {
            string pathToFile = GetUserInputFileName();
            if (pathToFile == "0")
            {
                break;
            }
            else if (pathToFile != null)
            {
                LoadDictionaryFromFile(pathToFile);
            }
            else
            {
                Console.WriteLine("Вы не ввели имя файла");
            }

        }
    }

    public static string GetUserInputFileName()
    {
        Console.WriteLine("Введите имя файла. Для выхода введите 0");
        string pathToFile = Console.ReadLine();
        if (!string.IsNullOrEmpty(pathToFile))
        {
            return pathToFile;
        }
        return null;
    }

    public static void LoadDictionaryFromFile(string pathToFile)
    {
        try
        {
            using (StreamReader reader = new StreamReader(pathToFile))
            {
                string text = reader.ReadLine();
                while (text != null)
                {
                    string[] words = text.Split(' ');
                    if (words.Length == 2)
                    {
                        if (!Dictionary.ContainsKey(words[0]))
                        {
                            Dictionary.Add(words[0], words[1]);
                        }
                    }
                    text = reader.ReadLine();
                }
                Console.WriteLine("Данные из файла успешно загружены");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Произошла ошибка при чтении файла: " + ex.Message);
        }
    }

    public static void ChangeTranslation()
    {
        while (true)
        {
            Console.WriteLine("Введите слово для замены перевода. Для выхода введите 0");
            string word = Console.ReadLine();
            if (word == "0")
            {
                break;
            }
            else if (Dictionary.ContainsKey(word))
            {
                Console.Write("Введите новый перевод: ");
                string newEngWord = Console.ReadLine();
                Dictionary[word] = newEngWord;
                Console.WriteLine("Перевод изменен");
            }
            else
            {
                Console.WriteLine("Слово по вашему запросу не найдено в словаре");
            }
        }
    }

    public static void Translate()
{
    while (true)
    {
        Console.WriteLine("На какой язык вы хотите перевести слово? Для выхода 0");
        Console.WriteLine("1 - Русский");
        Console.WriteLine("2 - Английский");
        string language = Console.ReadLine();

        if (language == "0")
        {
            break;
        }

        if (language != "1" && language != "2")
        {
            Console.WriteLine("Ошибка");
            continue;
        }

        Console.WriteLine("Введите слово");
        string word = Console.ReadLine();

        if (language == "2" && Dictionary.ContainsKey(word))
        {
            Console.WriteLine($"{word} - {Dictionary[word]}");
            Console.ReadLine();
        }
        else if (language == "1" && Dictionary.ContainsValue(word))
        {
            string matchingWord = Dictionary.FirstOrDefault(currentWord => currentWord.Value == word).Key;
            Console.WriteLine($"{word} - {matchingWord}");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Слово по вашему запросу не найдено в словаре");
        }

    }
}


    public static void RemoveTranslation()
    {
        while (true)
        {
            Console.WriteLine("Введите слово для удаления перевода. Для выхода введите 0 ");
            string word = Console.ReadLine();
            if (word == "0")
            {
                break;
            }
            else if (Dictionary.ContainsKey(word))
            {
                Dictionary[word] = "Перевод отсутствует";
                Console.WriteLine("Перевод слова удален из словаря");
            }
            else
            {
                Console.WriteLine("Слово по вашему запросу не найдено в словаре");
            }
        }
    }

    public static void AddTranslation()
    {
        while (true) 
        {
            Console.WriteLine("Введите 2 значения: слово на русском и перевод. Для выхода 0");
            string text = Console.ReadLine();
            string[] words = text.Split(' ');
            if (text == "0")
            {
                break;
            }
            else if (words.Length == 2)
            {
                if (Dictionary.ContainsKey(words[0]))
                {
                    Console.WriteLine("Слово уже находится в соваре");
                }
                else
                {
                    Dictionary.Add(words[0], words[1]);
                    Console.WriteLine("Слово и перевод добавлены в словарь");
                }

            }
            else
            {
                Console.WriteLine("Ошибка ввода");
            }
        }
    }
}