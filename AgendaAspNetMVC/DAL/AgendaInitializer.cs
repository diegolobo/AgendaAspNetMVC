using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using AgendaAspNetMVC.Models;

namespace AgendaAspNetMVC.DAL
{
    public class AgendaInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<AgendaContext>
    {
        protected override void Seed(AgendaContext context)
        {
            var pessoas = new List<Pessoa>
            {
                new Pessoa{Nome="Rafaela",Email="rafaela@carlos.com.br"},
                new Pessoa{Nome="Carlos",Email="carlos@carlos.com.br"},
                new Pessoa{Nome="Vitor",Email="vitor@carlos.com.br"},
                new Pessoa{Nome="Claudio",Email="claudio@carlos.com.br"}
            };

            pessoas.ForEach(s => context.Pessoas.Add(s));
            context.SaveChanges();

            var telefones = new List<Telefone>
            {
                new Telefone{PessoaID=1,Numero="3234-3234",Tipo=Tipo.RESIDENCIAL},
                new Telefone{PessoaID=1,Numero="9898-9898",Tipo=Tipo.CELULAR},
                new Telefone{PessoaID=2,Numero="3636-3636",Tipo=Tipo.RESIDENCIAL},
                new Telefone{PessoaID=2,Numero="8686-8686",Tipo=Tipo.CELULAR},
                new Telefone{PessoaID=3,Numero="3535-3234",Tipo=Tipo.RESIDENCIAL},
                new Telefone{PessoaID=3,Numero="8787-3234",Tipo=Tipo.CELULAR},
                new Telefone{PessoaID=4,Numero="3249-3234",Tipo=Tipo.RESIDENCIAL},
                new Telefone{PessoaID=4,Numero="8800-3234",Tipo=Tipo.CELULAR}
            };

            telefones.ForEach(s => context.Telefoens.Add(s));
            context.SaveChanges();
        }        

    }
}