using BibliotecaVirtual.Data;
using BibliotecaVirtual.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BibliotecaVirtual.Services
{
    public class AutorService
    {
        private readonly BibliotecaVirtualContext _context;

        public AutorService(BibliotecaVirtualContext context) { _context = context; }

        public async Task<List<Autor>> FindAllAsyncAsNoTracking() 
        {
            return await _context.Autor.AsNoTracking().ToListAsync();
        
        }
        public async Task<List<string>> FindDescricaoAsyncAsNoTracking()
        {
            return await _context.Autor.Select(obj => obj.Descricao)
                .AsNoTracking().ToListAsync();

        }

        public async Task<List<Autor>> FindAllAsync()
        {
            return await _context.Autor.ToListAsync();

        }
        public async Task<Autor?> FindByIdAsync(int id)
        {
            return await _context.Autor
                .FirstOrDefaultAsync(obj => obj.Id == id); 
        }
        public async Task<Autor?> FindByIdAsyncAsNoTracking(int id)
        {
            return await _context.Autor.AsNoTracking()
                .FirstOrDefaultAsync(obj => obj.Id == id);
        }
        public async Task InsertAsync(Autor obj)
        {
            _context.Autor.Add(obj);
            await _context.SaveChangesAsync();
        }
        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Autor.FindAsync(id);
                _context.Autor.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {

                throw new Exception("Não foi possivel deletar o Autor por que ele tem vinculo");
            }
        }
        public async Task UpdateAsync(Autor obj)
        {
            // este if verifica se não existe algum objeto com - 
            // - este id no banco de dado
            bool hasAny = await _context.Autor.AnyAsync(x => x.Id == obj.Id);
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
