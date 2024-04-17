using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRUD_operation.Models;

namespace CRUD_operation.Controllers
{
    public class Railways_DetailsController : Controller
    {
        private sqlserverconceptsEntities1 db = new sqlserverconceptsEntities1();

        // GET: Railways_Details
        public ActionResult Index()
        {
            return View(db.Railways_Details.ToList());
        }

        // GET: Railways_Details/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Railways_Details railways_Details = db.Railways_Details.Find(id);
            if (railways_Details == null)
            {
                return HttpNotFound();
            }
            return View(railways_Details);
        }

        // GET: Railways_Details/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Railways_Details/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "pnrnumber,passname,dateoftravel,source,destination,ticketprice")] Railways_Details railways_Details)
        {
            if (ModelState.IsValid)
            {
                db.Railways_Details.Add(railways_Details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(railways_Details);
        }

        // GET: Railways_Details/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Railways_Details railways_Details = db.Railways_Details.Find(id);
            if (railways_Details == null)
            {
                return HttpNotFound();
            }
            return View(railways_Details);
        }

        // POST: Railways_Details/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "pnrnumber,passname,dateoftravel,source,destination,ticketprice")] Railways_Details railways_Details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(railways_Details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(railways_Details);
        }

        // GET: Railways_Details/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Railways_Details railways_Details = db.Railways_Details.Find(id);
            if (railways_Details == null)
            {
                return HttpNotFound();
            }
            return View(railways_Details);
        }

        // POST: Railways_Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Railways_Details railways_Details = db.Railways_Details.Find(id);
            db.Railways_Details.Remove(railways_Details);
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
