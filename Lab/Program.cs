using Lab;

Course course2 = new Course();
Professor professor2 = new Professor("Dima", 100.23f);
course2.Title = "Fundamentals of C#";
course2.Professor = professor2;

course2.Professor.AddAssignemnt("Homework #3");
course2.Professor.AddAssignemnt("Homework #4");

Course course = new Course();
Professor professor = new Professor("Amigo", 223);

course.Title = "Basics Of SE";
course.Professor = professor;

Student stud = new Student("Alex");
Student stud2 = new Student("Serhiy");

course.Professor.AddAssignemnt("Homework #1");
course.Professor.AddAssignemnt("Homework #2");

stud.Enroll(course);
stud2.Enroll(course);

stud.Enroll(course2);
stud2.Enroll(course2);

stud2.ShowAssignments();

//course.Professor.CheckAssignment(stud, "Homework #2");
course.Professor.CheckAssignment(stud2, "Homework #2");
course2.Professor.CheckAssignment(stud2, "Homework #3");

stud2.DoAssignment("Homework #1");
stud2.DoAssignment("Homework #3");

course.Professor.CheckAssignment(stud2, "Homework #1");
course2.Professor.CheckAssignment(stud2, "Homework #3");

stud2.DoAssignment("Homework #2");
stud2.DoAssignment("Homework #4");

course.Professor.CheckAssignment(stud2, "Homework #2");
course2.Professor.CheckAssignment(stud2, "Homework #4");

Console.WriteLine(stud2.AvgMark);

stud.Unenroll("Fundamentals of C#");
course.ShowInfo();
course2.ShowInfo();

stud2.ShowAssignments();