using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DesafioWebMotors.Web.Models;
using DesafioWebMotors.Application.Interfaces;
using DesafioWebMotors.Application.ViewModels;
using System;
using Newtonsoft.Json;

namespace DesafioWebMotors.Web.Controllers
{
    public class AnuncioController : Controller
    {
        private readonly IServicoAnuncio _servicoAnuncio;
        private readonly IServicoApi _servicoApi;

        public AnuncioController(IServicoAnuncio servicoAnuncio,
            IServicoApi servicoApi)
        {
            this._servicoAnuncio = servicoAnuncio;
            this._servicoApi = servicoApi;
        }

        public IActionResult Index()
        {
            var anuncios = _servicoAnuncio.ObterTodos();

            if (anuncios == null)
                return View();

            return View(anuncios);
        }

        public IActionResult Adicionar()
        {
            ViewBag.ListaMarcas = JsonConvert.DeserializeObject(_servicoApi.ListarMarcas());
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Adicionar(AnuncioViewModel anuncio)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _servicoAnuncio.Adicionar(anuncio);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToActionPermanent("Index");
        }

        public IActionResult Editar(int ID)
        {
            var anuncio = _servicoAnuncio.ObterPeloID(ID);

            return View(anuncio);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Editar(AnuncioViewModel anuncio)
        {

            try
            {
                _servicoAnuncio.Atualizar(anuncio);
                _servicoAnuncio.SalvarAlteracoes();
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToActionPermanent("Index");

        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Remover(int ID)
        {
            var anuncio = _servicoAnuncio.ObterPeloID(ID);

            return View(anuncio);
        }

        [HttpPost]
        public IActionResult ConfirmarRemocao(int ID)
        {
            try
            {
                _servicoAnuncio.Remover(ID);
            }
            catch (Exception)
            { throw; }

            return RedirectToActionPermanent("Index");
        }

        [HttpGet]
        public string Marcas()
        {
            return _servicoApi.ListarMarcas();
        }

        public string Modelos(int ID)
        {
            return _servicoApi.ListarModelos(ID);
        }

        public string Versoes(int ModelId)
        {
            return _servicoApi.ListarVersoes(ModelId);
        }
    }
}
