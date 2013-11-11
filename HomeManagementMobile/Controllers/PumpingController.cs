using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeManagement.Domain;
using HomeManagement.DataLayer;
using HomeManagementMobile.Models;

namespace HomeManagementMobile.Controllers
{
    public class PumpingController : Controller
    {
        private HomeManagementContext db = new HomeManagementContext();

        //
        // GET: /Pumping/

        public ActionResult Index()
        {
            var pumpingsViewModels = from pumping in db.Pumpings.ToArray()
                                     select new PumpingViewModel(pumping);
            return View(pumpingsViewModels);
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

            var pumpingViewModle = new PumpingViewModel(pumping);

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
        public ActionResult Create(PumpingViewModel pumping)
        {
            if (ModelState.IsValid)
            {
                db.Pumpings.Add(pumping.ToPumping());
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
            return View(new PumpingViewModel(pumping));
        }

        //
        // POST: /Pumping/Edit/5

        [HttpPost]
        public ActionResult Edit(PumpingViewModel pumping, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pumping.ToPumping()).State = EntityState.Modified;
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
            return View(new PumpingViewModel(pumping));
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