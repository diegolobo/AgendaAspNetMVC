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
    public class TelefoneController : Controller
    {
        private AgendaContext db = new AgendaContext();

        // GET: Telefone
        public ActionResult Index()
        {
            var telefoens = db.Telefoens.Include(t => t.Pessoa);
            return View(telefoens.ToList());
        }

        // GET: Telefone/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Telefone telefone = db.Telefoens.Find(id);
            if (telefone == null)
            {
                return HttpNotFound();
            }
            return View(telefone);
        }

        // GET: Telefone/Create
        public ActionResult Create()
        {
            ViewBag.PessoaID = new SelectList(db.Pessoas, "ID", "Nome");
            return View();
        }

        // POST: Telefone/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PessoaID,Numero,Tipo")] Telefone telefone)
        {
            if (ModelState.IsValid)
            {
                db.Telefoens.Add(telefone);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PessoaID = new SelectList(db.Pessoas, "ID", "Nome", telefone.PessoaID);
            return View(telefone);
        }

        // GET: Telefone/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Telefone telefone = db.Telefoens.Find(id);
            if (telefone == null)
            {
                return HttpNotFound();
            }
            ViewBag.PessoaID = new SelectList(db.Pessoas, "ID", "Nome", telefone.PessoaID);
            return View(telefone);
        }

        // POST: Telefone/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PessoaID,Numero,Tipo")] Telefone telefone)
        {
            if (ModelState.IsValid)
            {
                db.Entry(telefone).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PessoaID = new SelectList(db.Pessoas, "ID", "Nome", telefone.PessoaID);
            return View(telefone);
        }

        // GET: Telefone/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Telefone telefone = db.Telefoens.Find(id);
            if (telefone == null)
            {
                return HttpNotFound();
            }
            return View(telefone);
        }

        // POST: Telefone/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Telefone telefone = db.Telefoens.Find(id);
            db.Telefoens.Remove(telefone);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
