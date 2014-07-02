using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgendaAspNetMVC.Models
{
    public class Pessoa
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Telefone> Telefones { get; set; }
    }
}