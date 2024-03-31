internal class Programm
{
    static int Main()
    {
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        bool isExit = true;

        do
        {
            Console.WriteLine($"Выберите одну из команд:");
            Console.WriteLine("1 - AddTranslation");
            Console.WriteLine("2 - RemoveTranslation");
            Console.WriteLine("3 - ChangeTranslation");
            Console.WriteLine("4 - Translate");
            Console.WriteLine("5 - AddTranslateFromFile");
            Console.WriteLine("6 - ShowAllDictionary");
            Console.WriteLine("0 - Exit");

            string option = Console.ReadLine().Trim();

            if ((dictionary.Count == 0 && option == "2") || (dictionary.Count == 0 && option == "3") || (dictionary.Count == 0 && option == "4") || (dictionary.Count == 0 && option == "6"))
            {
                Console.WriteLine("Словарь пуст");
                Console.ReadLine();
                continue;
            }

            switch (option)
            {
                case "1":
                    AddTranslation(ref dictionary);
                    break;
                case "0":
                    isExit = false;
                    break;
                case "2":
                    RemoveTranslation(ref dictionary);
                    break;
                case "3":
                    ChangeTranslation(ref dictionary);
                    break;
                case "4":
                    Translate(ref dictionary);
                    break;
                case "5":
                    AddTranslationFromFile(ref dictionary);
                    break;
                case "6":
                    Console.WriteLine("Ваш словарь:");
                    ShowAllDictionary(ref dictionary);
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine($"Операции под номером {option} не существует");
                    Console.ReadLine();
                    break;
            }
        } while (isExit);

        return 1;
    }

    static void ShowAllDictionary(ref Dictionary<string, string> dictionary)
    {
        foreach (KeyValuePair<string, string> currentWord in dictionary)
        {
            Console.WriteLine($"{currentWord.Key} - {currentWord.Value}");
        }
    }

    static void AddTranslationFromFile(ref Dictionary<string, string> dictionary)
    {
        bool isExit = true;

        do
        {
            string pathToFile = GetUserInputFileName();
            if (pathToFile == "0")
            {
                isExit = false;
            }
            else if (pathToFile != null)
            {
                LoadDictionaryFromFile(pathToFile, ref dictionary);
            }

        } while (isExit);
    }

    static string GetUserInputFileName()
    {
        Console.WriteLine("Введите имя файла. Для выхода введите 0");
        string pathToFile = Console.ReadLine();
        if (!string.IsNullOrEmpty(pathToFile))
        {
            return pathToFile;
        }
        else
        {
            Console.WriteLine("Входной файл пуст\n");
            return null; // В случае некорректного завершения цикла
        }
    }

    static void LoadDictionaryFromFile(string pathToFile, ref Dictionary<string, string> dictionary)
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
                        if (!dictionary.ContainsKey(words[0]))
                        {
                            dictionary.Add(words[0], words[1]);
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

    static void ChangeTranslation(ref Dictionary<string, string> dictionary)
    {
        bool isExit = true;

        do
        {
            Console.WriteLine("Введите слово для замены перевода. Для выхода введите 0");
            string word = Console.ReadLine();
            if (word == "0")
            {
                isExit = false;
                break;
            }
            else if (dictionary.ContainsKey(word))
            {
                Console.Write("Введите новый перевод: ");
                string newEngWord = Console.ReadLine();
                dictionary[word] = newEngWord;
                Console.WriteLine("Перевод изменен");
            }
            else
            {
                Console.WriteLine("Слово по вашему запросу не найдено в словаре");
            }
        } while (isExit);
    }

    static void Translate(ref Dictionary<string, string> dictionary)
    {
        bool isExit = true;

        do
        {
            Console.WriteLine("На какой язык вы хотите перевести слово? Для выхода 0");
            Console.WriteLine("1 - Русский");
            Console.WriteLine("2 - Английский");
            string language = Console.ReadLine();
            if (language == "0")
            {
                isExit = false;
                break;
            }
            if (language == "1" || language == "2")
            {
                Console.WriteLine("Введите слово");
                string word = Console.ReadLine();
                if ((language == "2" && dictionary.ContainsKey(word)) || (language == "1" && dictionary.ContainsValue(word)))
                {
                    if (language == "2")
                    {
                        Console.WriteLine($"{word} - {dictionary[word]}");
                        Console.ReadLine();
                    }
                    else if (language == "1")
                    {
                        foreach (var currentWord in dictionary)
                        {
                            if (currentWord.Value == word)
                            {
                                Console.WriteLine($"{word} - {currentWord.Key}");
                                Console.ReadLine();
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Слово по вашему запросу не найдено в словаре");
                }
            }
            else
            {
                Console.WriteLine("Ошибка");
            }
        } while (isExit);
    }

    static void RemoveTranslation(ref Dictionary<string, string> dictionary)
    {
        bool isExit = true;

        do
        {
            Console.WriteLine("Введите слово для удаления перевода. Для выхода введите 0 ");
            string word = Console.ReadLine();
            if (word == "0")
            {
                isExit = false;
                break;
            }
            else if (dictionary.ContainsKey(word))
            {
                dictionary[word] = "Перевод отсутствует";
                Console.WriteLine("Перевод слова удален из словаря");
            }
            else
            {
                Console.WriteLine("Слово по вашему запросу не найдено в словаре");
            }
        } while (isExit);
    }

    static void AddTranslation(ref Dictionary<string, string> dictionary)
    {
        bool isExit = true;

        do
        {
            Console.WriteLine("Введите 2 значения: слово на русском и перевод. Для выхода 0");
            string text = Console.ReadLine();
            string[] words = text.Split(' ');
            if (text == "0")
            {
                isExit = false;
                break;
            }
            else if (words.Length == 2)
            {
                if (dictionary.ContainsKey(words[0]))
                {
                    Console.WriteLine("Слово уже находится в соваре");
                }
                else
                {
                    dictionary.Add(words[0], words[1]);
                    Console.WriteLine("Слово и перевод добавлены в словарь");
                }

            }
            else
            {
                Console.WriteLine("Ошибка ввода");
            }
        } while (isExit);
    }
}