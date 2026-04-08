using LeituraFacil.Data;
using LeituraFacil.Models;
using Microsoft.AspNetCore.Mvc;

namespace LeituraFacil.Controllers
{
    public class CarrinhoController : Controller
    {
        private readonly AppDbContext _db;

        public CarrinhoController(AppDbContext db)
        {
            _db = db;
        }

        // GET: Ver carrinho
        public IActionResult Index()
        {
            var carrinho = CarrinhoHelper.ObterCarrinho(HttpContext.Session);
            ViewBag.TotalItensCarrinho = carrinho.TotalItens;
            return View(carrinho);
        }

        // POST: Adicionar item
        [HttpPost]
        public async Task<IActionResult> Adicionar(int produtoId, int quantidade = 1)
        {
            var produto = await _db.Produtos.FindAsync(produtoId);
            if (produto == null || !produto.Disponivel)
                return NotFound();

            var carrinho = CarrinhoHelper.ObterCarrinho(HttpContext.Session);
            carrinho.AdicionarItem(produto, quantidade);
            CarrinhoHelper.SalvarCarrinho(HttpContext.Session, carrinho);

            TempData["Sucesso"] = $"\"{produto.Titulo}\" adicionado ao carrinho!";
            return RedirectToAction("Detalhes", "Produto", new { id = produtoId });
        }

        // POST: Alterar quantidade
        [HttpPost]
        public IActionResult AlterarQuantidade(int produtoId, int quantidade)
        {
            var carrinho = CarrinhoHelper.ObterCarrinho(HttpContext.Session);
            carrinho.AlterarQuantidade(produtoId, quantidade);
            CarrinhoHelper.SalvarCarrinho(HttpContext.Session, carrinho);
            return RedirectToAction(nameof(Index));
        }

        // POST: Remover item
        [HttpPost]
        public IActionResult Remover(int produtoId)
        {
            var carrinho = CarrinhoHelper.ObterCarrinho(HttpContext.Session);
            carrinho.RemoverItem(produtoId);
            CarrinhoHelper.SalvarCarrinho(HttpContext.Session, carrinho);
            TempData["Sucesso"] = "Item removido do carrinho.";
            return RedirectToAction(nameof(Index));
        }

        // POST: Limpar carrinho
        [HttpPost]
        public IActionResult Limpar()
        {
            var carrinho = CarrinhoHelper.ObterCarrinho(HttpContext.Session);
            carrinho.Limpar();
            CarrinhoHelper.SalvarCarrinho(HttpContext.Session, carrinho);
            return RedirectToAction(nameof(Index));
        }
    }
}
