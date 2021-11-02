using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public ICollection<Registration> Registrations { get; set; }
    }
}
