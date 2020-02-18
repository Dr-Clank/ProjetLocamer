using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplicationLocamerLDeMOg.Models;

namespace WebApplicationLocamerLDeMOg.Controllers
{
    public class SejoursController : Controller
    {
        private LocamerMOgEntities db = new LocamerMOgEntities();

        // GET: Sejours
        public ActionResult Index()
        {
            var sejour = db.Sejour.Include(s => s.Categorie).Include(s => s.Client);
            return View(sejour.ToList());
        }

        // GET: Sejours/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sejour sejour = db.Sejour.Find(id);
            if (sejour == null)
            {
                return HttpNotFound();
            }
            return View(sejour);
        }

        // GET: Sejours/Create
        public ActionResult Create()
        {
            ViewBag.idCate = new SelectList(db.Categorie, "idCate", "libelleCate");
            ViewBag.idCli = new SelectList(db.Client, "idCli", "nom");
            return View();
        }

        // POST: Sejours/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idSejour,dateDebut,dateFin,idCli,idCate")] Sejour sejour)
        {
            if (ModelState.IsValid)
            {
                db.Sejour.Add(sejour);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCate = new SelectList(db.Categorie, "idCate", "libelleCate", sejour.idCate);
            ViewBag.idCli = new SelectList(db.Client, "idCli", "nom", sejour.idCli);
            return View(sejour);
        }

        // GET: Sejours/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sejour sejour = db.Sejour.Find(id);
            if (sejour == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCate = new SelectList(db.Categorie, "idCate", "libelleCate", sejour.idCate);
            ViewBag.idCli = new SelectList(db.Client, "idCli", "nom", sejour.idCli);
            return View(sejour);
        }

        // POST: Sejours/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idSejour,dateDebut,dateFin,idCli,idCate")] Sejour sejour)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sejour).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCate = new SelectList(db.Categorie, "idCate", "libelleCate", sejour.idCate);
            ViewBag.idCli = new SelectList(db.Client, "idCli", "nom", sejour.idCli);
            return View(sejour);
        }

        // GET: Sejours/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sejour sejour = db.Sejour.Find(id);
            if (sejour == null)
            {
                return HttpNotFound();
            }
            return View(sejour);
        }

        // POST: Sejours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sejour sejour = db.Sejour.Find(id);
            db.Sejour.Remove(sejour);
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
