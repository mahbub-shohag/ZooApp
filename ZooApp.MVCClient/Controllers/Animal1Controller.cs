using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZooApp.Models;
using ZooApp.services;
namespace ZooApp.MVCClient.Controllers
{
    public class Animal1Controller : Controller
    {
        //
        // GET: /Animal1/
        AnimalService service = new AnimalService();
        public ActionResult Index()
        {
            
            var viewAnimals = service.Get();

            return View(viewAnimals);
        }
        public ActionResult Details(int Id)
        {

            var animal = service.Get(Id);

            return View(animal);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Animal animal)
        {
            bool saved = service.Save(animal);
            if (saved)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Create");
        }

        public ActionResult Edit(int id)
        {
            Animal animal =service.GetDbModel(id);
            return View(animal);
        }
        [HttpPost]
        public ActionResult Edit(Animal animal)
        {
            bool update = service.Update(animal);
            if (update)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Edit");
        }

        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(Animal animal)
        {
            bool delete = service.Delete(animal);
            if (delete)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
      

	}
}