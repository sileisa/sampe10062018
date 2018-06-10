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
	public class OrdemProducaoRefugosController : Controller
	{
		private SampeContext db = new SampeContext();

		// GET: OrdemProducaoRefugos
		public ActionResult Index()
		{
			var ordemProducaoRefugoes = db.OrdemProducaoRefugoes.Include(o => o.Usuario);
			return View(ordemProducaoRefugoes.ToList());
		}

		// GET: OrdemProducaoRefugos/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			OrdemProducaoRefugo ordemProducaoRefugo = db.OrdemProducaoRefugoes.Find(id);
			if (ordemProducaoRefugo == null)
			{
				return HttpNotFound();
			}
			return View(ordemProducaoRefugo);
		}

		// GET: OrdemProducaoRefugos/Create
		public ActionResult Create()
		{
			ViewBag.UsuarioId = new SelectList(db.Usuarios, "UsuarioId", "NomeUsuario");
			return View();
		}

		// POST: OrdemProducaoRefugos/Create
		// Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
		// obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "OrdemProducaoRefugoId,Produto,Data,UsuarioId,ProdIncio,ProdFim,Obs")] OrdemProducaoRefugo ordemProducaoRefugo, bool Status)
		{
			var a = Request.Form["Material"];
			var b = Request.Form["Cor"];
			var c = Request.Form["EspecificacaoRefugo.Peso"];
			List<string> d = new List<string>(Request.Form.GetValues("EspecificacaoRefugo.Limpeza"));

			var e = Request.Form["ParadaRefugo.HoraParada"];
			var f = Request.Form["ParadaRefugo.HoraRetorno"];
			var g = Request.Form["Motivo"];
			var h = Request.Form["ParadaRefugo.Observacoes"];
			if (ModelState.IsValid)
			{
				if (a != null)
				{
					var material = a.Split(',');
					var cor = b.Split(',');
					var peso = c.Split(',').Select(Double.Parse).ToArray();
					d = ordemProducaoRefugo.RemoveExtraFalseFromCheckbox(d);
					bool[] limpeza = d.Select(Boolean.Parse).ToArray();
					List<EspecificacaoRefugo> esp = new List<EspecificacaoRefugo>();
					for (int x = 0; x < material.Count(); x++)
					{
						EspecificacaoRefugo e1 = new EspecificacaoRefugo();
						e1.Material = material[x];
						e1.Cor = cor[x];
						e1.Peso = peso[x];
						e1.Limpeza = limpeza[x];
						e1.OrdemProducaoRefugoId = ordemProducaoRefugo.OrdemProducaoRefugoId;
						esp.Add(e1);
					}
					ordemProducaoRefugo.EspecificacoesRefugo = esp;
				}

				if (e != null)
				{
					var hrP = e.Split(',');
					var hrR = f.Split(',');
					var mot = g.Split(',');
					var obs = h.Split(',');
					List<ParadaRefugo> parada = new List<ParadaRefugo>();
					for (int y = 0; y < hrP.Count(); y++)
					{
						ParadaRefugo p = new ParadaRefugo();
						p.HoraParada = hrP[y];
						p.HoraRetorno = hrR[y];
						p.Motivo = mot[y];
						p.Observacoes = obs[y];
						p.OrdemProducaoRefugoId = ordemProducaoRefugo.OrdemProducaoRefugoId;
						parada.Add(p);
					}
					ordemProducaoRefugo.ParadasRefugo = parada;
				}
				
				db.OrdemProducaoRefugoes.Add(ordemProducaoRefugo);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			ViewBag.UsuarioId = new SelectList(db.Usuarios, "UsuarioId", "NomeUsuario", ordemProducaoRefugo.UsuarioId);
			return View(ordemProducaoRefugo);
		}

		// GET: OrdemProducaoRefugos/Edit/5
		public ActionResult Edit(int? id)
		{
			ViewBag.UsuarioId = new SelectList(db.Usuarios, "UsuarioId", "NomeUsuario");
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			OrdemProducaoRefugo ordemProducaoRefugo = db.OrdemProducaoRefugoes.Find(id);
			var busca = db.ParadaRefugoes.Where(o => o.OrdemProducaoRefugoId == id).ToList();
			ordemProducaoRefugo.ParadasRefugo = busca;
			var busca2 = db.EspecificacaoRefugoes.Where(o => o.OrdemProducaoRefugoId == id).ToList();
			ordemProducaoRefugo.EspecificacoesRefugo = busca2;
			if (ordemProducaoRefugo == null)
			{
				return HttpNotFound();
			}
			ViewBag.UsuarioId = new SelectList(db.Usuarios, "UsuarioId", "NomeUsuario", ordemProducaoRefugo.UsuarioId);
			return View(ordemProducaoRefugo);
		}

		// POST: OrdemProducaoRefugos/Edit/5
		// Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
		// obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "OrdemProducaoRefugoId,Produto,Data,UsuarioId,ProdIncio,ProdFim,Obs")] OrdemProducaoRefugo ordemProducaoRefugo)
		{
			var a = Request.Form["Material"];
			var b = Request.Form["Cor"];
			var c = Request.Form["EspecificacaoRefugo.Peso"];
			

			var e = Request.Form["ParadaRefugo.HoraParada"];
			var f = Request.Form["ParadaRefugo.HoraRetorno"];
			var g = Request.Form["Motivo"];
			var h = Request.Form["ParadaRefugo.Observacoes"];
			if (ModelState.IsValid)
			{

				if (a != null)
				{
					var material = a.Split(',');
					var cor = b.Split(',');
					var peso = c.Split(',').Select(Double.Parse).ToArray();
					List<string> d = new List<string>(Request.Form.GetValues("EspecificacaoRefugo.Limpeza"));
					d = ordemProducaoRefugo.RemoveExtraFalseFromCheckbox(d);
					bool[] limpeza = d.Select(Boolean.Parse).ToArray();
					for (int x = 0; x < material.Count(); x++)
					{
						EspecificacaoRefugo e1 = new EspecificacaoRefugo();
						e1.Material = material[x];
						e1.Cor = cor[x];
						e1.Peso = peso[x];
						e1.Limpeza = limpeza[x];
						e1.OrdemProducaoRefugoId = ordemProducaoRefugo.OrdemProducaoRefugoId;
						db.EspecificacaoRefugoes.Add(e1);
						db.SaveChanges();
					}
				}

				if (e != null)
				{
					var hrP = e.Split(',');
					var hrR = f.Split(',');
					var mot = g.Split(',');
					var obs = h.Split(',');
					for (int y = 0; y < hrP.Count(); y++)
					{
						ParadaRefugo p = new ParadaRefugo();
						p.HoraParada = hrP[y];
						p.HoraRetorno = hrR[y];
						p.Motivo = mot[y];
						p.Observacoes = obs[y];
						p.OrdemProducaoRefugoId = ordemProducaoRefugo.OrdemProducaoRefugoId;
						db.ParadaRefugoes.Add(p);
						db.SaveChanges();
					}
				}


				db.Entry(ordemProducaoRefugo).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			ViewBag.UsuarioId = new SelectList(db.Usuarios, "UsuarioId", "NomeUsuario", ordemProducaoRefugo.UsuarioId);
			return View(ordemProducaoRefugo);
		}

		// GET: OrdemProducaoRefugos/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			OrdemProducaoRefugo ordemProducaoRefugo = db.OrdemProducaoRefugoes.Find(id);

			if (ordemProducaoRefugo == null)
			{
				return HttpNotFound();
			}
			return View(ordemProducaoRefugo);
		}

		// POST: OrdemProducaoRefugos/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			OrdemProducaoRefugo ordemProducaoRefugo = db.OrdemProducaoRefugoes.Find(id);
			db.OrdemProducaoRefugoes.Remove(ordemProducaoRefugo);
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
