namespace School.Data.Migrations
{
    using School.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            var teachers = new List<Teacher>
            {
                new Teacher {
                    TeacherId = Guid.NewGuid(),
                    Name = "Science Guy",
                },
                new Teacher {
                    TeacherId = Guid.NewGuid(),
                    Name = "Maths Guy",
                },
                new Teacher {
                    TeacherId = Guid.NewGuid(),
                    Name = "English Guy",
                },
            };
            teachers.ForEach(s => context.Teachers.AddOrUpdate(p => p.TeacherId, s));
            context.SaveChanges();

            var students = new List<Student>
            {
                new Student
                {
                    StudentId = Guid.NewGuid(),
                    TeacherId = context.Teachers.Where(x => x.Name == "Science Guy").FirstOrDefault().TeacherId,
                    Name = "Student1 Science",
                    Grade = "A+"
                },
                new Student
                {
                    StudentId = Guid.NewGuid(),
                    TeacherId = context.Teachers.Where(x => x.Name == "Science Guy").FirstOrDefault().TeacherId,
                    Name = "Student2 Science",
                    Grade = "B"
                },
                new Student
                {
                    StudentId = Guid.NewGuid(),
                    TeacherId = context.Teachers.Where(x => x.Name == "Maths Guy").FirstOrDefault().TeacherId,
                    Name = "Student1 Maths",
                    Grade = "F"
                },
                new Student
                {
                    StudentId = Guid.NewGuid(),
                    TeacherId = context.Teachers.Where(x => x.Name == "Maths Guy").FirstOrDefault().TeacherId,
                    Name = "Student2 Maths",
                    Grade = "B-"
                },
                new Student
                {
                    StudentId = Guid.NewGuid(),
                    TeacherId = context.Teachers.Where(x => x.Name == "Maths Guy").FirstOrDefault().TeacherId,
                    Name = "Student3 Maths",
                    Grade = "B+"
                },
                new Student
                {
                    StudentId = Guid.NewGuid(),
                    TeacherId = context.Teachers.Where(x => x.Name == "English Guy").FirstOrDefault().TeacherId,
                    Name = "Student1 English",
                    Grade = "C+"
                },
            };
            students.ForEach(s => context.Students.AddOrUpdate(p => p.StudentId, s));
            context.SaveChanges();
        }
    }
}
