using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Entities.ViewModels
{
    public class TeacherEditViewModel
    {
        [Display(Name = "Teacher ID")]
        public string TeacherId { get; set; }

        [Required]
        [StringLength(128)]
        [Display(Name = "Teacher Name")]
        public string TeacherName { get; set; }
    }
}
