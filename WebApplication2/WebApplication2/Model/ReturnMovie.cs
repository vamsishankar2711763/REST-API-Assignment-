using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Model
{
    public class ReturnMovie
    {
        public string MovieName { get; set; }
        public string Actors { get; set; }
        public string Producers { get; set; }
        public DateTime ReleaseDate { get; set; }        
        public string Plot { get; set; }
                
    }
}
