using Cronometragem.NH.Config;
using Cronometragem.NH.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeusEventos.Controllers
{
    public class EventoController : Controller
    {
        // GET: Evento
        public ActionResult Eventos()
        {
            var eventos = ConfigDB.Instance.EventoRepository.GetAll();

            return View(eventos);
        }

        public ActionResult IncluirEventos()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GravarEvento(Evento evento)
        {
                ConfigDB.Instance.EventoRepository.Gravar(evento);

            return RedirectToAction("Eventos", "Evento");
        }

        public ActionResult AlterarEvento(int id)
        {
            var evento = ConfigDB.Instance.EventoRepository.GetAll().FirstOrDefault(x => x.Id == id);

            if(evento != null)
            {
                return View(evento);
            }

            return RedirectToAction("Index");
        }

        public ActionResult FaixasEventos(int id)
        {
            var evento = ConfigDB.Instance.EventoRepository.GetAll().FirstOrDefault(x => x.Id == id);

            if (evento != null)
            {
                var faixa = new Faixa()
                {
                    Evento = evento
                };
                return View(faixa);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult GravarFaixa(Faixa faixa)
        {
            ConfigDB.Instance.FaixaRepository.Gravar(faixa);
            return RedirectToAction("Eventos");
        }
    }
}