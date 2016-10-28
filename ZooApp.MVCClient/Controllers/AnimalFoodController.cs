using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ZooApp.Models;
using ZooApp.ViewModel;

namespace ZooApp.MVCClient.Controllers
{
    public class AnimalFoodController : Controller
    {
        private ZooContext db = new ZooContext();

        // GET: /AnimalFood/
        public ActionResult Index()
        {
            var animalfoods = db.AnimalFoods.Include(a => a.Animal).Include(a => a.Food);
            List<ViewFoodTotal> totals=new List<ViewFoodTotal>();
            foreach (AnimalFood animalFood in animalfoods)
            {
                ViewFoodTotal foodTotal=new ViewFoodTotal(animalFood);
                totals.Add(foodTotal);
            }
            return View(totals);
        }

        // GET: /AnimalFood/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnimalFood animalfood = db.AnimalFoods.Find(id);
            if (animalfood == null)
            {
                return HttpNotFound();
            }
            return View(animalfood);
        }

        // GET: /AnimalFood/Create
        public ActionResult Create()
        {
            ViewBag.AnimalId = new SelectList(db.Animals, "Id", "Name");
            ViewBag.FoodId = new SelectList(db.Foods, "Id", "Name");
            return View();
        }

        // POST: /AnimalFood/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,AnimalId,FoodId,Quantity")] AnimalFood animalfood)
        {
            if (ModelState.IsValid)
            {
                db.AnimalFoods.Add(animalfood);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AnimalId = new SelectList(db.Animals, "Id", "Name", animalfood.AnimalId);
            ViewBag.FoodId = new SelectList(db.Foods, "Id", "Name", animalfood.FoodId);
            return View(animalfood);
        }

        // GET: /AnimalFood/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnimalFood animalfood = db.AnimalFoods.Find(id);
            if (animalfood == null)
            {
                return HttpNotFound();
            }
            ViewBag.AnimalId = new SelectList(db.Animals, "Id", "Name", animalfood.AnimalId);
            ViewBag.FoodId = new SelectList(db.Foods, "Id", "Name", animalfood.FoodId);
            return View(animalfood);
        }

        // POST: /AnimalFood/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,AnimalId,FoodId,Quantity")] AnimalFood animalfood)
        {
            if (ModelState.IsValid)
            {
                db.Entry(animalfood).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AnimalId = new SelectList(db.Animals, "Id", "Name", animalfood.AnimalId);
            ViewBag.FoodId = new SelectList(db.Foods, "Id", "Name", animalfood.FoodId);
            return View(animalfood);
        }

        // GET: /AnimalFood/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnimalFood animalfood = db.AnimalFoods.Find(id);
            if (animalfood == null)
            {
                return HttpNotFound();
            }
            return View(animalfood);
        }

        // POST: /AnimalFood/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AnimalFood animalfood = db.AnimalFoods.Find(id);
            db.AnimalFoods.Remove(animalfood);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
