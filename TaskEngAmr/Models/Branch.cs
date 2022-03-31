using System.ComponentModel.DataAnnotations;

namespace TaskEngAmr.Models
{
    public class Branch
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string ArabicName { get; set; }
        [MaxLength(100)]
        public string EnglishName { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        [MaxLength(100)]
        public string Address { get; set; }
    }
}
