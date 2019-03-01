using SuperHeroProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperHeroProject.Controllers
{
    public class SuperHeroController : Controller
    {
        ApplicationDbContext db;
        // GET: SuperHero
        public SuperHeroController()
        {
            db = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var displayAll = db.SuperHeroes.Select(s => s);
            return View(displayAll);
        }

        // GET: SuperHero/Details/5
        public ActionResult Details(int id)
        {
            var foundHero = db.SuperHeroes.Where(s => s.ID == id).FirstOrDefault();
            return View(foundHero);
        }

        // GET: SuperHero/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SuperHero/Create
        [HttpPost]
        public ActionResult Create(SuperHero superhero)
        {
            try
            {
                db.SuperHeroes.Add(superhero);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHero/Edit/5
        public ActionResult Edit(int id)
        {
            var foundHero = db.SuperHeroes.Where(s => s.ID == id).FirstOrDefault();
            return View(foundHero);
        }

        // POST: SuperHero/Edit/5
        [HttpPost]
        public ActionResult Edit(int id , SuperHero superhero)
        {
            try
            {
                var foundHero = db.SuperHeroes.Where(s => s.ID == id).FirstOrDefault();
                foundHero.Name = superhero.Name;
                foundHero.AlterEgoName = superhero.AlterEgoName;
                foundHero.PrimaryAbility = superhero.PrimaryAbility;
                foundHero.SecondaryAbility = superhero.SecondaryAbility;
                foundHero.CatchPhrase = superhero.CatchPhrase;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHero/Delete/5
        public ActionResult Delete(int id)
        {
            var foundHero = db.SuperHeroes.Where(s => s.ID == id).FirstOrDefault();
            return View(foundHero);
        }

        // POST: SuperHero/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, SuperHero superHero)
        {
            try
            {
               db.SuperHeroes.Remove(superHero);
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
