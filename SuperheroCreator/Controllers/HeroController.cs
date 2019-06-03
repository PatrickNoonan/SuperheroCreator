using SuperheroCreator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperheroCreator.Controllers
{
    public class HeroController : Controller
    {
        ApplicationDbContext context;
        public HeroController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Hero
        public ActionResult Index()
        {
            List<Hero>heroList = context.Heroes.ToList<Hero>();
            return View(heroList);
        }

        // GET: Hero/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hero hero = context.Heroes.Find(id);
            if (hero == null)
            {
                return HttpNotFound();
            }
            return View(hero);
        }

        // GET: Hero/Create
        public ActionResult Create()
        {
            Hero hero = new Hero();
            return View(hero);
        }

        // POST: Hero/Create
        [HttpPost]
        public ActionResult Create(Hero hero)
        {
            try
            {
                // TODO: Add insert logic here
                //create application dbcontext, create user and pass it to the database
                context.Heroes.Add(hero);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: Hero/Edit/5
        public ActionResult Edit(int id)
        {
            Hero hero = context.Heroes.Find(id);
            return View(hero);
        }

        // POST: Hero/Edit/5
        [AcceptVerbs(HttpVerbs.Post)]
        [HttpPost]
        public ActionResult Edit(int id, FormCollection formValues)
        {
            try
            {
                // TODO: Add update logic here
                Hero hero = context.Heroes.Find(id);
                UpdateModel(hero);

                context.SaveChanges();

                return RedirectToAction("Details", new { id = hero.Id });
            }
            catch
            {
                return View();
            }
        }

        // GET: Hero/Delete/5
        public ActionResult Delete(int? id)
        {
            //Hero foundHero = context.Heroes.Find(id);
            //return View(foundHero);
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hero hero = context.Heroes.Find(id);
            if (hero == null)
            {
                return HttpNotFound();
            }
            return View(hero);
        }

        // POST: Hero/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                // TODO: Add delete logic here
                Hero hero = context.Heroes.Find(id);
                context.Heroes.Remove(hero);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }
    }
}
