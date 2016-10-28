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
    public class AnimalService
    {
        ZooContext db = new ZooContext();
        public List<ViewAnimal> Get()
        {
            
            List<Animal> animals =db.Animals.ToList();
            List<ViewAnimal> viewAnimals=new List<ViewAnimal>();
            foreach (Animal animal in animals)
            {
                ViewAnimal viewAnimal = new ViewAnimal()
                {
                    Id = animal.Id,
                    Quantity = animal.Quantity,
                    Origin = animal.Origin,
                    Name = animal.Name
                };
                viewAnimals.Add(viewAnimal);
            }
            return viewAnimals;


        }

        public object Get(int Id)
        {
            Animal animal =db.Animals.Find(Id);
            return new ViewAnimal
            {
           
                Origin = animal.Origin,
                Quantity = animal.Quantity,
                Name = animal.Name,
                Id = animal.Id
            };
        }

        public bool Save(Animal animal)
        {
            var result=db.Animals.Add(animal);
            db.SaveChanges();
            return true;
        }

        public bool Update(Animal animal)
        {
            db.Entry(animal).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }

        public Animal GetDbModel(int id)
        {
            Animal animal=db.Animals.Find(id);
            return animal;
        }

        public bool Delete(Animal animal)
        {
            Animal dbAnimal = db.Animals.Find(animal.Id);
            db.Animals.Remove(dbAnimal);
            db.SaveChanges();
            return true;
        }
    }
}
