using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    public class Professor
    {
        public Professor(string name, float salary)
        {
            this.Name = name;
            this.Salary = salary;
        }
        public Course Course { get; set; } = new Course();
        public string Name { get; set; }
        public float Salary { get; set; }

        // Добаляєм завдання в курс і відповідно всім його студентам
        public void AddAssignemnt(string assignment)
        {
            this.Course.Assignments.Add(assignment);
            foreach (var item in this.Course.Students)
            {
                item.Assignments.Add(assignment, false);
            }
        }

        // При виклику цього методу, йде провірка чи метод виконаний
        // якщо він виконаний, то професор ставить оцінку і добаляє цю таску в stud.CourseProgress
        public bool CheckAssignment(Student student, string title)
        {
            if (student.Assignments != null)
            {
                var isExists = student.Assignments.ContainsKey(title);

                if (isExists)
                {
                    var assignment = student.Assignments[title];
                    if (assignment)
                    {
                        var mark = new Random().Next(2, 5);
                        student.CourseProggress[this.Course.Title].CompletedAssignments.Add(title, mark);
                        Console.WriteLine($"The assignment {title} is rated {mark} points");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine($"Your task {title} hasn`t done yet!");
                        return false;
                    }
                }
            }
            Console.WriteLine("Assignment doesn`t exists!");
            return false;
        }
    }
}
