namespace LeituraFacil.Models
{
    public class CarrinhoItem
    {
        public int ProdutoId { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public string ImagemUrl { get; set; } = string.Empty;

        public decimal Subtotal => Preco * Quantidade;
    }

    public class Carrinho
    {
        public List<CarrinhoItem> Itens { get; set; } = new();

        public decimal Total => Itens.Sum(i => i.Subtotal);
        public int TotalItens => Itens.Sum(i => i.Quantidade);

        public void AdicionarItem(Produto produto, int quantidade = 1)
        {
            var item = Itens.FirstOrDefault(i => i.ProdutoId == produto.Id);
            if (item != null)
                item.Quantidade += quantidade;
            else
                Itens.Add(new CarrinhoItem
                {
                    ProdutoId = produto.Id,
                    Titulo = produto.Titulo,
                    Autor = produto.Autor,
                    Preco = produto.Preco,
                    Quantidade = quantidade,
                    ImagemUrl = produto.ImagemUrl
                });
        }

        public void RemoverItem(int produtoId)
        {
            Itens.RemoveAll(i => i.ProdutoId == produtoId);
        }

        public void AlterarQuantidade(int produtoId, int novaQuantidade)
        {
            var item = Itens.FirstOrDefault(i => i.ProdutoId == produtoId);
            if (item != null)
            {
                if (novaQuantidade <= 0)
                    RemoverItem(produtoId);
                else
                    item.Quantidade = novaQuantidade;
            }
        }

        public void Limpar() => Itens.Clear();
    }
}
