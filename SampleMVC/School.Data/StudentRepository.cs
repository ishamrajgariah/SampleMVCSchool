using School.Entities;
using School.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Data
{
    public class StudentRepository
    {
        public TeacherStudentListViewModel GetTeacherStudentDisplay(Guid teacherId)
        {
            if (teacherId != null && teacherId != Guid.Empty)
            {
                using (var context = new ApplicationDbContext())
                {
                    var teacherRepo = new TeacherRepository();
                    var teacher = teacherRepo.GetTeacher(teacherId);
                    if (teacher != null)
                    {
                        var teacherStudentListVm = new TeacherStudentListViewModel()
                        {
                            TeacherId = teacher.TeacherId,
                            TeacherName = teacher.Name,
                        };

                        List<StudentDisplayViewModel> studentList = context.Students.AsNoTracking()
                            .Where(x => x.TeacherId == teacherId)
                            .Select(x =>
                           new StudentDisplayViewModel
                           {
                               StudentId = x.StudentId,
                               StudentName = x.Name,
                               Grade = x.Grade
                           }).ToList();

                        teacherStudentListVm.Students = studentList;
                        return teacherStudentListVm;
                    }
                }
            }
            return null;
        }

        public void SaveStudents(List<StudentDisplayViewModel> students)
        {
            if (students != null)
            {
                using (var context = new ApplicationDbContext())
                {
                    foreach (var student in students)
                    {
                        var record = context.Students.Find(student.StudentId);
                        if (record != null)
                        {
                            record.Name = student.StudentName;
                            record.Grade = student.Grade;
                        }
                    }
                    context.SaveChanges();
                }
            }
        }
    }
}
