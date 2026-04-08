using LeituraFacil.Models;
using System.Text.Json;

namespace LeituraFacil.Data
{
    public static class CarrinhoHelper
    {
        private const string SessionKey = "Carrinho";

        public static Carrinho ObterCarrinho(ISession session)
        {
            var json = session.GetString(SessionKey);
            if (string.IsNullOrEmpty(json))
                return new Carrinho();
            return JsonSerializer.Deserialize<Carrinho>(json) ?? new Carrinho();
        }

        public static void SalvarCarrinho(ISession session, Carrinho carrinho)
        {
            session.SetString(SessionKey, JsonSerializer.Serialize(carrinho));
        }
    }
}
