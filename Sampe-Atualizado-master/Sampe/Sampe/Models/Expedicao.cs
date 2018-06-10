using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sampe.Models
{
    public class Expedicao
    {
        [Key]
        public int ExpedicaoId { get; set; }

        [Required(ErrorMessage = "Preencha este campo")]
        public int Quantidade { get; set; }
        [Required(ErrorMessage = "Preencha este campo")]
        public List<float> Subtotal { get; set; }
        [Required(ErrorMessage = "Preencha este campo")]
        public List<float> ValorUnitario { get; set; }
        [Required(ErrorMessage = "Preencha este campo")]
        public float ValorTotal { get; set; }
        [Required(ErrorMessage = "Preencha este campo")]
        public DateTime Vencimento { get; set; }

        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        [ForeignKey("Marcanti")]
        public int MarcantiId { get; set; }
        public Marcanti Marcanti { get; set; }

        [ForeignKey("OrdemProducaoKit")]
        public String CodigoIdentificadorKit { get; set; }
        public OrdemProducaoKit OrdemProducaoKit { get; set; }

        [ForeignKey("OrdemProducaoCopo")]
        public String OrdemProducaoCopoId { get; set; }
        public OrdemProducaoCopo OrdemProducaoCopo { get; set; }

        public void CalcSubtotal(List<float> valorUnitario, int quantidade)
        {
            var cont = valorUnitario.Count();
            for (var i =0; i <= cont; i++)
            {
                this.Subtotal[i] = valorUnitario[i] * quantidade;
            }
        }
        public void CalcValorTotal(List<float>subtotal)
        {
            var cont = subtotal.Count();
            for (var i = 0; i <= cont; i++)
            {
                this.ValorTotal = this.ValorTotal + subtotal[i] ;
            }
        }
    }
}