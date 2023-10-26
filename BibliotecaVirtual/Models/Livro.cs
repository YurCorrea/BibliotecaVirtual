using BibliotecaVirtual.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaVirtual.Models
{
    public class Livro
    {
        public int Id { get; set; }

        //-----------------------------------
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "O campo {0} deve ter entre {2} a {1} caracteres")]
        public string Nome { get; set; }

        //-----------------------------------
        [StringLength(200, MinimumLength = 3, ErrorMessage = "O campo {0} deve ter entre {2} a {1} caracteres")]
        public string Descricao { get; set; }

        //-----------------------------------
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "O campo {0} deve ter entre {2} a {1} caracteres")]
        public string SerialNumber {  get; set; }

        //-----------------------------------
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public CategoriaLivroEnum Categoria { get; set; }

        //-----------------------------------
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public DateTime DataPublicacao { get; set; }

        public int AutorId { get; set; }
        public virtual Autor Autor { get; set; }

        public int EditoraId { get; set; }
        public virtual Editora Editora { get; set; }


    }
}
