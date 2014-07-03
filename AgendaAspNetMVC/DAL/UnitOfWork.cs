using AgendaAspNetMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgendaAspNetMVC.DAL
{
    public class UnitOfWork<TEntity> : IDisposable where TEntity : class
    {
        private AgendaContext context = new AgendaContext();
        //private GenericRepository<Pessoa> pessoaRepository;
        private GenericRepository<Telefone> telefoneRepository;
        private GenericRepository<TEntity> repository;

        //public GenericRepository<Pessoa> PessoaRepository
        //{
        //    get
        //    {
        //        if (this.pessoaRepository == null)
        //        {
        //            this.pessoaRepository = new GenericRepository<Pessoa>(context);
        //        }
        //        return pessoaRepository;
        //    }
        //}

        public GenericRepository<Telefone> TelefoneRepository
        {
            get 
            {
                if (telefoneRepository == null)
                {
                    telefoneRepository = new GenericRepository<Telefone>(context);
                }
                return telefoneRepository; 
            }
        }

        public GenericRepository<TEntity> Repository
        {
            get 
            {
                if (repository == null)
                {
                    repository = new GenericRepository<TEntity>(context);
                }
                return repository;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}