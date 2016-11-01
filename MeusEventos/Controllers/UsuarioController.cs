using Cronometragem.NH.Config;
using Cronometragem.NH.Model;
using MeusEventos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeusEventos.Controllers
{
    public class UsuarioController : Controller
    {
        public object UsuarioUtils { get; private set; }

        // GET: Usuario
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GravarUsuario(Pessoa pessoa, Usuario usuario)
        {
            usuario.Pessoa = pessoa;
            pessoa.Usuarios.Add(usuario);

            ConfigDB.Instance.PessoaRepository.Gravar(pessoa);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Login(string Login, string Senha)
        {
            UsuariosUtils.Logar(Login, Senha);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult LogOut()
        {
            UsuariosUtils.Deslogar();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult VerificarLogin(string login)
        {
            try
            {
                var usuario = ConfigDB.Instance.UsuarioRepository.GetAll().FirstOrDefault(f => f.Login.ToLower() == login.ToLower());

                if (usuario != null)
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }

                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

        }
    }
}