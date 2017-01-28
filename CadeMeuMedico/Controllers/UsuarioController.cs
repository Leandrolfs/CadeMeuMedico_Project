using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CadeMeuMedico.Repositorios;
using CadeMeuMedico.Models;

namespace CadeMeuMedico.Controllers
{

    public class UsuarioController : Controller
    {
        private cademeumedicoEntities db = new cademeumedicoEntities();

        [HttpGet] //Indica que o metodo apenas devolvera dados para o chamador
        public JsonResult AutenticacaoDeUsuario(string Login, string Senha)
        {
            if (RepositorioUsuario.AutenticarUsuario(Login, Senha))
            {
                return Json(new {
                    OK=true,
                    Mensagem = "Usuário autenticado. Redirecionando..." },
                    JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new
                {
                    Ok = false,
                    Mensagem = "Usuário não encontrado. Tente novamente.."
                },
                    JsonRequestBehavior.AllowGet);
            }
        }
    }
}
