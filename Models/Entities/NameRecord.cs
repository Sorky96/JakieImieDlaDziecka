using Enums;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class NameRecord
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public Gender Gender { get; set; } 
        public int Count { get; set; }
    }
}
