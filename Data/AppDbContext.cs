using LeituraFacil.Models;
using Microsoft.EntityFrameworkCore;

namespace LeituraFacil.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
    }

    public static class SeedData
    {
        public static void Initialize(AppDbContext db)
        {
            if (db.Produtos.Any()) return;

            db.Produtos.AddRange(
                new Produto { Titulo = "O Senhor dos Anéis", Autor = "J.R.R. Tolkien", Descricao = "A épica aventura de Frodo e a Sociedade do Anel para destruir o Um Anel e salvar a Terra Média das forças do mal.", Preco = 89.90m, Categoria = "Fantasia", Paginas = 1216, Editora = "HarperCollins", ISBN = "978-0261102354", ImagemUrl = "https://covers.openlibrary.org/b/isbn/9780261102354-M.jpg" },
                new Produto { Titulo = "Dom Quixote", Autor = "Miguel de Cervantes", Descricao = "Clássico da literatura universal que narra as aventuras do cavaleiro andante Dom Quixote de La Mancha e seu fiel escudeiro Sancho Pança.", Preco = 54.90m, Categoria = "Clássico", Paginas = 1072, Editora = "Penguin Companhia", ISBN = "978-8563560278", ImagemUrl = "https://covers.openlibrary.org/b/isbn/9788563560278-M.jpg" },
                new Produto { Titulo = "1984", Autor = "George Orwell", Descricao = "Distopia clássica ambientada em um futuro totalitário onde o Grande Irmão controla todos os aspectos da vida.", Preco = 44.90m, Categoria = "Ficção Científica", Paginas = 352, Editora = "Companhia das Letras", ISBN = "978-8535914849", ImagemUrl = "https://covers.openlibrary.org/b/isbn/9788535914849-M.jpg" },
                new Produto { Titulo = "Harry Potter e a Pedra Filosofal", Autor = "J.K. Rowling", Descricao = "O início da jornada mágica de Harry Potter na Escola de Magia e Bruxaria de Hogwarts.", Preco = 59.90m, Categoria = "Fantasia", Paginas = 264, Editora = "Rocco", ISBN = "978-8532523051", ImagemUrl = "https://covers.openlibrary.org/b/isbn/9788532523051-M.jpg" },
                new Produto { Titulo = "O Pequeno Príncipe", Autor = "Antoine de Saint-Exupéry", Descricao = "Conto poético que narra o encontro de um aviador com um pequeno príncipe vindo de outro planeta.", Preco = 29.90m, Categoria = "Infantil", Paginas = 96, Editora = "Agir", ISBN = "978-8522005123", ImagemUrl = "https://covers.openlibrary.org/b/isbn/9788522005123-M.jpg" },
                new Produto { Titulo = "Sapiens: Uma Breve História da Humanidade", Autor = "Yuval Noah Harari", Descricao = "Uma viagem fascinante pela história da espécie humana, desde os primórdios até a atualidade.", Preco = 69.90m, Categoria = "Não-Ficção", Paginas = 456, Editora = "L&PM", ISBN = "978-8525432186", ImagemUrl = "https://covers.openlibrary.org/b/isbn/9788525432186-M.jpg" },
                new Produto { Titulo = "A Revolução dos Bichos", Autor = "George Orwell", Descricao = "Fábula política sobre uma revolução liderada pelos animais de uma fazenda que culmina em nova tirania.", Preco = 34.90m, Categoria = "Clássico", Paginas = 152, Editora = "Companhia das Letras", ISBN = "978-8535909555", ImagemUrl = "https://covers.openlibrary.org/b/isbn/9788535909555-M.jpg" },
                new Produto { Titulo = "O Código Da Vinci", Autor = "Dan Brown", Descricao = "Thriller de suspense envolvendo uma investigação sobre um assassinato no Museu do Louvre com pistas escondidas em obras de Da Vinci.", Preco = 49.90m, Categoria = "Thriller", Paginas = 480, Editora = "Sextante", ISBN = "978-8575422717", ImagemUrl = "https://covers.openlibrary.org/b/isbn/9788575422717-M.jpg" },
                new Produto { Titulo = "Cem Anos de Solidão", Autor = "Gabriel García Márquez", Descricao = "Obra-prima do realismo mágico que narra a história da família Buendía ao longo de sete gerações na cidade fictícia de Macondo.", Preco = 64.90m, Categoria = "Literatura", Paginas = 432, Editora = "Record", ISBN = "978-8501012081", ImagemUrl = "https://covers.openlibrary.org/b/isbn/9788501012081-M.jpg" },
                new Produto { Titulo = "Inteligência Artificial: Uma Abordagem Moderna", Autor = "Stuart Russell e Peter Norvig", Descricao = "O livro-texto definitivo sobre inteligência artificial, cobrindo desde fundamentos até técnicas avançadas de aprendizado de máquina.", Preco = 129.90m, Categoria = "Tecnologia", Paginas = 1132, Editora = "Campus", ISBN = "978-8535237016", ImagemUrl = "https://covers.openlibrary.org/b/isbn/9788535237016-M.jpg" }
            );

            db.SaveChanges();
        }
    }
}
