using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Model
{
    public class Actor
    {
        [Key]
        public int ActorId { get; set; }

        public string ActorName { get; set; }
        public string Bio { get; set; }
        public DateTime DOB { get; set; }
        public char Gender { get; set; }

    }
}
