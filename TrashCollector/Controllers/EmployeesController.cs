using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class EmployeesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //GET: Employees
        public ActionResult Index(string inputDate)
        {
            var employeeId = User.Identity.GetUserId();
            var employee = db.Employees.Where(e => e.ApplicationId == employeeId).Single();
            string dayOfWeek = DateTime.Now.DayOfWeek.ToString();


            //var customer = db.Customers.Where(c => c.ApplicationId == User.Identity.GetUserId()).Single();
            //if(customer.SuspendPickupStart == DateTime.Now.ToString())
            //{

            //}
            //var endCompare = 
            //if startCompare(){
            //    cusomter.PickupStatus = false;
            //}


            if (inputDate == null)
            {
                return View(db.Customers.Where(c => c.PickupStatus == true && c.AreaCode == employee.AreaCode && c.PickupDay == dayOfWeek || c.PickupStatus == true && c.AreaCode == employee.AreaCode && c.OneTimePickupDay == dayOfWeek).ToList());
            }
            else
            {
                return View(db.Customers.Where(c => c.PickupStatus == true && c.AreaCode == employee.AreaCode && c.PickupDay == inputDate || c.PickupStatus == true && c.AreaCode == employee.AreaCode && c.OneTimePickupDay == inputDate).ToList());
            }
        }

        public ActionResult CustomerIndex()
        {
            var employeeId = User.Identity.GetUserId();
            var employee = db.Employees.Where(e => e.ApplicationId == employeeId).Single();
            string dayOfWeek = DateTime.Now.DayOfWeek.ToString();
            var customers = db.Customers.Where(c => c.PickupStatus == true && c.AreaCode == employee.AreaCode && c.PickupDay == dayOfWeek || c.PickupStatus == true && c.AreaCode == employee.AreaCode && c.OneTimePickupDay == dayOfWeek);
            return View(customers);
        }

        public ActionResult CustomerIndexFilter()
        {
            var employeeId = User.Identity.GetUserId();
            var employee = db.Employees.Where(e => e.ApplicationId == employeeId).Single();
            string dayOfWeek = "Monday";
            var customers = db.Customers.Where(c => c.PickupStatus == true && c.AreaCode == employee.AreaCode && c.PickupDay == dayOfWeek || c.PickupStatus == true && c.AreaCode == employee.AreaCode && c.OneTimePickupDay == dayOfWeek);
            return View(customers);
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,AreaCode")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.ApplicationId = User.Identity.GetUserId();
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,AreaCode")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
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
