using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntroBackend.Models
{
    public class Stock
    {
        [Key]
        public int Id { get; set; }
        public int Amount { get; set; }
        public  int BeerId { get; set; }

        [ForeignKey("BeerId")]
        public virtual Beer? Beer { get; set; }
    }
}
