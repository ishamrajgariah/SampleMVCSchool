using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Entities
{
    public class Teacher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid TeacherId { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        public virtual List<Student> Students { get; set; }
    }
}
