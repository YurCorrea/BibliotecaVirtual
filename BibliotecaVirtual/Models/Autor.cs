using System.ComponentModel.DataAnnotations;

namespace BibliotecaVirtual.Models
{
    public class Autor
    {
        public int Id { get; set; }
        //-------------------------------------
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "O campo {0} deve ter entre {2} a {1} caracteres")]
        public string Nome { get; set; }
        //-------------------------------------
        [StringLength(200, MinimumLength = 1, ErrorMessage = "O campo {0} deve ter entre {2} a {1} caracteres")]
        public string Descricao { get; set; }

        public ICollection<Livro> Livros { get; set; } = new List<Livro>();


    }
}
