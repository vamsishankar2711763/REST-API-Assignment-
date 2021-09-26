using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Model
{
    public class MovieAdd
    {
        [Key]
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Plot { get; set; }
        public byte[] Poster { get; set; }
        public List<int> ActorId { get; set; }
        public List<int> ProducerId { get; set; }
    }
}
