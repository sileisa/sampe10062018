using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sampe.Models
{
	public class OrdemProducaoRefugo
	{
		[Key]
		public int OrdemProducaoRefugoId { get; set; }
		public string Produto { get; set; }
		public DateTime Data { get; set; }

		[ForeignKey("Usuario")]
		public int UsuarioId { get; set; }
		public Usuario Usuario { get; set; }

		public string ProdIncio { get; set; }
		public string ProdFim { get; set; }
		public string Obs { get; set; }
		public bool Status { get; set; }

		public ICollection<int> ParadasRefugoId { get; set; }
		public ICollection<ParadaRefugo> ParadasRefugo { get; set; }
		public ParadaRefugo ParadaRefugo { get; set; }

		public ICollection<int> EspecificacoesRefugoId { get; set; }
		public ICollection<EspecificacaoRefugo> EspecificacoesRefugo { get; set; }
		public EspecificacaoRefugo EspecificacaoRefugo { get; set; }

		public List<string> RemoveExtraFalseFromCheckbox(List<string> val)
		{
			List<string> d_taxe1_list = new List<string>(val);

			int y = 0;

			foreach (string cbox in val)
			{

				if (val[y] == "false")
				{
					if (y > 0)
					{
						if (val[y - 1] == "true")
						{
							d_taxe1_list[y] = "remove";
						}
					}
				}
				y++;
			}

			val = new List<string>(d_taxe1_list);

			foreach (var del in d_taxe1_list)
				if (del == "remove") val.Remove(del);

			return val;

		}
	}
}