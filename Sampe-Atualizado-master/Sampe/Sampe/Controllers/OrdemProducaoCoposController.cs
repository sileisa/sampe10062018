﻿using System;
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
    public class OrdemProducaoCoposController : Controller
    {
        private SampeContext db = new SampeContext();

        // GET: OrdemProducaoCopos
        public ActionResult Index()
        {
            var ordemProducaoCopoes = db.OrdemProducaoCopoes.Include(o => o.Expectativa);
            return View(ordemProducaoCopoes.ToList());
        }

        // GET: OrdemProducaoCopos/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdemProducaoCopo ordemProducaoCopo = db.OrdemProducaoCopoes.Find(id);
            if (ordemProducaoCopo == null)
            {
                return HttpNotFound();
            }
            return View(ordemProducaoCopo);
        }

        // GET: OrdemProducaoCopos/Create
        public ActionResult Create()
        {
			ViewBag.MaquinaId = db.Maquinas.ToList();
			ViewBag.CorId = new SelectList(db.Cors, "CorId", "NomeCor");
			ViewBag.ExpectativaId = new SelectList(db.Expectativas, "ExpectativaId", "Produto");
            return View();
        }

        // POST: OrdemProducaoCopos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodigoIdentificador,MaquinaId,ExpectativaId,OPnoMes,Data,MateriaPrima,MPLote,MPConsumo,ProdIncio,ProdFim,TempAgua,NivelOleo,RefugoKg,TotalProduzidos,ContadorInicial,ContadorFinal,Status")] OrdemProducaoCopo ordemProducaoCopo, int MaquinaId)
        {
			var a = Request.Form["CorId"];
			var b = Request.Form["EspecificacaoCopo.UniProd"];
			var c = Request.Form["EspecificacaoCopo.LoteMaster"];

			var d = Request.Form["ParadaCopo.HoraParada"];
			var e = Request.Form["ParadaCopo.HoraRetorno"];
			var f = Request.Form["Motivo"];
			var g = Request.Form["ParadaCopo.Observacoes"];

			var h = Request.Form["Hora"];
			var i = Request.Form["ControleDeQualidadeCopo.Ciclo"];
			var j = Request.Form["ControleDeQualidadeCopo.PesoDaPeca"];
			var k = Request.Form["ControleDeQualidadeCopo.PesoDaPeca2"];
			List<string> peso1 = new List<string>(Request.Form.GetValues("ControleDeQualidadeCopo.Peso"));
			List<string> cor1 = new List<string>(Request.Form.GetValues("ControleDeQualidadeCopo.Cor"));
			List<string> dim = new List<string>(Request.Form.GetValues("ControleDeQualidadeCopo.Dimensao"));
			var l = Request.Form["Assinatura"];

			if (ModelState.IsValid)
            {
				var qtdOp = 0;
				var mesAnterior = 0;
				if (db.OrdemProducaoKits.Count() > 0)
				{
					qtdOp = db.OrdemProducaoKits.ToList().Last().OPnoMes;
					mesAnterior = db.OrdemProducaoKits.ToList().Last().Data.Month;
				}
				else
				{
					qtdOp = 0;
					mesAnterior = 0;
				}
				if (mesAnterior != ordemProducaoCopo.Data.Month)
				{
					ordemProducaoCopo.OPnoMes = 1;
				}
				else
					ordemProducaoCopo.OPnoMes = qtdOp + 1;

				ordemProducaoCopo.GerarCodigo();

				if (a != null)
				{
					var cor = a.Split(',').Select(Int32.Parse).ToArray();
					var quant = b.Split(',').Select(Int32.Parse).ToArray();
					var lote = c.Split(',');
					List<EspecificacaoCopo> esp = new List<EspecificacaoCopo>();
					for (int x = 0; x < cor.Count(); x++)
					{
						EspecificacaoCopo e1 = new EspecificacaoCopo();
						e1.CorId = cor[x];
						e1.UniProd = quant[x];
						e1.LoteMaster = lote[x];
						e1.OrdemProducaoCopoId = ordemProducaoCopo.CodigoIdentificador;
						esp.Add(e1);
					}
					ordemProducaoCopo.EspecificacoesCopo = esp;
				}

				if (d != null)
				{
					var hrP = d.Split(',');
					var hrR = e.Split(',');
					var mot = f.Split(',');
					var obs = g.Split(',');

					List<ParadaCopo> parada = new List<ParadaCopo>();
					for (int y = 0; y < hrP.Count(); y++)
					{
						ParadaCopo p = new ParadaCopo();
						p.HoraParada = hrP[y];
						p.HoraRetorno = hrR[y];
						p.Motivo = mot[y];
						p.Observacoes = obs[y];
						p.OrdemProducaoCopoId = ordemProducaoCopo.CodigoIdentificador;
						parada.Add(p);
					}
					ordemProducaoCopo.ParadasCopo = parada;
				}
				if (h != null)
				{
					var hora = h.Split(',');
					var ciclo = i.Split(',').Select(float.Parse).ToArray();
					var pesoPeca = j.Split(',').Select(float.Parse).ToArray();
					var pesoPeca2 = k.Split(',').Select(float.Parse).ToArray();

					peso1 = ordemProducaoCopo.RemoveExtraFalseFromCheckbox(peso1);
					bool[] peso = peso1.Select(Boolean.Parse).ToArray();

					cor1 = ordemProducaoCopo.RemoveExtraFalseFromCheckbox(cor1);
					bool[] cor = cor1.Select(Boolean.Parse).ToArray();

					dim = ordemProducaoCopo.RemoveExtraFalseFromCheckbox(dim);
					bool[] dimensao = dim.Select(Boolean.Parse).ToArray();

					var assinatura = l.Split(',').Select(Int32.Parse).ToArray();

					List<ControleDeQualidadeCopo> ctrlQual = new List<ControleDeQualidadeCopo>();
					for (int x = 0; x < hora.Count(); x++)
					{
						ControleDeQualidadeCopo c1 = new ControleDeQualidadeCopo();
						c1.Hora = hora[x];
						c1.Ciclo = ciclo[x];
						c1.PesoDaPeca = pesoPeca[x];
						c1.Peso = peso[x];
						c1.Cor = cor[x];
						c1.Dimensao = dimensao[x];
						c1.UsuarioId = assinatura[x];
						c1.OrdemProducaoCopoId = ordemProducaoCopo.CodigoIdentificador;
						ctrlQual.Add(c1);
						//ordemProducaoPeca.ControleDeQualidade.ValidaInspecao();
					}
					ordemProducaoCopo.ControleDeQualidadeCopos = ctrlQual;
				}

				db.OrdemProducaoCopoes.Add(ordemProducaoCopo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ExpectativaId = new SelectList(db.Expectativas, "ExpectativaId", "Produto", ordemProducaoCopo.ExpectativaId);
            return View(ordemProducaoCopo);
        }

        // GET: OrdemProducaoCopos/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdemProducaoCopo ordemProducaoCopo = db.OrdemProducaoCopoes.Find(id);
            if (ordemProducaoCopo == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExpectativaId = new SelectList(db.Expectativas, "ExpectativaId", "Produto", ordemProducaoCopo.ExpectativaId);
            return View(ordemProducaoCopo);
        }

        // POST: OrdemProducaoCopos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodigoIdentificador,ExpectativaId,OPnoMes,Data,MateriaPrima,MPLote,MPConsumo,ProdIncio,ProdFim,TempAgua,NivelOleo,RefugoKg,TotalProduzidos,ContadorInicial,ContadorFinal,Status")] OrdemProducaoCopo ordemProducaoCopo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordemProducaoCopo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ExpectativaId = new SelectList(db.Expectativas, "ExpectativaId", "Produto", ordemProducaoCopo.ExpectativaId);
            return View(ordemProducaoCopo);
        }

        // GET: OrdemProducaoCopos/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdemProducaoCopo ordemProducaoCopo = db.OrdemProducaoCopoes.Find(id);
            if (ordemProducaoCopo == null)
            {
                return HttpNotFound();
            }
            return View(ordemProducaoCopo);
        }

        // POST: OrdemProducaoCopos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            OrdemProducaoCopo ordemProducaoCopo = db.OrdemProducaoCopoes.Find(id);
            db.OrdemProducaoCopoes.Remove(ordemProducaoCopo);
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
