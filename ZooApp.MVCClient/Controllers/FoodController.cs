using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ZooApp.Models;
using ZooApp.services;

namespace ZooApp.MVCClient.Controllers
{
    public class FoodController : Controller
    {
        //
        // GET: /Food/
    FoodService service = new FoodService();
        public ActionResult Index()
        {

            var viewFoods = service.GetAll();

            return View(viewFoods);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Food food)
        {
            bool saved = service.Save(food);
            if (saved)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Create");
        }


        public ActionResult Edit(int id)
        {
            Food food = service.GetDbModel(id);
            return View(food);
        }
        [HttpPost]
        public ActionResult Edit(Food food)
        {
            bool update = service.Update(food);
            if (update)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Edit");
        }
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food food = service.GetDbModel(id);
            if (food == null)
            {
                return HttpNotFound();
            }
            return View(food);
           
        }

        [HttpPost]
        public ActionResult Delete(Food food)
        {
            bool delete = service.Delete(food);
            if (delete)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
      
	}
}