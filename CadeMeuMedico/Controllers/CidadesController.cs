using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CadeMeuMedico.Models;
using System.Data;

namespace CadeMeuMedico.Controllers
{
    public class CidadesController : BaseController
    {
        //
        // GET: /Cidades/
        private cademeumedicoEntities db = new cademeumedicoEntities();

        public ActionResult ListaCidades()
        {
            var cidade = db.cidades.ToList(); // // SELECT
            return View(cidade);
        }


        // // INSERT
        public ActionResult Adicionar() //Mostra o formulario para preenchimento
        {
            return View();
        }

        [HttpPost]
        public ActionResult Adicionar(cidades cidade)
        {
            if (ModelState.IsValid)
            {
                db.cidades.Add(cidade);
                db.SaveChanges();
                return RedirectToAction("ListaCidades");
            }
            return View(cidade);
        }

        // // UPDATE
        public ActionResult Editar(long id)
        {
            cidades cidade = db.cidades.Find(id); //Retorna a cidade de acordo com o ID

            return View(cidade);
        }

        [HttpPost]
        public ActionResult Editar(cidades cidade)
        {
            if (ModelState.IsValid) //Verificando se o modelo é valido
            {
                db.Entry(cidade).State = EntityState.Modified; //Acessando o campo e Modificando
                db.SaveChanges();
                return RedirectToAction("ListaCidades");
            }

            return View(cidade);
        }

        // // DELETE
        public ActionResult Excluir(long id)
        {
            cidades cidade = db.cidades.Find(id);
            if (cidade != null)
            {
                db.cidades.Remove(cidade);
                db.SaveChanges();
                return RedirectToAction("ListaCidades");
            }
            return View(cidade);
        }

        // // Detalhes
        public ActionResult Detalhes(long id)
        {
            cidades cidade = db.cidades.Find(id);
            return View(cidade);
        }

    }
}
