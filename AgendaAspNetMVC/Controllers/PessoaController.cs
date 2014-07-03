using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AgendaAspNetMVC.DAL;
using AgendaAspNetMVC.Models;

namespace AgendaAspNetMVC.Controllers
{
    public class PessoaController : Controller
    {
        //private AgendaContext db = new AgendaContext();
        private UnitOfWork<Pessoa> unitOfWork = new UnitOfWork<Pessoa>();

        // GET: Pessoa
        public ActionResult Index()
        {
            //return View(db.Pessoas.ToList());
            return View(unitOfWork.Repository.Get());
        }

        // GET: Pessoa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Pessoa pessoa = db.Pessoas.Find(id);
            Pessoa pessoa = unitOfWork.Repository.GetByID(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        // GET: Pessoa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pessoa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,Email")] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                //db.Pessoas.Add(pessoa);
                //db.SaveChanges();
                unitOfWork.Repository.Insert(pessoa);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(pessoa);
        }

        // GET: Pessoa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Pessoa pessoa = db.Pessoas.Find(id);
            Pessoa pessoa = unitOfWork.Repository.GetByID(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        // POST: Pessoa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Email")] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(pessoa).State = EntityState.Modified;
                //db.SaveChanges();
                unitOfWork.Repository.Update(pessoa);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(pessoa);
        }

        // GET: Pessoa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Pessoa pessoa = db.Pessoas.Find(id);
            Pessoa pessoa = unitOfWork.Repository.GetByID(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        // POST: Pessoa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Pessoa pessoa = db.Pessoas.Find(id);
            //db.Pessoas.Remove(pessoa);
            //db.SaveChanges();
            Pessoa pessoa = unitOfWork.Repository.GetByID(id);
            unitOfWork.Repository.Delete(id);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
                unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
