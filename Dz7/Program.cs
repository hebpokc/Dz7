using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Dz7
{
    class Program
    {
        static string ReverseLetters(string input)
        {
            string output = "";
            string[] words = input.Split(' ');
            foreach (var word in words)
            {
                for (int i = word.Length; i > 0; i--)
                {
                    output += word[i - 1];
                }
                output += ' ';
            }
            return output;
        }
        static void checkArgImplementInterface(Speed s)
        {
            IFormattable form, form2;

            if (s is IFormattable)
            {
                form = (IFormattable)s;
            }
            else
            {
                form = null;
            }

            if (form is null)
            {
                Console.WriteLine("Не реализует IFormattable");
            }
            else
            {
                Console.WriteLine("Реализует IFormattable");
            }

            form2 = s as IFormattable;

            if (form2 is null)
            {
                Console.WriteLine("Не реализует IFormattable");
            }
            else
            {
                Console.WriteLine("Реализует IFormattable");
            }
        }
        public static void SearchMail(ref string s)
        {
            int index = s.IndexOf('#');
            if (index != -1)
            {
                s = s.Substring(index + 1);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Упражнение 8.1");
            Console.WriteLine("Программа создает объект класса банк, в котором есть метод перевода");
            Console.WriteLine("\nСоздание 1 счета");
            int type;
            double balance, money;
            BankAccount account1 = new BankAccount();
            BankAccount account2 = new BankAccount();

            Console.Write("Введите баланс: ");
            if (double.TryParse(Console.ReadLine(), out balance))
            {
                account1.SetBalance(balance);
                Console.WriteLine("Введите тип аккаунта: \n1) Текущий \n2) Сберегательный");
                if (int.TryParse(Console.ReadLine(), out type))
                {
                    account1.SetBankAccountType(type);
                    account1.Print();
                }
                else
                {
                    Console.WriteLine("\nВы ввели не число");
                }
            }
            else
            {
                Console.WriteLine("\nВы ввели не число");
            }
            Console.WriteLine("\nСоздание 2 счета");

            Console.Write("Введите баланс: ");
            if (double.TryParse(Console.ReadLine(), out balance))
            {
                account2.SetBalance(balance);
                Console.WriteLine("Введите тип аккаунта: \n1) Текущий \n2) Сберегательный");
                if (int.TryParse(Console.ReadLine(), out type))
                {
                    account2.SetBankAccountType(type);
                    account2.Print();
                }
                else
                {
                    Console.WriteLine("\nВы ввели не число");
                }
            }
            else
            {
                Console.WriteLine("\nВы ввели не число");
            }
            Console.Write("\nВведите сумму перевода: ");
            if (double.TryParse(Console.ReadLine(), out money))
            {
                account1.Transfer(account2, money);
                account1.Print();
                account2.Print();
            }
            else
            {
                Console.WriteLine("\nВы ввели не число");
            }

            Console.WriteLine("\nУпражнение 8.2");
            Console.Write("Введите строку: ");
            string input = Console.ReadLine();
            Console.WriteLine($"\nПеревернутая строка: {ReverseLetters(input)}");

            Console.WriteLine("\nУпражнение 8.3");
            Console.Write("Введите имя файла: ");
            string fileName = Console.ReadLine();
            string fileResultName = "result.txt";
            if (!File.Exists(fileName))
            {
                Console.WriteLine("\nДанного файла не существует");
            }
            else
            {
                string inputText = File.ReadAllText(fileName);
                string outputText = inputText.ToUpper();
                File.WriteAllText(fileResultName, outputText);

                Console.WriteLine("\nФайл создан");

                Console.WriteLine("Содержимое файла: " + outputText);
            }

            Console.WriteLine("\nУпражнение 8.4");
            Console.WriteLine("Метод, который проверяет реализует ли входной параметр метода интерфейс System.IFormattable.");
            Console.Write("\nВведите скорость: ");
            if (double.TryParse(Console.ReadLine(), out double speed))
            {
                Speed s = new Speed(speed);
                checkArgImplementInterface(s);
            }
            else
            {
                Console.WriteLine("\nВы ввели не число");
            }

            Console.WriteLine("\nДом. задание 8.1");
            Console.Write("Введите название файла: ");
            string path = Console.ReadLine();
            if (!File.Exists(path))
            {
                Console.WriteLine("\nДанного файла не существуте");
            }
            else
            {
                string[] lines = File.ReadAllLines(path);
                StreamWriter sw = new StreamWriter("mails.txt");
                foreach (string line in lines)
                {
                    string[] parts = line.Split('#');
                    if (parts.Length == 2 && parts[1].Contains("@"))
                    {
                        sw.WriteLine(parts[1]);
                    }
                }
                Console.WriteLine("\nФайл с email создан");
                sw.Close();
            }
            Console.Write("\nВведите строку: ");
            input = Console.ReadLine();
            SearchMail(ref input);
            Console.WriteLine("Mail: " + input);

            Console.WriteLine("\nДом. задание 8.2");
            Console.WriteLine("Программа создает список из песен, выводит информацию о них и сравнивает");

            List<Song> songs = new List<Song>();
            Song song1 = new Song("Hello, World!", "Alice", null);
            Song song2 = new Song("Moonlight Sonata", "Ludwig van Beethoven", song1);
            Song song3 = new Song("Yellow Submarine", "The Beatles", song2);
            Song song4 = new Song("Smells Like Teen Spirit", "Nirvana", song3);

            songs.Add(song1);
            songs.Add(song2);
            songs.Add(song3);
            songs.Add(song4);

            foreach (var song in songs)
            {
                Console.WriteLine(song.Title());
            }

            Console.WriteLine("\nСравнение 1-ой и 2-ой песни");
            if (songs[0].Equals(songs[1]))
            {
                Console.WriteLine("Одинаковые песни");
            }
            else
            {
                Console.WriteLine("Разные песни");
            }


            Console.WriteLine("\nНажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}
