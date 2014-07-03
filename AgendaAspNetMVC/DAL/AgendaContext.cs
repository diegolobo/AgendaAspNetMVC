using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AgendaAspNetMVC.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AgendaAspNetMVC.DAL
{
    public class AgendaContext : DbContext
    {

        public AgendaContext()
            : base("AgendaContext")
        {

        }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}