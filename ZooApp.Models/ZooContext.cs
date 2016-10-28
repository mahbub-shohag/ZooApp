using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooApp.Models
{
   public class ZooContext :DbContext
    {
        public ZooContext() :base("ZooContext")
        {
            
        }
        public DbSet<Animal> Animals { set; get; }
        public DbSet<Food> Foods { set; get; }

        public System.Data.Entity.DbSet<ZooApp.Models.AnimalFood> AnimalFoods { get; set; }
       
    }
}
