using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа создает иерархию сотрудников, которые выполняют определенные задачи");
            Worker semen = new Worker("Семен", Departments.Начальство, null);
            Worker rashid = new Worker("Рашид", Departments.Начальство, new List<Worker> { semen });
            Worker ilham = new Worker("Ильхам", Departments.Начальство, new List<Worker> { semen });
            Worker lucas = new Worker("Лукас", Departments.Начальство, new List<Worker> { rashid });
            Worker orkady = new Worker("Оркадий", Departments.Начальство, new List<Worker> { ilham });
            Worker volodya = new Worker("Володя", Departments.Начальство, new List<Worker> { orkady });
            Worker ilshat = new Worker("Ильшат", Departments.Системщик, new List<Worker> { volodya, orkady });
            Worker ivanovich = new Worker("Иваныч", Departments.Системщик, new List<Worker> { ilshat });
            Worker ilya = new Worker("Илья", Departments.Системщик, new List<Worker> { ivanovich });
            Worker vitya = new Worker("Витя", Departments.Системщик, new List<Worker> { ivanovich });
            Worker zhenya = new Worker("Женя", Departments.Системщик, new List<Worker> { ivanovich });
            Worker sergey = new Worker("Сергей", Departments.Разработчик, new List<Worker> { volodya, orkady });
            Worker laysan= new Worker("Ляйсан", Departments.Разработчик, new List<Worker> { sergey });
            Worker marat = new Worker("Марат", Departments.Разработчик, new List<Worker> { laysan });
            Worker dina = new Worker("Дина", Departments.Разработчик, new List<Worker> { laysan });
            Worker ildar = new Worker("Ильдар", Departments.Разработчик, new List<Worker> { laysan });
            Worker anton = new Worker("Антон", Departments.Разработчик, new List<Worker> { laysan });

            Task task1 = new Task("Разработать стратегию продвижения компании на рынке", Departments.Начальство);
            Task task2 = new Task("Планирование и контроль финансовых результатов", Departments.Начальство);
            Task task3 = new Task("Обеспечение безопасности данных компании", Departments.Системщик);
            Task task4 = new Task("Диагностика и устранение неполадок в работе компьютерной техники и сетей", Departments.Системщик);
            Task task5 = new Task("Разработка новых продуктов и сервисов", Departments.Разработчик);

            rashid.AcceptingTheTask(semen, task1);
            volodya.AcceptingTheTask(orkady, task3);
            orkady.AcceptingTheTask(ilham, task2);
            ivanovich.AcceptingTheTask(ildar, task3);
            ilshat.AcceptingTheTask(volodya, task4);
            anton.AcceptingTheTask(semen, task1);
            laysan.AcceptingTheTask(sergey, task5);

            Console.WriteLine("\nНажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}
