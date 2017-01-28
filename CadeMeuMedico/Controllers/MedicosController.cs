using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CadeMeuMedico.Models;
using System.Data; //Referenciando o Models para ter acesso ao contexto de entidade do EF (Instância do banco)

namespace CadeMeuMedico.Controllers
{
    public class MedicosController : BaseController
    {
       private cademeumedicoEntities db = new cademeumedicoEntities(); //Instância com o banco de dados

        public ActionResult ListaMedicos() // // // SELECT
        {
            var Medico = db.medicos.ToList();
            return View(Medico);
        }


        //  //  //INSERT

        public ActionResult Adicionar() //Pagina do formulario de cadastro de novos medicos
        {//Usando o  ViewBag para transferir dados do controler para as Views, atraves das prop IDCidade e IDEspecialidade
            //Cada uma das prop contem a lista de Cidades e Especialidades, SelectList();
            ViewBag.IDCidade = new SelectList(db.cidades, "IDCidade", "Nome");
            ViewBag.IDEspecialidade = new SelectList(db.especialidades, "IDEspecialidade", "Nome");
            return View();
        }
        [HttpPost] //Action que envia os dados do form ao server
        public ActionResult Adicionar(medicos medico)
        {
            if (ModelState.IsValid) //Chama a validação criada para cada prop das classes criadas como metadados
            {
                db.medicos.Add(medico);
                db.SaveChanges();
                return RedirectToAction("ListaMedicos"); //Retorna para a lista com os medicos cadastrados
            }
            ViewBag.IDCidade = new SelectList(db.cidades, "IDCidade", "Nome", medico.IDCidade);
            ViewBag.IDEspecialidade = new SelectList(db.especialidades, "IDEspecialidade", "Nome", medico.IDEspecialidade);

            return View(medico);
        }


        //  //  //UPDATE

        public ActionResult Editar(long id) //Mostra o form com os dados para serem Editados
        {
            medicos medico = db.medicos.Find(id); //Recupera os dados do medico pelo ID
            ViewBag.IDCidade = new SelectList(db.cidades, "IDCidade", "Nome", medico.IDCidade);
            ViewBag.IDEspecialidade = new SelectList(db.especialidades, "IDEspecialidade", "Nome", medico.IDEspecialidade);

            return View(medico);
        }

        [HttpPost]
        public ActionResult Editar(medicos medico) //Envia os dados alterados ao servidor de destino
        {
            if (ModelState.IsValid)
            {
                db.Entry(medico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ListaMedicos");
            }

            ViewBag.IDCidade = new SelectList(db.cidades, "IDCidade", "Nome", medico.IDCidade);
            ViewBag.IDEspecialidade = new SelectList(db.especialidades, "IDEspecialidade", "Nome");

            return View(medico);
        }

        //  //  // DELETE
        /*[HttpGet]
        public ActionResult Excluir(long id)
        {
            medicos medico = db.medicos.Find(id);
            if (medico != null)
            {
                db.medicos.Remove(medico);
                db.SaveChanges();
            }
            return RedirectToAction("ListaMedicos");
        }*/
        [HttpGet]
        public string Excluir(long id)
        {
            try
            {
                medicos medico = db.medicos.Find(id);
                db.medicos.Remove(medico);
                db.SaveChanges();
                return Boolean.TrueString;
            }
            catch
            {
                return Boolean.FalseString;
            }
        }
    }
}
