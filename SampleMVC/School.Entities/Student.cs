using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Entities
{
    public class Student
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid StudentId { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        [MaxLength(2)]
        public string Grade { get; set; }

        [Required]
        public Guid TeacherId { get; set; }

        public virtual Teacher Teacher { get; set; }
    }
}
