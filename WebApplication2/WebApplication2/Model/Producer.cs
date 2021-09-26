using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Model
{
    public class Producer
    {
        [Key]
        public int ProducerId { get; set; }
        public string ProducerName { get; set; }
        public DateTime DOB { get; set; }
        public string Company { get; set; }
        public char Gender { get; set; }
        public string BIO { get; set; }
    }
}
