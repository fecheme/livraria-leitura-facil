# Livraria Leitura Fácil - E-Commerce

Projeto acadêmico de e-commerce desenvolvido com **ASP.NET Core MVC** e **C#**.

## 📋 Requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8) instalado
- Visual Studio 2022 **ou** VS Code com extensão C#

## 🚀 Como Rodar o Projeto

### Opção 1 — Visual Studio 2022
1. Abra o arquivo `LeituraFacil.csproj`
2. Aguarde o VS restaurar os pacotes NuGet automaticamente
3. Pressione **F5** para rodar

### Opção 2 — Terminal (qualquer SO)
```bash
# Entre na pasta do projeto
cd LeituraFacil

# Restaure os pacotes
dotnet restore

# Execute o projeto
dotnet run
```

Acesse em: **http://localhost:5000**

## 📁 Estrutura do Projeto

```
LeituraFacil/
├── Controllers/
│   ├── HomeController.cs        # Página inicial
│   ├── ProdutoController.cs     # CRUD de livros
│   └── CarrinhoController.cs   # Carrinho de compras
├── Models/
│   ├── Produto.cs               # Entidade Produto
│   └── Carrinho.cs              # Modelos do carrinho
├── Data/
│   ├── AppDbContext.cs          # Contexto EF Core + Seed (10 livros)
│   └── CarrinhoHelper.cs       # Gerenciamento de sessão
├── Views/
│   ├── Home/Index.cshtml        # Página inicial
│   ├── Produto/
│   │   ├── Catalogo.cshtml      # Listagem pública
│   │   ├── Detalhes.cshtml      # Página do produto
│   │   ├── Gerenciar.cshtml     # Painel admin
│   │   ├── Cadastrar.cshtml     # Formulário de cadastro
│   │   ├── Editar.cshtml        # Formulário de edição
│   │   └── Excluir.cshtml       # Confirmação de exclusão
│   └── Carrinho/
│       └── Index.cshtml         # Carrinho de compras
└── wwwroot/css/site.css         # Estilos customizados
```

## ✅ Funcionalidades

| Funcionalidade | Status |
|---|---|
| Cadastro de produtos | ✅ |
| Edição de produtos | ✅ |
| Exclusão de produtos | ✅ |
| Listagem de produtos | ✅ |
| Detalhes do produto | ✅ |
| Adicionar ao carrinho | ✅ |
| Alterar quantidade | ✅ |
| Remover do carrinho | ✅ |
| Filtro por categoria e busca | ✅ |
| 10 livros pré-cadastrados | ✅ |

## 🛠️ Tecnologias

- ASP.NET Core 8 MVC
- C#
- Entity Framework Core + SQLite
- Bootstrap 5
- Bootstrap Icons
- SQLite (banco de dados local, sem instalação)

## 📄 Banco de Dados

O sistema usa **SQLite**, que não requer instalação. O arquivo `leitura_facil.db` é criado automaticamente na primeira execução, já com 10 livros cadastrados.

---
*Projeto e Modelagem de Sistemas de Software — 2026*
