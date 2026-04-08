using LeituraFacil.Data;
using LeituraFacil.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeituraFacil.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;

        public HomeController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var destaques = await _db.Produtos
                .Where(p => p.Disponivel)
                .OrderByDescending(p => p.DataCadastro)
                .Take(6)
                .ToListAsync();

            var carrinho = CarrinhoHelper.ObterCarrinho(HttpContext.Session);
            ViewBag.TotalItensCarrinho = carrinho.TotalItens;

            return View(destaques);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
