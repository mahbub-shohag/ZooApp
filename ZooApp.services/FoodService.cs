using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooApp.Models;
using ZooApp.ViewModel;

namespace ZooApp.services
{
    public class FoodService
    {
        ZooContext db = new ZooContext();
        public List<ViewFood> GetAll()
        {

            List<Food> foods = db.Foods.ToList();
            List<ViewFood> viewFoods = new List<ViewFood>();
            foreach (Food food in foods)
            {
                ViewFood viewFood = new ViewFood()
                {
                    Id = food.Id,
                  
                    Name = food.Name
                };
                viewFoods.Add(viewFood);
            }
            return viewFoods;


        }

        public object Get(int Id)
        {
            Food food = db.Foods.Find(Id);
            return new ViewFood

            {
                Id = food.Id,

                Name = food.Name
            };
        }

        public bool Save(Food food)
        {
            var result = db.Foods.Add(food);
            db.SaveChanges();
            return true;
        }

        public bool Update(Food food)
        {
            db.Entry(food).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }

        public Food GetDbModel(int id)
        {
            Food food = db.Foods.Find(id);
            return food;
        }

        public bool Delete(Food food)
        {
            Food dbFood = db.Foods.Find(food.Id);
            db.Foods.Remove(dbFood);
            db.SaveChanges();
            return true;
        }
    }
}
