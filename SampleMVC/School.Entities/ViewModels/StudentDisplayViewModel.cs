using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Entities.ViewModels
{
    public class StudentDisplayViewModel
    {
        public Guid TeacherId { get; set; }

        [Display(Name = "Student ID")]
        public Guid StudentId { get; set; }

        [Display(Name = "Student Name")]
        public string StudentName { get; set; }


        [Display(Name = "Grade")]
        public string Grade { get; set; }
    }
}
