using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CadeMeuMedico.Models;
using System.Data;

namespace CadeMeuMedico.Controllers
{
    public class EspecialidadeController : BaseController
    {
        //
        // GET: /Especialidade/
        private cademeumedicoEntities db = new cademeumedicoEntities();

        public ActionResult ListaEspecialidade()
        {
            var especialidade = db.especialidades.ToList(); // // SELECT
            return View(especialidade);
        }


        // // INSERT
        public ActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Adicionar(especialidades especialidade)
        {
            if (ModelState.IsValid)
            {
                db.especialidades.Add(especialidade);
                db.SaveChanges();
                return RedirectToAction("ListaEspecialidade");
            }
            return View(especialidade);
        }

        // // UPDATE
        public ActionResult Editar(long id)
        {
            especialidades especialidade = db.especialidades.Find(id);

            return View(especialidade);
        }

        [HttpPost]
        public ActionResult Editar(especialidades especialidade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(especialidade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ListaEspecialidade");
            }
            return View(especialidade);
        }

        // // DELETE
        public ActionResult Excluir(long id)
        {
            especialidades especialidade = db.especialidades.Find(id);
            if (especialidade != null)
            {
                db.especialidades.Remove(especialidade);
                db.SaveChanges();
                return RedirectToAction("ListaEspecialidade");
            }
            return View(especialidade);
        }
    }
}
