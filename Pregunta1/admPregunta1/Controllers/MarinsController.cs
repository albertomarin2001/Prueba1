using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using admPregunta1.Models;

namespace admPregunta1.Controllers
{
    public class MarinsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Marins
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Marins.ToList());
        }

        // GET: Marins/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marin marin = db.Marins.Find(id);
            if (marin == null)
            {
                return HttpNotFound();
            }
            return View(marin);
        }

        // GET: Marins/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Marins/Create
        [Authorize]
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "marinID,FriendofMarin,place,Email,Birthdate")] Marin marin)
        {
            if (ModelState.IsValid)
            {
                db.Marins.Add(marin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(marin);
        }

        // GET: Marins/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marin marin = db.Marins.Find(id);
            if (marin == null)
            {
                return HttpNotFound();
            }
            return View(marin);
        }

        // POST: Marins/Edit/5
        [Authorize]
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "marinID,FriendofMarin,place,Email,Birthdate")] Marin marin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(marin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(marin);
        }

        // GET: Marins/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marin marin = db.Marins.Find(id);
            if (marin == null)
            {
                return HttpNotFound();
            }
            return View(marin);
        }

        // POST: Marins/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Marin marin = db.Marins.Find(id);
            db.Marins.Remove(marin);
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
