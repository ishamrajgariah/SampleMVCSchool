using School.Entities;
using School.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Data
{
    public class TeacherRepository
    {
        public Teacher GetTeacher(Guid teacherid)
        {
            if (teacherid != Guid.Empty)
            {
                using (var context = new ApplicationDbContext())
                {
                    var teacher = context.Teachers.AsNoTracking()
                        .Where(x => x.TeacherId == teacherid)
                        .Single();
                    return teacher;
                }
            }
            return null;
        }

        public List<TeacherDisplayViewModel> GetTeachers()
        {
            using (var context = new ApplicationDbContext())
            {
                List<Teacher> teachers = new List<Teacher>();
                teachers = context.Teachers.AsNoTracking().ToList();

                if (teachers != null)
                {
                    List<TeacherDisplayViewModel> teachersDisplay = new List<TeacherDisplayViewModel>();
                    foreach (var x in teachers)
                    {
                        var teacherDisplay = new TeacherDisplayViewModel()
                        {
                            TeacherId = x.TeacherId,
                            TeacherName = x.Name,
                        };
                        teachersDisplay.Add(teacherDisplay);
                    }
                    return teachersDisplay;
                }
                return null;
            }
        }



        public TeacherEditViewModel CreateTeacher()
        {
            var teacher = new TeacherEditViewModel()
            {
                TeacherId = Guid.NewGuid().ToString(),
            };
            return teacher;
        }

        public bool SaveTeacher(TeacherEditViewModel teacherEdit)
        {
            if (teacherEdit != null)
            {
                using (var context = new ApplicationDbContext())
                {
                    if (Guid.TryParse(teacherEdit.TeacherId, out Guid newGuid))
                    {
                        var teacher = new Teacher()
                        {
                            TeacherId = newGuid,
                            Name = teacherEdit.TeacherName,
                        };

                        context.Teachers.Add(teacher);
                        context.SaveChanges();
                        return true;
                    }
                }
            }
            
            return false;
        }
    }
}
