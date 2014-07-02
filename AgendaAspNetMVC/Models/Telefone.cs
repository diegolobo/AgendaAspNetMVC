using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgendaAspNetMVC.Models
{

    public enum Tipo
    {
        RESIDENCIAL, CELULAR, OUTROS
    }

    public class Telefone
    {
        public int ID { get; set; }
        public int PessoaID { get; set; }
        public string Numero { get; set; }
        public Tipo Tipo { get; set; }

        public virtual Pessoa Pessoa { get; set; }
    }
}