using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CadeMeuMedico.Repositorios
{
    public class RepositorioCookies
    {
        public static void RegistraCookieAutenticacao(long IDUsuario)
        {
            //Criando um objeto Cookie
            HttpCookie UserCookie = new HttpCookie("UserCookieAuthentication");

            //Setando o ID do Usuario no Cookie
            UserCookie.Values["IDUsuario"] = CadeMeuMedico.Repositorios.RepositorioCriptografia.Criptografar(IDUsuario.ToString());

            //Definindo o prazo de validade do Cookie
            UserCookie.Expires = DateTime.Now.AddDays(1);

            //Adicionando o Cookie no contexto da Aplicação
            HttpContext.Current.Response.Cookies.Add(UserCookie);
        }
    }
}