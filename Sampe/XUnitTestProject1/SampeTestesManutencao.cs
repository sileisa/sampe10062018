using Sampe;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SampeTeste

{
    public class SampeTestesManutencao
    {

        #region OrdemDeServico
        [Fact(DisplayName = nameof(ManutencaoOrdemDadosValidos))]
        public void ManutencaoOrdemDadosValidos()
        {
            var ordemdeservico = new FormularioOrdemServico();
            var maquina = new Maquina();
            ordemdeservico.HoraFinal = "15:05";
            ordemdeservico.HoraInicio = "15:00";
            ordemdeservico.Intervalo = true;
            ordemdeservico.IntervaloFim = "15:30";
            ordemdeservico.IntervaloInicio = "15:15";
            ordemdeservico.Supervisor = "Manoel";
            ordemdeservico.QuantSobrante = 115;
            ordemdeservico.QuantUsado = 1000;
            maquina.MaquinaId = 1;
            maquina.NomeMaquina = "Injetora";
            ordemdeservico.TipoManutencao = "Preventiva";
            ordemdeservico.MaterialSobrante = "Refugo";
            ordemdeservico.ObsIntervalo = "Fui comer";
            ordemdeservico.MaterialUsado = "Plástico";
            DateTime date1 = new DateTime(2008, 5, 1, 8, 30, 52);
            DateTime date2 = new DateTime(2008, 5, 1, 8, 30, 52);
            var datacomparar = date2;
            ordemdeservico.Dt = date1;
            Assert.Equal("15:05", ordemdeservico.HoraFinal);
            Assert.Equal("15:00", ordemdeservico.HoraInicio);
            Assert.True(ordemdeservico.Intervalo);
            Assert.Equal("15:30", ordemdeservico.IntervaloFim);
            Assert.Equal("15:15", ordemdeservico.IntervaloInicio);
            Assert.Equal("Manoel", ordemdeservico.Supervisor);
            Assert.Equal(115, ordemdeservico.QuantSobrante);
            Assert.Equal(1000, ordemdeservico.QuantUsado);
            Assert.Equal("Preventiva", ordemdeservico.TipoManutencao);
            Assert.Equal("Refugo", ordemdeservico.MaterialSobrante);
            Assert.Equal("Fui comer", ordemdeservico.ObsIntervalo);
            Assert.Equal("Plástico", ordemdeservico.MaterialUsado);
            Assert.Equal("Injetora", maquina.NomeMaquina);
            Assert.Equal(1, maquina.MaquinaId);
            Assert.Equal(datacomparar, ordemdeservico.Dt);










        }
        #endregion
        #region TrocadeMolde
        [Fact(DisplayName = nameof(ManutencaoTrocaDadosValidos))]
        public void ManutencaoTrocaDadosValidos()
        {
            var trocademolde = new FormularioTrocaMolde();
            var maquina = new Maquina();
            DateTime date1 = new DateTime(2008, 5, 1, 8, 30, 52);
            DateTime date2 = new DateTime(2008, 5, 1, 8, 30, 52);
            DateTime date3 = new DateTime(2009, 6, 2, 9, 31, 55);
            DateTime date4 = new DateTime(2009, 6, 2, 9, 31, 55);
            maquina.MaquinaId = 1;
            maquina.NomeMaquina = "Injetora";
            trocademolde.DtRetirada = date1;
            trocademolde.DtColocar = date3;
            trocademolde.ColocarInicio = "15:05";
            trocademolde.ColocarFim = "15:10";
            trocademolde.RetirarInicio = "16:00";
            trocademolde.RetirarFim = "16:10";
            trocademolde.Supervisor = "Manoel";
            Assert.Equal("15:05", trocademolde.ColocarInicio);
            Assert.Equal("15:10", trocademolde.ColocarFim);
            Assert.Equal("16:00", trocademolde.RetirarInicio);
            Assert.Equal("16:10", trocademolde.RetirarFim);
            Assert.Equal("Manoel", trocademolde.Supervisor);
            Assert.Equal(date1, trocademolde.DtColocar);
            Assert.Equal(date3, trocademolde.DtRetirada);


        }
        #endregion
    }
}

