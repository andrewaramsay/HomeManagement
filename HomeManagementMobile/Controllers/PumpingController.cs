using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeManagement.Domain;
using HomeManagement.DataLayer;

namespace HomeManagementMobile.Controllers
{
    public class PumpingController : Controller
    {
        private HomeManagementContext db = new HomeManagementContext();

        //
        // GET: /Pumping/

        public ActionResult Index()
        {
            return View(db.Pumpings.ToList());
        }

        //
        // GET: /Pumping/Details/5

        public ActionResult Details(int id = 0)
        {
            Pumping pumping = db.Pumpings.Find(id);
            if (pumping == null)
            {
                return HttpNotFound();
            }
            return View(pumping);
        }

        //
        // GET: /Pumping/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Pumping/Create

        [HttpPost]
        public ActionResult Create(Pumping pumping)
        {
            if (ModelState.IsValid)
            {
                db.Pumpings.Add(pumping);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pumping);
        }

        //
        // GET: /Pumping/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Pumping pumping = db.Pumpings.Find(id);
            if (pumping == null)
            {
                return HttpNotFound();
            }
            return View(pumping);
        }

        //
        // POST: /Pumping/Edit/5

        [HttpPost]
        public ActionResult Edit(Pumping pumping, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pumping).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pumping);
        }

        //
        // GET: /Pumping/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Pumping pumping = db.Pumpings.Find(id);
            if (pumping == null)
            {
                return HttpNotFound();
            }
            return View(pumping);
        }

        //
        // POST: /Pumping/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Pumping pumping = db.Pumpings.Find(id);
            db.Pumpings.Remove(pumping);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}