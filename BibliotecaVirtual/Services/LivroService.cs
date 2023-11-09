using BibliotecaVirtual.Data;
using BibliotecaVirtual.Models;
using BibliotecaVirtual.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace BibliotecaVirtual.Services
{
    public class LivroService
    {
        private readonly BibliotecaVirtualContext _context;

        // ME EXPLICA MELHOR POR QUE TEM ESSE LIVROSERVICE QUE PASSA COMO PARAMETRO BIBLIOTECAVIRUTAL CONTEXT
        public LivroService(BibliotecaVirtualContext context)
        {
            _context = context;
        }

        public async Task<List<Livro>> FindAllAsyncAsNoTrackingInclude()
        {
            //Include
            return await _context.Livro
                .Include(x=>x.Autor).Include(x=>x.Editora)
                .AsNoTracking().ToListAsync();

        }

        public async Task<List<Livro>> GetLivrosByCategoria(CategoriaLivroEnum categoria)
        {
            return await _context.Livro
                .Where(x => x.Categoria == categoria)
                .OrderBy(x => x.Id).AsNoTracking().ToListAsync();
        }

        public async Task<List<Livro>> GetLivroByDataPublicacao(DateTime dataPublicacao)
        {
            return await _context.Livro
                 .Where(x=> x.DataPublicacao == dataPublicacao)
                 .Include(x=> x.Autor)
                 .AsNoTracking() .ToListAsync();
        }

        public async Task<List<Livro>> GetLivroBySerialNumber(string serialNumber)
        {
            return await _context.Livro
                .Where(x => x.SerialNumber == serialNumber)
                .AsNoTracking().ToListAsync();
        }
        public async Task<bool> ExisteSerialNumber(string serialNumber)
        {
            return await _context.Livro
                .AnyAsync(x => x.SerialNumber == serialNumber);
        }
        public async Task<List<Livro>> FindAllAsyncAsNoTracking()
        {
            return await _context.Livro.AsNoTracking().ToListAsync();

        }
        public async Task<List<string>> FindDescricaoAsyncAsNoTracking()
        {
            return await _context.Livro.Select(obj => obj.Descricao)
                .AsNoTracking().ToListAsync();

        }

        public async Task<List<Livro>> FindAllAsync()
        {
            return await _context.Livro.ToListAsync();

        }
        public async Task<Livro?> FindByIdAsync(int id)
        {
            return await _context.Livro
                .FirstOrDefaultAsync(obj => obj.Id == id);
        }
        public async Task<Livro?> FindByIdAsyncAsNoTracking(int id)
        {
            return await _context.Livro.AsNoTracking()
                .FirstOrDefaultAsync(obj => obj.Id == id);
        }
        public async Task InsertAsync(Livro obj)
        {
            _context.Livro.Add(obj);
            await _context.SaveChangesAsync();
        }
        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Livro.FindAsync(id);
                _context.Livro.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {

                throw new Exception("Não foi possivel deletar o Livro por que ele tem vinculo");
            }
        }
        public async Task UpdateAsync(Livro obj)
        {
            // este if verifica se não existe algum objeto com - 
            // - este id no banco de dado
            bool hasAny = await _context.Livro.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new Exception("Id not found");
            }

            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
