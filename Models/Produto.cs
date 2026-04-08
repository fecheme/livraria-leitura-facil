using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeituraFacil.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O título é obrigatório")]
        [Display(Name = "Título")]
        [StringLength(200)]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "O autor é obrigatório")]
        [Display(Name = "Autor")]
        [StringLength(150)]
        public string Autor { get; set; } = string.Empty;

        [Required(ErrorMessage = "A descrição é obrigatória")]
        [Display(Name = "Descrição")]
        [StringLength(1000)]
        public string Descricao { get; set; } = string.Empty;

        [Required(ErrorMessage = "O preço é obrigatório")]
        [Display(Name = "Preço")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(0.01, 9999.99, ErrorMessage = "Preço deve ser entre R$0,01 e R$9.999,99")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "A categoria é obrigatória")]
        [Display(Name = "Categoria")]
        public string Categoria { get; set; } = string.Empty;

        [Display(Name = "URL da Imagem")]
        public string ImagemUrl { get; set; } = "/images/livro-default.jpg";

        [Display(Name = "Páginas")]
        public int Paginas { get; set; }

        [Display(Name = "ISBN")]
        [StringLength(20)]
        public string ISBN { get; set; } = string.Empty;

        [Display(Name = "Editora")]
        [StringLength(100)]
        public string Editora { get; set; } = string.Empty;

        [Display(Name = "Disponível")]
        public bool Disponivel { get; set; } = true;

        [Display(Name = "Data de Cadastro")]
        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}
