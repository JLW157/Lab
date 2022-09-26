using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    public class Student
    {
        /*
         * Для того, щоб робити курс прогрес потрібно для кожного курс прогрес добавляти екземпляр курсу
         */
        public Student() { }

        public Student(string name)
        {
            Name = name;
        }

        private Dictionary<string, bool> Lectures = new Dictionary<string, bool>();
        public List<Course> Courses { get; set; } = new List<Course>();
        public Dictionary<string, bool> Assignments { get; set; } = new Dictionary<string, bool>();
        public Dictionary<string, CourseProggress> CourseProggress { get; set; } = new Dictionary<string, CourseProggress>();
        public string Name { get; set; }
        public float AvgMark
        {
            get
            {
                float result = 0;
                foreach (var item in this.CourseProggress.Values)
                {
                    result += item.GetFinalMark();
                }
                return result;
            }
        }

        public void DoSmth()
        {
            Console.WriteLine("sdsds");
        }

        public void VisitLecture(string courseTitle, string lecture)
        {
            this.Lectures[lecture] = true;
            this.CourseProggress[courseTitle].VisitedLectures++;
        }

        // При енролі студента додається вся потрібно інфа
        /*public void Enroll(Course course)
        {
            this.Course = course;
            this.CourseProggress = new Dictionary<string, CourseProggress>();
            this.Assignments = new Dictionary<string, bool>();
            var tmpTasks = Course.Assignments;
            foreach (var item in this.Course.Assignments)
            {
                this.Assignments.Add(item, false);
            }
            this.Course.Students.Add(this);

            Console.WriteLine("Student has successfully enroled on Course");
        }*/
        public void Enroll(Course course)
        {
            this.Courses.Add(course);

            if (this.CourseProggress.Count < 1)
            {
                this.CourseProggress = new Dictionary<string, CourseProggress>();
            }

            this.CourseProggress.Add(course.Title, new CourseProggress());
            this.CourseProggress[course.Title].Course = course;
            if (this.Assignments.Count() < 1)
            {
                this.Assignments = new Dictionary<string, bool>();
            }
            Course courseTmp = this.Courses.FirstOrDefault(crs => crs.Title == course.Title);

            foreach (var item in courseTmp.Assignments)
            {
                this.Assignments.Add(item, false);
            }
            courseTmp.Students.Add(this);

            Console.WriteLine("Student has successfully enroled on Course");
        }

        public void Unenroll(string courseTitle)
        {
            var course = this.Courses.FirstOrDefault(crs => crs.Title == courseTitle);

            this.CourseProggress.Remove(course.Title);
            foreach (var item in this.Assignments.Keys)
            {
                foreach (var crsAssign in course.Assignments)
                {
                    if (item == crsAssign)
                    {
                        Assignments.Remove(item);
                    }
                }
            }
            course.Students.Remove(this);
            this.Courses.Remove(course);
            Console.WriteLine("Student has successfully unenroled from Course");
        }

        public void DoAssignment(string title)
        {
            foreach (var item in this.Assignments)
            {
                if (item.Key == title)
                {
                    this.Assignments[title] = true;
                    Console.WriteLine($"Assignment {title} is done");
                    return;
                }
            }

            Console.WriteLine("Assignment not found!");
        }

        public void ShowAssignments()
        {
            Console.WriteLine("All assinments:");
            foreach (var item in this.Assignments)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }
    }
}
