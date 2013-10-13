using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeManagement.DataLayer;
using HomeManagement.Domain;
using System.Data;

namespace HomeManagementUi.Controllers
{
    public class PumpingController : Controller
    {
        //
        // GET: /Pumping/

        public ActionResult Index()
        {
            var context = new HomeManagementContext();
            return View(context.Pumpings.ToArray());
        }

        [HttpGet]
        public ActionResult Create()
        {
            var pumping = new Pumping
            {
                PumpingTimes = new[]
                {
                    new PumpingTime
                    {
                        StartTime = DateTime.Now
                    }
                }
            };
            return View(pumping);
        }

        [HttpPost]
        public ActionResult Create(Pumping pumping, bool save = true)
        {
            if (save)
            {
                var context = new HomeManagementContext();

                context.Pumpings.Add(pumping);
                context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(pumping);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var context = new HomeManagementContext();

            return View(context.Pumpings.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(Pumping pumping, bool save = true)
        {
            if (save)
            {
                var context = new HomeManagementContext();

                context.Entry<Pumping>(pumping).State = EntityState.Modified;
                context.SaveChanges();

                return RedirectToAction("Index");
            }

            pumping.PumpingTimes.Add(new PumpingTime());
            return View(pumping);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var context = new HomeManagementContext();

            return View(context.Pumpings.Find(id));
        }

        [HttpPost]
        public ActionResult Delete(Pumping pumping)
        {
            var context = new HomeManagementContext();

            context.Entry<Pumping>(pumping).State = EntityState.Modified;
            context.Pumpings.Remove(pumping);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
