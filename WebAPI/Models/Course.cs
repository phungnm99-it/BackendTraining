using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public ICollection<Registration> Registrations { get; set; }
    }
}
