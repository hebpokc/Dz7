using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    class Task
    {
        string description;
        Departments taskDepartment;
        public string Description { get; set; }
        public Departments TaskDepartment { get; set; }
        public Task(string description, Departments taskd)
        {
            Description = description;
            TaskDepartment = taskd;
        }
    }
}
