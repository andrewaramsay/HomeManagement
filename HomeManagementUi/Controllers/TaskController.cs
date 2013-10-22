using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeManagement.Domain;
using HomeManagement.DataLayer;
using System.Data.Entity.Validation;

namespace HomeManagementUi.Controllers
{
    public class TaskController : Controller
    {
        private readonly HomeManagementContext _db = new HomeManagementContext();

        //
        // GET: /Task/

        public ViewResult Index(bool showCompleted = false)
        {
            ViewBag.ShowingCompleted = showCompleted;
            ViewBag.MaxDescriptionLength = 35;
            var tasks = _db.Tasks.Include(t => t.Person).Where(t => !t.Completed || showCompleted);
            return View(tasks.ToList());
        }

        //
        // GET: /Task/Details/5

        public ViewResult Details(int id)
        {
            var task = _db.Tasks.Find(id);
            return View(task);
        }

        //
        // GET: /Task/Create

        public ActionResult Create()
        {
            ViewBag.PersonId = new SelectList(_db.People, "Id", "Name");
            var task = new Task
            {
                DateEntered = DateTime.Now
            };
            return View(task);
        }

        //
        // POST: /Task/Create

        [HttpPost]
        public ActionResult Create(Task task)
        {
            if (ModelState.IsValid)
            {
                if (task.PersonId != null && task.DateAssigned == null)
                    task.DateAssigned = DateTime.Now;

                _db.Tasks.Add(task);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonId = new SelectList(_db.People, "Id", "Name");
            return View(task);
        }

        //
        // GET: /Task/Edit/5

        public ActionResult Edit(int id)
        {
            var task = _db.Tasks.Find(id);
            if (task.DateCompleted != null)
                return RedirectToAction("Details", new { id = id });

            ViewBag.PersonId = new SelectList(_db.People, "Id", "Name", task.PersonId);
            return View(task);
        }

        //
        // POST: /Task/Edit/5

        [HttpPost]
        public ActionResult Edit(Task task)
        {


            if (ModelState.IsValid)
            {
                if (task.Completed)
                    task.DateCompleted = DateTime.Now;

                if (task.PersonId != null && task.DateAssigned == null)
                    task.DateAssigned = DateTime.Now;

                _db.Entry(task).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonId = new SelectList(_db.People, "Id", "Name");
            return View(task);

        }

        //
        // GET: /Task/Delete/5

        public ActionResult Delete(int id)
        {
            Task task = _db.Tasks.Find(id);
            return View(task);
        }

        //
        // POST: /Task/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Task task = _db.Tasks.Find(id);
            _db.Tasks.Remove(task);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}