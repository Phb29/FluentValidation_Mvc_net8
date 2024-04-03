using FluentValidation_JwtToken.Models;
using FluentValidation_JwtToken.Service;
using FluentValidation_JwtToken.Validator;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidation_JwtToken.Controllers
{
    public class FilmeController : Controller
    {
        private readonly IFilme _filme;


        public FilmeController(IFilme filme)
        {
            _filme = filme;
        }
        public async Task<IActionResult> Index()
        {
            var filme = await _filme.ObterTodosFilmes();
            return View(filme);
        }
        [HttpPost]
        public async Task<IActionResult> New(Filme filme)
        {
            var validator = new FilmeValidator();
            var result = validator.Validate(filme);

            if (result.IsValid)
            {
                await _filme.AdicionarFilme(filme);
                TempData["sucess"] = "Filme Criado Com Sucesso!!";
                return RedirectToAction("New");
            }


            foreach (var failure in result.Errors)
            {
                ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
            }


            return View(filme);
        }


        [HttpGet]
        public IActionResult New()
        {
            return View();
        }
    
        [HttpGet]
        public IActionResult Delete(int? id)
        {

            _filme.Remove(id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)

        {
            var buscar = await _filme.BuscaFilmePorId(id);

            return View(buscar);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Filme filme)
        {
            if (ModelState.IsValid)
            {
              await _filme.AtualizarFilme(filme);
                TempData["MensagemSucesso"] = "Filme alterado com sucesso!";
                return RedirectToAction("Index");
            }
            return View(filme);

        }
    }
}