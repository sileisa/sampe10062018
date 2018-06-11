using PagedList;
using Rotativa;
using Rotativa.Options;
using Sampe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sampe.Controllers
{
    public class RelatorioController : Controller
    {
        private SampeContext db = new SampeContext();
        public ActionResult ExibeOs(int? pagina, Boolean? gerarPdf, int id)
        {
            FormularioOrdemServico formularioOrdemServico = db.FormularioOrdemServicoes.Find(id);
            var busca = from FormularioOrdemServicos in db.FormularioOrdemServicoes
                        where FormularioOrdemServicos.FormularioOrdemServicoId == formularioOrdemServico.FormularioOrdemServicoId
                        join FormularioOSAtividades in db.FormularioOSAtividade
                        on FormularioOrdemServicos.FormularioOrdemServicoId equals FormularioOSAtividades.FormularioOrdemServicoId
                        join AtividadeOS in db.AtividadeOS
                        on FormularioOSAtividades.AtividadeOSId equals AtividadeOS.AtividadeOSId
                        select FormularioOSAtividades;

            var busca2 = from FormularioOrdemServicos in db.FormularioOrdemServicoes
                         where FormularioOrdemServicos.FormularioOrdemServicoId == formularioOrdemServico.FormularioOrdemServicoId
                         join FormularioOSAtividades in db.FormularioOSAtividade
                        on FormularioOrdemServicos.FormularioOrdemServicoId equals FormularioOSAtividades.FormularioOrdemServicoId
                         join AtividadeOS in db.AtividadeOS
                         on FormularioOSAtividades.AtividadeOSId equals AtividadeOS.AtividadeOSId
                         select FormularioOSAtividades.AtividadeOS;
            List<FormularioOrdemServico> buscaOs = new List<FormularioOrdemServico>();

            db.Entry(formularioOrdemServico).Reference(f => f.Maquina).Load();
            db.Entry(formularioOrdemServico).Reference(f => f.Usuario).Load();
            formularioOrdemServico.FormularioOSAtividades = busca.ToArray();
            formularioOrdemServico.AtividadesOs = busca2.ToArray();
            buscaOs.Add(formularioOrdemServico);
            if (gerarPdf != true)
            {
                int pgQtdRegistro = 2;
                int pgNav = (pagina ?? 1);
                return View(buscaOs.ToPagedList(pgNav, pgQtdRegistro));
            }
            else
            {
                int paginaNumero = 1;
                var pdf = new ViewAsPdf
                {
                    ViewName = "ExibeOs",
                    PageSize = Size.A4,
                    IsGrayScale = false,
                    Model = buscaOs.ToPagedList(paginaNumero, buscaOs.Count)
                };
                return pdf;
            }
        }
        public ActionResult ExibeTm(int? pagina, Boolean? gerarPdf, int id)
        {
            FormularioTrocaMolde formularioTrocaMolde = db.FormularioTrocaMoldes.Find(id);

            var busca = from FormularioTrocaMoldes in db.FormularioTrocaMoldes
                        where FormularioTrocaMoldes.FormularioTrocaMoldeId == formularioTrocaMolde.FormularioTrocaMoldeId
                        join FormularioTMAtividades in db.FormularioTMAtividade
                        on FormularioTrocaMoldes.FormularioTrocaMoldeId equals FormularioTMAtividades.FormularioTrocaMoldeId
                        join AtividadeTM in db.AtividadeTMs
                        on FormularioTMAtividades.AtividadeTMId equals AtividadeTM.AtividadeTMId
                        select FormularioTMAtividades;

            var busca2 = from Formulario in db.FormularioTrocaMoldes
                         where Formulario.FormularioTrocaMoldeId == formularioTrocaMolde.FormularioTrocaMoldeId
                         join Relacional in db.FormularioTMAtividade
                         on Formulario.FormularioTrocaMoldeId equals Relacional.FormularioTrocaMoldeId
                         join Atividade in db.AtividadeTMs
                         on Relacional.AtividadeTMId equals Atividade.AtividadeTMId
                         select Relacional.AtividadeTM;

            var busca3 = from Formulario in db.FormularioTrocaMoldes
                         where Formulario.FormularioTrocaMoldeId == formularioTrocaMolde.FormularioTrocaMoldeId
                         join Relacional in db.FormularioMolde
                         on Formulario.FormularioTrocaMoldeId equals Relacional.FormularioTrocaMoldeId
                         join Molde in db.Moldes
                         on Relacional.MoldeId equals Molde.MoldeId
                         select Relacional.Molde;

            //var user = User.Identity.Name;
            //db.Entry(formularioTrocaMolde).Reference(f => f.Molde).Load();
            db.Entry(formularioTrocaMolde).Reference(f => f.Maquina).Load();
            db.Entry(formularioTrocaMolde).Reference(f => f.Usuario).Load();
            formularioTrocaMolde.FormularioTMAtividades = busca.ToList();
            formularioTrocaMolde.AtividadesTM = busca2.ToList();
            formularioTrocaMolde.Moldes = busca3.ToList();

            List<FormularioTrocaMolde> buscaTm = new List<FormularioTrocaMolde>();
            buscaTm.Add(formularioTrocaMolde);
            if (gerarPdf != true)
            {
                int pgQtdRegistro = 2;
                int pgNav = (pagina ?? 1);
                return View(buscaTm.ToPagedList(pgNav, pgQtdRegistro));
            }
            else
            {
                int paginaNumero = 1;
                var pdf = new ViewAsPdf
                {
                    ViewName = "ExibeTm",
                    PageSize = Size.A4,
                    IsGrayScale = false,
                    Model = buscaTm.ToPagedList(paginaNumero, buscaTm.Count)
                };
                return pdf;
            }
        }

        // GET: Relatorio

        public ActionResult BuscaOS()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BuscaOS(DateTime dt1, DateTime dt2, int? pagina, Boolean? gerarPdf)
        {
            var buscaOS = db.FormularioOrdemServicoes.Where(a => a.Dt >= dt1 && a.Dt <= dt2 && a.Status == true).ToList();
            ViewBag.dt1 = dt1;
            ViewBag.dt2 = dt2;
            foreach (var item in buscaOS)
            {
                FormularioOrdemServico formularioOrdemServico = db.FormularioOrdemServicoes.Find(item.FormularioOrdemServicoId);
                db.Entry(formularioOrdemServico).Reference(f => f.Maquina).Load();
                db.Entry(formularioOrdemServico).Reference(f => f.Usuario).Load();
            }
            if (gerarPdf == true)
            {
                int pgQtdRegistro = 2;
                int pgNav = (pagina ?? 1);

                return View(buscaOS.ToPagedList(pgNav, pgQtdRegistro));
            }
            else
            {
                int paginaNumero = 1;
                var pdf = new ViewAsPdf
                {
                    ViewName = "OsData",
                    PageSize = Size.A4,
                    IsGrayScale = false,
                    Model = buscaOS.ToPagedList(paginaNumero, buscaOS.Count)
                };
                return pdf;
            }

        }
        public ActionResult BuscaTM()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BuscaTM(DateTime dt1, DateTime dt2, int? pagina, Boolean? gerarPdf, int? id)
        {

            var buscaTM = db.FormularioTrocaMoldes.Where(a => a.DtRetirada >= dt1 && a.DtRetirada <= dt2 && a.Status == true).ToList();
            ViewBag.dt1 = dt1;
            ViewBag.dt2 = dt2;
            foreach (var item in buscaTM)
            {
                FormularioTrocaMolde formularioTrocaMolde = db.FormularioTrocaMoldes.Find(item.FormularioTrocaMoldeId);
                db.Entry(formularioTrocaMolde).Reference(f => f.Maquina).Load();
                db.Entry(formularioTrocaMolde).Reference(f => f.Usuario).Load();
            }

            if (gerarPdf == true)
            {
                int pgQtdRegistro = 10;
                int pgNav = (pagina ?? 1);

                return View(buscaTM.ToPagedList(pgNav, pgQtdRegistro));
            }
            else
            {
                int paginaNumero = 1;
                var pdf = new ViewAsPdf
                {
                    ViewName = "TmData",
                    PageSize = Size.A4,
                    IsGrayScale = false,
                    Model = buscaTM.ToPagedList(paginaNumero, buscaTM.Count)
                };

                return pdf;

            }

        }
        public ActionResult BuscaTMporMaquina()
        {
            ViewBag.MaquinaId = new SelectList(db.Maquinas, "MaquinaId", "NomeMaquina");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BuscaTMporMaquina(int MaquinaId, int? pagina, Boolean? gerarPdf, int? id)
        {

            var buscaTM = db.FormularioTrocaMoldes.Where(a => a.MaquinaId == MaquinaId && a.Status == true).ToList();

            foreach (var item in buscaTM)
            {

                FormularioTrocaMolde formularioTrocaMolde = db.FormularioTrocaMoldes.Find(item.FormularioTrocaMoldeId);
                db.Entry(formularioTrocaMolde).Reference(f => f.Maquina).Load();
                ViewBag.MaquinaId = formularioTrocaMolde.Maquina.NomeMaquina;
                db.Entry(formularioTrocaMolde).Reference(f => f.Usuario).Load();

            }

            if (gerarPdf == true)
            {
                int pgQtdRegistro = 10;
                int pgNav = (pagina ?? 1);

                return View(buscaTM.ToPagedList(pgNav, pgQtdRegistro));
            }
            else
            {
                int paginaNumero = 1;
                var pdf = new ViewAsPdf
                {
                    ViewName = "TmMaquina",
                    PageSize = Size.A4,
                    IsGrayScale = false,
                    Model = buscaTM.ToPagedList(paginaNumero, buscaTM.Count)
                };

                return pdf;

            }

        }
        public ActionResult BuscaOSporMaquina()
        {
            ViewBag.MaquinaId = new SelectList(db.Maquinas, "MaquinaId", "NomeMaquina");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BuscaOSporMaquina(int MaquinaId, int? pagina, Boolean? gerarPdf, int? id)
        {

            var buscaOS = db.FormularioOrdemServicoes.Where(a => a.MaquinaId == MaquinaId && a.Status == true).ToList();

            foreach (var item in buscaOS)
            {

                FormularioOrdemServico formularioOrdemServico = db.FormularioOrdemServicoes.Find(item.FormularioOrdemServicoId);
                db.Entry(formularioOrdemServico).Reference(f => f.Maquina).Load();
                ViewBag.MaquinaId = formularioOrdemServico.Maquina.NomeMaquina;
                db.Entry(formularioOrdemServico).Reference(f => f.Usuario).Load();

            }

            if (gerarPdf == true)
            {
                int pgQtdRegistro = 10;
                int pgNav = (pagina ?? 1);

                return View(buscaOS.ToPagedList(pgNav, pgQtdRegistro));
            }
            else
            {
                int paginaNumero = 1;
                var pdf = new ViewAsPdf
                {
                    ViewName = "OsMaquina",
                    PageSize = Size.A4,
                    IsGrayScale = false,
                    Model = buscaOS.ToPagedList(paginaNumero, buscaOS.Count)
                };

                return pdf;

            }

        }
        public ActionResult BuscaOpPeca()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BuscaOpPeca(DateTime dt1, DateTime dt2, int? pagina, Boolean? gerarPdf, string id)
        {
            var buscaOpPeca = db.OrdemProducaoPecas.Where(a => a.Data >= dt1 && a.Data <= dt2 && a.Status == true).ToList();
            ViewBag.dt1 = dt1;
            ViewBag.dt2 = dt2;
            foreach (var item in buscaOpPeca)
            {
                OrdemProducaoPeca ordemProducaoPeca = db.OrdemProducaoPecas.Find(item.CodigoIdentificador);
                db.Entry(ordemProducaoPeca).Reference(f => f.Maquina).Load();
                db.Entry(ordemProducaoPeca).Reference(f => f.Expectativa).Load();
                db.Entry(ordemProducaoPeca).Reference(f => f.ControleDeQualidade).Load();
                db.Entry(ordemProducaoPeca).Reference(f => f.Parada).Load();
            }
            if (gerarPdf == true)
            {
                int pgQtdRegistro = 10;
                int pgNav = (pagina ?? 1);

                return View(buscaOpPeca.ToPagedList(pgNav, pgQtdRegistro));
            }
            else
            {
                int paginaNumero = 1;
                var pdf = new ViewAsPdf
                {
                    ViewName = "OpPecaData",
                    PageSize = Size.A4,
                    IsGrayScale = false,
                    Model = buscaOpPeca.ToPagedList(paginaNumero, buscaOpPeca.Count)
                };
                return pdf;
            }
        }

        public ActionResult BuscaOpKit()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BuscaOpKit(DateTime dt1, DateTime dt2, int? pagina, Boolean? gerarPdf, string id)
        {
            var buscaOpKit = db.OrdemProducaoKits.Where(a => a.Data >= dt1 && a.Data <= dt2 && a.Status == true).ToList();
            ViewBag.dt1 = dt1;
            ViewBag.dt2 = dt2;
            foreach (var item in buscaOpKit)
            {
                OrdemProducaoKit ordemProducaoKit = db.OrdemProducaoKits.Find(item.CodigoIdentificadorKit);
                db.Entry(ordemProducaoKit).Reference(f => f.Especificacao).Load();
                db.Entry(ordemProducaoKit).Reference(f => f.OrdemProducaoPeca).Load();
                db.Entry(ordemProducaoKit).Reference(f => f.ParadaKit).Load();
                db.Entry(ordemProducaoKit).Reference(f => f.Usuario).Load();
            }
            if (gerarPdf == true)
            {
                int pgQtdRegistro = 10;
                int pgNav = (pagina ?? 1);

                return View(buscaOpKit.ToPagedList(pgNav, pgQtdRegistro));
            }
            else
            {
                int paginaNumero = 1;
                var pdf = new ViewAsPdf
                {
                    ViewName = "OpKitData",
                    PageSize = Size.A4,
                    IsGrayScale = false,
                    Model = buscaOpKit.ToPagedList(paginaNumero, buscaOpKit.Count)
                };
                return pdf;
            }
        }
        public ActionResult BuscaOpCopo()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BuscaOpCopo(DateTime dt1, DateTime dt2, int? pagina, Boolean? gerarPdf)
        {
            var buscaOpCopo = db.OrdemProducaoCopoes.Where(a => a.Data >= dt1 && a.Data <= dt2 && a.Status == true).ToList();
            ViewBag.dt1 = dt1;
            ViewBag.dt2 = dt2;
            foreach (var item in buscaOpCopo)
            {
                OrdemProducaoCopo ordemProducaoCopo = db.OrdemProducaoCopoes.Find(item.CodigoIdentificador);
                db.Entry(ordemProducaoCopo).Reference(f => f.Maquina).Load();
                db.Entry(ordemProducaoCopo).Reference(f => f.Expectativa).Load();
                db.Entry(ordemProducaoCopo).Reference(f => f.ControleDeQualidadeCopo).Load();
                db.Entry(ordemProducaoCopo).Reference(f => f.ParadaCopo).Load();
                db.Entry(ordemProducaoCopo).Reference(f => f.EspecificacaoCopo).Load();
            }
            if (gerarPdf == true)
            {
                int pgQtdRegistro = 2;
                int pgNav = (pagina ?? 1);

                return View(buscaOpCopo.ToPagedList(pgNav, pgQtdRegistro));
            }
            else
            {
                int paginaNumero = 1;
                var pdf = new ViewAsPdf
                {
                    ViewName = "OpCopoData",
                    PageSize = Size.A4,
                    IsGrayScale = false,
                    Model = buscaOpCopo.ToPagedList(paginaNumero, buscaOpCopo.Count)
                };
                return pdf;
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BuscaOpRefugo(DateTime dt1, DateTime dt2, int? pagina, Boolean? gerarPdf)
        {
            var buscaOpRefugo = db.OrdemProducaoRefugoes.Where(a => a.Data >= dt1 && a.Data <= dt2 && a.Status == true).ToList();
            ViewBag.dt1 = dt1;
            ViewBag.dt2 = dt2;
            foreach (var item in buscaOpRefugo)
            {
                OrdemProducaoRefugo ordemProducaoRefugo = db.OrdemProducaoRefugoes.Find(item.OrdemProducaoRefugoId);
                db.Entry(ordemProducaoRefugo).Reference(f => f.Usuario).Load();
                db.Entry(ordemProducaoRefugo).Reference(f => f.EspecificacaoRefugo).Load();
                db.Entry(ordemProducaoRefugo).Reference(f => f.ParadaRefugo).Load();

            }
            if (gerarPdf == true)
            {
                int pgQtdRegistro = 2;
                int pgNav = (pagina ?? 1);

                return View(buscaOpRefugo.ToPagedList(pgNav, pgQtdRegistro));
            }
            else
            {
                int paginaNumero = 1;
                var pdf = new ViewAsPdf
                {
                    ViewName = "OpRefugoData",
                    PageSize = Size.A4,
                    IsGrayScale = false,
                    Model = buscaOpRefugo.ToPagedList(paginaNumero, buscaOpRefugo.Count)
                };
                return pdf;
            }

        }
       
    }
}