using BibliotecaVirtual.Data;
using BibliotecaVirtual.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaVirtual.Services
{
    public class EditoraService
    {
        private readonly BibliotecaVirtualContext _context;

        public EditoraService(BibliotecaVirtualContext context)
        {
            _context = context;
        }

        public async Task<List<Editora>> FindAllAsyncAsNoTracking()
        {
            return await _context.Editora.AsNoTracking().ToListAsync();

        }
        public async Task<List<string>> FindDescricaoAsyncAsNoTracking()
        {
            return await _context.Editora.Select(obj => obj.Descricao)
                .AsNoTracking().ToListAsync();

        }

        public async Task<List<Editora>> FindAllAsync()
        {
            return await _context.Editora.ToListAsync();

        }
        public async Task<Editora?> FindByIdAsync(int id)
        {
            return await _context.Editora
                .FirstOrDefaultAsync(obj => obj.Id == id);
        }
        public async Task<Editora?> FindByIdAsyncAsNoTracking(int id)
        {
            return await _context.Editora.AsNoTracking()
                .FirstOrDefaultAsync(obj => obj.Id == id);
        }
        public async Task InsertAsync(Editora obj)
        {
            _context.Editora.Add(obj);
            await _context.SaveChangesAsync();
        }
        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Editora.FindAsync(id);
                _context.Editora.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {

                throw new Exception("Não foi possivel deletar o Editora por que ele tem vinculo");
            }
        }
        public async Task UpdateAsync(Editora obj)
        {
            // este if verifica se não existe algum objeto com - 
            // - este id no banco de dado
            bool hasAny = await _context.Editora.AnyAsync(x => x.Id == obj.Id);
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
