using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CadeMeuMedico.Repositorios;
using System.Web.Mvc;

namespace CadeMeuMedico.Filtros
{
    [HandleError] //Decorando a classe como um gerenciador de erros automatizado
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    //Atraves da diretiva AttUsage informamos qual comportamento esperar ao utilizar o filtro
    public class AutorizacaoDeAcesso : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext FiltroDeContexto)
        {
            var Controller = FiltroDeContexto.ActionDescriptor.ControllerDescriptor.ControllerName;
            var Action = FiltroDeContexto.ActionDescriptor.ActionName;

            if (Controller != "Home" || Action != "Login")
            {
                if (RepositorioUsuario.VerificaSeOUsuarioEstaLogado() == null)
                {
                    FiltroDeContexto.RequestContext.HttpContext.Response.Redirect("/Home/Login?Url=" + 
                    FiltroDeContexto.HttpContext.Request.Url.LocalPath);
                }
            }
        }
    }
}