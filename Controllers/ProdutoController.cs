using LeituraFacil.Data;
using LeituraFacil.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeituraFacil.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly AppDbContext _db;

        public ProdutoController(AppDbContext db)
        {
            _db = db;
        }

        private void SetCarrinhoViewBag()
        {
            var carrinho = CarrinhoHelper.ObterCarrinho(HttpContext.Session);
            ViewBag.TotalItensCarrinho = carrinho.TotalItens;
        }

        // GET: Catálogo público de produtos
        public async Task<IActionResult> Catalogo(string? categoria, string? busca)
        {
            SetCarrinhoViewBag();
            var query = _db.Produtos.Where(p => p.Disponivel).AsQueryable();

            if (!string.IsNullOrEmpty(categoria))
                query = query.Where(p => p.Categoria == categoria);

            if (!string.IsNullOrEmpty(busca))
                query = query.Where(p => p.Titulo.Contains(busca) || p.Autor.Contains(busca));

            ViewBag.Categorias = await _db.Produtos.Select(p => p.Categoria).Distinct().ToListAsync();
            ViewBag.CategoriaAtual = categoria;
            ViewBag.Busca = busca;

            return View(await query.OrderBy(p => p.Titulo).ToListAsync());
        }

        // GET: Detalhes do produto
        public async Task<IActionResult> Detalhes(int id)
        {
            SetCarrinhoViewBag();
            var produto = await _db.Produtos.FindAsync(id);
            if (produto == null) return NotFound();
            return View(produto);
        }

        // GET: Gerenciamento (admin)
        public async Task<IActionResult> Gerenciar()
        {
            SetCarrinhoViewBag();
            return View(await _db.Produtos.OrderByDescending(p => p.DataCadastro).ToListAsync());
        }

        // GET: Cadastrar
        public IActionResult Cadastrar()
        {
            SetCarrinhoViewBag();
            return View();
        }

        // POST: Cadastrar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastrar(Produto produto)
        {
            if (ModelState.IsValid)
            {
                produto.DataCadastro = DateTime.Now;
                if (string.IsNullOrEmpty(produto.ImagemUrl))
                    produto.ImagemUrl = "/images/livro-default.jpg";
                _db.Produtos.Add(produto);
                await _db.SaveChangesAsync();
                TempData["Sucesso"] = $"Livro \"{produto.Titulo}\" cadastrado com sucesso!";
                return RedirectToAction(nameof(Gerenciar));
            }
            SetCarrinhoViewBag();
            return View(produto);
        }

        // GET: Editar
        public async Task<IActionResult> Editar(int id)
        {
            SetCarrinhoViewBag();
            var produto = await _db.Produtos.FindAsync(id);
            if (produto == null) return NotFound();
            return View(produto);
        }

        // POST: Editar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, Produto produto)
        {
            if (id != produto.Id) return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    _db.Produtos.Update(produto);
                    await _db.SaveChangesAsync();
                    TempData["Sucesso"] = $"Livro \"{produto.Titulo}\" atualizado com sucesso!";
                    return RedirectToAction(nameof(Gerenciar));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _db.Produtos.AnyAsync(p => p.Id == id)) return NotFound();
                    throw;
                }
            }
            SetCarrinhoViewBag();
            return View(produto);
        }

        // GET: Confirmar Exclusão
        public async Task<IActionResult> Excluir(int id)
        {
            SetCarrinhoViewBag();
            var produto = await _db.Produtos.FindAsync(id);
            if (produto == null) return NotFound();
            return View(produto);
        }

        // POST: Excluir
        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarExclusao(int id)
        {
            var produto = await _db.Produtos.FindAsync(id);
            if (produto != null)
            {
                _db.Produtos.Remove(produto);
                await _db.SaveChangesAsync();
                TempData["Sucesso"] = $"Livro \"{produto.Titulo}\" excluído com sucesso!";
            }
            return RedirectToAction(nameof(Gerenciar));
        }
    }
}
