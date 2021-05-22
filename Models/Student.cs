using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Student015.Models
{
    public class Student
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public String Name { get; set; }

        [Required]
        public String Course { get; set; }

        [Required]
        public int Semester { get; set; }

        [Required]
        public int BirthYear { get; set; }
    }
}
