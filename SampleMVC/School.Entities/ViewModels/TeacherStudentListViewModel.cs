using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Entities.ViewModels
{
    public class TeacherStudentListViewModel
    {
        [Display(Name = "Teacher ID")]
        public Guid TeacherId { get; set; }

        [Display(Name = "Teacher Name")]
        public string TeacherName { get; set; }

        public List<StudentDisplayViewModel> Students { get; set; }
    }
}
