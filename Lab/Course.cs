using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    public class Course
    {
        public Course(){}

        public List<Student> Students { get; set; } = new List<Student>();

        // Добавлєм професора та цьому ж професору добавляємо цей курс
        private Professor professor;
        public Professor Professor { get { return professor; }
            set 
            {
                professor = value;
                professor.Course = this;
            } 
        }
        public string Title { get; set; }
        public List<string> Assignments { get; set; } = new List<string>();
        public List<string> Lectures { get; } = new List<string>();

        public void AddStudent(Student student)
        {
            Students.Add(student);
            Console.WriteLine($"Student: Name: {student.Name} was added");
        }

        public void RemoveStudent(Student student)
        {
            Students.Remove(student);
            Console.WriteLine($"Student - Name: {student.Name} was removed");
        }


        public void ShowInfo()
        {
            Console.WriteLine("Students of course: ");
            foreach (var item in this.Students)
            {
                Console.WriteLine($"\tStudent: Name - {item.Name}, AvgMark - {item.AvgMark}");
                Console.WriteLine("\tAssignments: ");
                foreach (var assignment in item.Assignments)
                {
                    Console.WriteLine($"\t\tTitle: {assignment.Key} | is Done: {assignment.Value}");
                }
                Console.WriteLine("\tStudent proggress: ");
                
                Console.WriteLine("\t\tAmount of visited Lectures: " + item?.CourseProggress[this.Title]?.VisitedLectures);
                Console.WriteLine("\t\tCompleted assignments: ");
                foreach (var completedAssignments in item.CourseProggress[this.Title].CompletedAssignments)
                {
                    Console.WriteLine($"\t\t{completedAssignments.Key} - {completedAssignments.Value}");
                }
                Console.WriteLine("Final mark of student: " + item.CourseProggress[this.Title].GetFinalMark());
            }
        }
    }
}
