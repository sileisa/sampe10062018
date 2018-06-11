using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sampe
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }
        public String NomeCliente { get; set; }
        public int? Cnpj  { get; set; }
        public int? Cep { get; set; }
        public String Uf { get; set; }
        public String Cidade { get; set; }
        public String Rua { get; set; }
        public String Bairro { get; set; }
        public int? Numero { get; set; }
        public int? IE { get; set; }
    }
}