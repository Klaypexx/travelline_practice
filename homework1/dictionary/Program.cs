using System.Collections.Generic;

internal class Programm
{
    private static Dictionary<string, string> _dictionary { get; set; } = new();
    public static int Main()
    {
        while (true)
        {
            MenuText();

            string option = Console.ReadLine().Trim();
            if (option == "0") break;

            HashSet<string> optionCollection = new() {"2", "3", "4", "6"};
            bool emptyDictonaryCondition = !_dictionary.Any() && optionCollection.Contains(option);

            if (emptyDictonaryCondition)
            {
                Console.WriteLine("Словарь пуст");
                Console.ReadLine();
                continue;
            }

            SwitchOption(option);

        }

        return 1;
    }

    private static void SwitchOption(string option) 
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

    private static void MenuText()
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

    private static void ShowAllDictionary()
    {
        foreach (KeyValuePair<string, string> currentWord in _dictionary)
        {
            Console.WriteLine($"{currentWord.Key} - {currentWord.Value}");
        }
    }

    private static void AddTranslationFromFile()
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

    private static string GetUserInputFileName()
    {
        Console.WriteLine("Введите имя файла. Для выхода введите 0");
        string pathToFile = Console.ReadLine();
        if (!string.IsNullOrEmpty(pathToFile))
        {
            return pathToFile;
        }
        return null;
    }

    private static void LoadDictionaryFromFile(string pathToFile)
    {
        try
        {
            StreamReader reader = new StreamReader(pathToFile);
            string text = reader.ReadLine();
            while (text != null)
            {
                string[] words = text.Split(' ');
                if (words.Length == 2 && !_dictionary.ContainsKey(words[0]))
                {
                    _dictionary.Add(words[0], words[1]);
                }
                text = reader.ReadLine();
            }
            Console.WriteLine("Данные из файла успешно загружены");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Произошла ошибка при чтении файла: " + ex.Message);
        }
    }

    private static void ChangeTranslation()
    {
        while (true)
        {
            Console.WriteLine("Введите слово для замены перевода. Для выхода введите 0");
            string word = Console.ReadLine();
            if (word == "0")
            {
                break;
            }
            else if (_dictionary.ContainsKey(word))
            {
                Console.Write("Введите новый перевод: ");
                string newEngWord = Console.ReadLine();
                _dictionary[word] = newEngWord;
                Console.WriteLine("Перевод изменен");
            }
            else
            {
                Console.WriteLine("Слово по вашему запросу не найдено в словаре");
            }
        }
    }

    private static void Translate()
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

            if (language == "2" && _dictionary.ContainsKey(word))
            {
                Console.WriteLine($"{word} - {_dictionary[word]}");
                Console.ReadLine();
            }
            else if (language == "1" && _dictionary.ContainsValue(word))
            {
                string matchingWord = _dictionary.FirstOrDefault(currentWord => currentWord.Value == word).Key;
                Console.WriteLine($"{word} - {matchingWord}");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Слово по вашему запросу не найдено в словаре");
            }

        }
    }


    private static void RemoveTranslation()
    {
        while (true)
        {
            Console.WriteLine("Введите слово для удаления перевода. Для выхода введите 0 ");
            string word = Console.ReadLine();
            if (word == "0")
            {
                break;
            }
            else if (_dictionary.ContainsKey(word))
            {
                _dictionary[word] = "Перевод отсутствует";
                Console.WriteLine("Перевод слова удален из словаря");
            }
            else
            {
                Console.WriteLine("Слово по вашему запросу не найдено в словаре");
            }
        }
    }

    private static void AddTranslation()
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

            if (words.Length != 2)
            {
                Console.WriteLine("Ошибка ввода");
                continue;
            }

            if (_dictionary.ContainsKey(words[0]))
            {
                Console.WriteLine("Слово уже находится в словаре");
            }
            else
            {
                _dictionary.Add(words[0], words[1]);
                Console.WriteLine("Слово и перевод добавлены в словарь");
            }
        }
    }
}