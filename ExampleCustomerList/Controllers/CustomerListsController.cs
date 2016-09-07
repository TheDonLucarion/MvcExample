using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Customers.Data;
using Customers.Models;

namespace ExampleCustomerList.Controllers
{
    public class CustomerListsController : Controller
    {
        private CustomerDbContext db = new CustomerDbContext();

        // GET: CustomerLists
        public ActionResult Index()
        {
            return View(db.CustomerList.ToList());
        }

        // GET: CustomerLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerList customerList = db.CustomerList.Find(id);
            if (customerList == null)
            {
                return HttpNotFound();
            }
            return View(customerList);
        }

        // GET: CustomerLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName")] CustomerList customerList)
        {
            if (ModelState.IsValid)
            {
                db.CustomerList.Add(customerList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customerList);
        }

        // GET: CustomerLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerList customerList = db.CustomerList.Find(id);
            if (customerList == null)
            {
                return HttpNotFound();
            }
            return View(customerList);
        }

        // POST: CustomerLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName")] CustomerList customerList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customerList);
        }

        // GET: CustomerLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerList customerList = db.CustomerList.Find(id);
            if (customerList == null)
            {
                return HttpNotFound();
            }
            return View(customerList);
        }

        // POST: CustomerLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerList customerList = db.CustomerList.Find(id);
            db.CustomerList.Remove(customerList);
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
