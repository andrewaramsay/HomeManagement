using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeManagement.Domain;
using HomeManagement.DataLayer;
using HomeManagement.Web.Models;

namespace HomeManagement.Web.Controllers
{
    public class PumpingController : Controller
    {
        private HomeManagementContext db = new HomeManagementContext();

        //
        // GET: /Pumping/

        public ActionResult Index()
        {
            var pumpingsViewModels = from pumping in db.Pumpings.ToArray()
                                     orderby pumping.StartTime descending
                                     select new PumpingViewModel(pumping);
            return View(pumpingsViewModels);
        }

        //
        // GET: /Pumping/Create

        public ActionResult Create()
        {
            ViewBag.Title = "Create Pumping";
            ViewBag.SubmitButtonText = "Create";
            ViewBag.EmitModelId = false;
            return View("Edit");
        }

        //
        // POST: /Pumping/Create

        [HttpPost]
        public ActionResult Create(PumpingViewModel pumping)
        {
            ViewBag.Title = "Create Pumping";
            ViewBag.SubmitButtonText = "Create";
            ViewBag.EmitModelId = false;
            if (ModelState.IsValid)
            {
                db.Pumpings.Add(pumping.ToPumping());
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Edit", pumping);
        }

        //
        // GET: /Pumping/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ViewBag.Title = "Edit Pumping";
            ViewBag.SubmitButtonText = "Save";
            ViewBag.EmitModelId = true;
            var pumping = db.Pumpings.Find(id);
            if (pumping == null)
            {
                return HttpNotFound();
            }
            return View("Edit", new PumpingViewModel(pumping));
        }

        //
        // POST: /Pumping/Edit/5

        [HttpPost]
        public ActionResult Edit(PumpingViewModel pumping, FormCollection collection)
        {
            ViewBag.Title = "Edit Pumping";
            ViewBag.SubmitButtonText = "Save";
            ViewBag.EmitModelId = true;
            if (ModelState.IsValid)
            {
                db.Entry(pumping.ToPumping()).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Edit", pumping);
        }

        public ActionResult Delete(int id)
        {
            var pumping = db.Pumpings.Find(id);
            if (pumping == null)
            {
                return HttpNotFound();
            }

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