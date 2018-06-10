using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sampe.Models;

namespace Sampe.Controllers
{
    public class CoresController : Controller
    {
        private SampeContext db = new SampeContext();

        // GET: Cores
        public ActionResult Index()
        {
            return View(db.Cors.ToList());
        }

        // GET: Cores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cor cor = db.Cors.Find(id);
            if (cor == null)
            {
                return HttpNotFound();
            }
            return View(cor);
        }

        // GET: Cores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cores/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CorId,NomeCor")] Cor cor)
        {
            if (ModelState.IsValid)
            {
                db.Cors.Add(cor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cor);
        }

        // GET: Cores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cor cor = db.Cors.Find(id);
            if (cor == null)
            {
                return HttpNotFound();
            }
            return View(cor);
        }

        // POST: Cores/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CorId,NomeCor")] Cor cor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cor);
        }

        // GET: Cores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cor cor = db.Cors.Find(id);
            if (cor == null)
            {
                return HttpNotFound();
            }
            return View(cor);
        }

        // POST: Cores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cor cor = db.Cors.Find(id);
            db.Cors.Remove(cor);
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
