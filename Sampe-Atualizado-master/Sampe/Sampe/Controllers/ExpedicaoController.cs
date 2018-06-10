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
    public class ExpedicaoController : Controller
    {
        private SampeContext db = new SampeContext();

        // GET: Expedicao
        public ActionResult Index()
        {
            var expedicaos = db.Expedicaos.Include(e => e.Cliente).Include(e => e.Marcanti).Include(e => e.OrdemProducaoCopo).Include(e => e.OrdemProducaoKit);
            return View(expedicaos.ToList());
        }

        // GET: Expedicao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expedicao expedicao = db.Expedicaos.Find(id);
            if (expedicao == null)
            {
                return HttpNotFound();
            }
            return View(expedicao);
        }

        [Authorize(Roles = "Acesso Total, Acesso Administrador")]
        // GET: Expedicao/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "NomeCliente");
            ViewBag.MarcantiId = new SelectList(db.Marcantis, "MarcantiId", "NomeEmpresa");
            ViewBag.OrdemProducaoCopoId = new SelectList(db.OrdemProducaoCopoes, "OrdemProducaoCopoId", "Cor");
            ViewBag.CodigoIdentificadorKit = new SelectList(db.OrdemProducaoKits, "CodigoIdentificadorKit", "CodigoIdentificadorKit");
            return View();
        }

        // POST: Expedicao/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExpedicaoId,Quantidade,ValorTotal,Vencimento,ClienteId,MarcantiId,CodigoIdentificadorKit,OrdemProducaoCopoId,ValorUnitario,Subtotal")] Expedicao expedicao)
        {
            
            if (ModelState.IsValid)
            {
                expedicao.CalcSubtotal(expedicao.ValorUnitario, expedicao.Quantidade);
                expedicao.CalcValorTotal(expedicao.Subtotal);
                db.Expedicaos.Add(expedicao);                
                db.SaveChanges();                
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "NomeCliente", expedicao.ClienteId);
            ViewBag.MarcantiId = new SelectList(db.Marcantis, "MarcantiId", "NomeEmpresa", expedicao.MarcantiId);
            ViewBag.OrdemProducaoCopoId = new SelectList(db.OrdemProducaoCopoes, "OrdemProducaoCopoId", "Cor", expedicao.OrdemProducaoCopoId);
            ViewBag.CodigoIdentificadorKit = new SelectList(db.OrdemProducaoKits, "CodigoIdentificadorKit", "CodigoIdentificadorKit", expedicao.CodigoIdentificadorKit);
            return View(expedicao);
        }

        // GET: Expedicao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expedicao expedicao = db.Expedicaos.Find(id);
            if (expedicao == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "NomeCliente", expedicao.ClienteId);
            ViewBag.MarcantiId = new SelectList(db.Marcantis, "MarcantiId", "NomeEmpresa", expedicao.MarcantiId);
            ViewBag.OrdemProducaoCopoId = new SelectList(db.OrdemProducaoCopoes, "OrdemProducaoCopoId", "Cor", expedicao.OrdemProducaoCopoId);
            ViewBag.CodigoIdentificadorKit = new SelectList(db.OrdemProducaoKits, "CodigoIdentificadorKit", "CodigoIdentificadorKit", expedicao.CodigoIdentificadorKit);
            return View(expedicao);
        }

        // POST: Expedicao/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExpedicaoId,Quantidade,ValorTotal,Vencimento,ClienteId,MarcantiId,CodigoIdentificadorKit,OrdemProducaoCopoId")] Expedicao expedicao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expedicao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "NomeCliente", expedicao.ClienteId);
            ViewBag.MarcantiId = new SelectList(db.Marcantis, "MarcantiId", "NomeEmpresa", expedicao.MarcantiId);
            ViewBag.OrdemProducaoCopoId = new SelectList(db.OrdemProducaoCopoes, "OrdemProducaoCopoId", "Cor", expedicao.OrdemProducaoCopoId);
            ViewBag.CodigoIdentificadorKit = new SelectList(db.OrdemProducaoKits, "CodigoIdentificadorKit", "CodigoIdentificadorKit", expedicao.CodigoIdentificadorKit);
            return View(expedicao);
        }

        // GET: Expedicao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expedicao expedicao = db.Expedicaos.Find(id);
            if (expedicao == null)
            {
                return HttpNotFound();
            }
            return View(expedicao);
        }

        // POST: Expedicao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Expedicao expedicao = db.Expedicaos.Find(id);
            db.Expedicaos.Remove(expedicao);
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
