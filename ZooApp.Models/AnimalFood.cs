using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZooApp.Models
{
    public class AnimalFood
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }
        [ForeignKey("Animal")]
        [Required]
        public int AnimalId { set; get; }
        public virtual Animal Animal { set; get; }
        [ForeignKey("Food")]
        [Required]
        public int FoodId { set; get; }
        public virtual Food Food { set; get; }
        [Required]
        public double Quantity { get; set; }
    }
}