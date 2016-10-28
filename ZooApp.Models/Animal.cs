using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ZooApp.Models
{
    public class Animal
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }
        [Required]
        [StringLength(50)]
        [Index("Animal_Name")]
        public string Name { set; get; }
        public string Food { set; get; }
        [Required]
        [StringLength(50)]
        [Index("Animal_Origin")]
        public string Origin { set; get; }
        public int Quantity { set; get; }
        public virtual ICollection<AnimalFood> AnimalFoods { set; get; }
    }
}
