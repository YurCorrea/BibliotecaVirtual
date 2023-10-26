using BibliotecaVirtual.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaVirtual.Data
    //CLASSE DE INTERFACE PARA CONEXÃO COM O BANCO DE DADOS
{
    public class BibliotecaVirtualContext : DbContext
    {
        public BibliotecaVirtualContext (DbContextOptions<BibliotecaVirtualContext> options) : base(options)
        {
        }
        public DbSet<Autor> Autor { get; set; }
        public DbSet<Livro> Livro { get; set; }
        public DbSet<Editora> Editora { get; set; }

    }
}
