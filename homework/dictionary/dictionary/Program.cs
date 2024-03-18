using System.Diagnostics.Tracing;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

internal class Programm
{
    static void showAllDictionary(ref Dictionary<string, string> dictionary)
    {
        Console.WriteLine("Ваш словарь:");
        foreach (var currentWord in dictionary)
        {
            Console.WriteLine($"{currentWord.Key} - {currentWord.Value}");
        }
        Console.ReadLine();
    }
    static void addTranslationFromFile(ref Dictionary<string, string> dictionary)
    {
        while (true) {
            Console.WriteLine("Введите имя файла. Для выхода 0");
            string refs = Console.ReadLine();
            if (refs == "0")
            {
                break;
            } else
            {
                try
                {
                    StreamReader reader = new StreamReader(refs);
                    string text = reader.ReadLine();
                    while (text != null)
                    {
                        string[] words = text.Split(' ');
                        if (words.Length == 2 )
                        {
                            if (!dictionary.ContainsKey(words[0])) {
                                dictionary.Add(words[0], words[1]);
                            }
                        }
                        text = reader.ReadLine();
                    }
                    Console.WriteLine("Данные из файла успешно загружены");
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

        }
    }
    static void changeTranslation(ref Dictionary<string, string> dictionary)
    {
        while (true)
        {
            Console.WriteLine("Введите слово для замены перевода. Для выхода введите Exit");
            string word = Console.ReadLine();
            if (word == "0")
            {
                break;
            }
            else
            {
                if (dictionary.ContainsKey(word))
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
            }

        }
    }
    static void translate(ref Dictionary<string, string> dictionary)
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
            } else
            {
                Console.WriteLine("Ошибка");
            }

        }
    }
    static void removeTranslation(ref Dictionary<string, string> dictionary)
    {
        while (true)
        {
            Console.WriteLine("Введите слово для удаления перевода. Для выхода введите 0 ");
            string word = Console.ReadLine();
            if (word == "0") 
            {
                break;
            } 
            else
            {
                if (dictionary.ContainsKey(word))
                {
                    dictionary[word] = "Перевод отсутствует";
                    Console.WriteLine("Перевод слова удален из словаря");
                }
                else
                {
                    Console.WriteLine("Слово по вашему запросу не найдено в словаре");
                }

            }

        }
    }
   static void addTranslation(ref Dictionary<string, string> dictionary)
    {
        while (true)
        {
            Console.WriteLine("Введите 2 значения: слово на русском и перевод. Для выхода 0");
            string text = Console.ReadLine();
            if (text == "0")
            {
                break;
            } 
            else
            {
                string[] words = text.Split(' ');
                if (words.Length == 2)
                {
                    if (dictionary.ContainsKey(words[0])) {
                        Console.WriteLine("Слово уже находится в соваре");
                    } else
                    {
                        dictionary.Add(words[0], words[1]);
                        Console.WriteLine("Слово и перевод добавлены в словарь");
                    }

                } else
                {
                    Console.WriteLine("Ошибка ввода");
                }
            }

        }
    }
    static int Main()
    {
        var dictionary = new Dictionary<string, string>();

        while (true)
        {
            Console.WriteLine($"Выберите одну из команд:");
            Console.WriteLine("1 - AddTranslation");
            Console.WriteLine("2 - RemoveTranslation");
            Console.WriteLine("3 - ChangeTranslation");
            Console.WriteLine("4 - Translate");
            Console.WriteLine("5 - AddTranslateFromFile");
            Console.WriteLine("6 - ShowAllDictionary");
            Console.WriteLine("0 - Exit");

            string option = Console.ReadLine();

            switch(option)
            {
                case "1":
                    addTranslation(ref dictionary);
                    break;
                case "0":
                    return 1;
                case "2":
                    if (dictionary.Count != 0) 
                    { 
                        removeTranslation(ref dictionary);
                    } 
                    else
                    {
                        Console.WriteLine("Словарь пуст");
                    }
                    break;
                case "3":
                    if (dictionary.Count != 0)
                    {
                        changeTranslation(ref dictionary);
                    }
                    else
                    {
                        Console.WriteLine("Словарь пуст");
                    }
                    break;
                case "4":
                    if (dictionary.Count != 0)
                    {
                        translate(ref dictionary);
                    }
                    else
                    {
                        Console.WriteLine("Словарь пуст");
                    }
                    break;
                case "5":
                    addTranslationFromFile(ref dictionary);
                    break;
                case "6":
                    showAllDictionary(ref dictionary);
                    break;
            }
        }
    }

}