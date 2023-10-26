using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public enum Departments
    {
        Начальство,
        Системщик,
        Разработчик
    }
    class Worker
    {
        string name;
        Departments department;
        List <Worker> supervisors = new List<Worker>();
        public string Name { get; set; }
        public Departments Department { get; set; }
        public Worker(string name, Departments department, List<Worker> supervis)
        {
            Name = name;
            Department = department;
            supervisors = supervis;
        }
        public void AcceptingTheTask(Worker worker, Task task)
        {
            Console.WriteLine($"\n{worker.Name} попросил {Name} сделать {task.Description}");
            if (supervisors.Contains(worker) && Department == task.TaskDepartment)
            {
                Console.WriteLine($"{Name} взялся за выполнеие задачи, т.к он/а {Department} и слушается {worker.Name}");
            }
            else
            {
                Console.WriteLine($"{Name} не берет задачу, т.к либо не совпадает отдел, либо не тот управляющий");
            }
        }
    }
}
