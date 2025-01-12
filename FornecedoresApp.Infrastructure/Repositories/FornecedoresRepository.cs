using FornecedoresApp.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace FornecedoresApp.Infrastructure.Repositories
{
    public class FornecedoresRepository(FornecedoresDbContext fornecedoresContext) : IFornecedoresRepository
    {

        private readonly FornecedoresDbContext _fornecedoresContext = fornecedoresContext;
        private readonly DbSet<Fornecedor> _dbSet = fornecedoresContext.Set<Fornecedor>();

        public async Task<IEnumerable<Fornecedor>> GetAllAsync() =>
            await _dbSet.ToListAsync();
        

        public async Task<Fornecedor> GetByIdAsync(int id) =>
            await _dbSet.FindAsync(id);
        
        public async Task AddAsync(Fornecedor fornecedor)
        {
            await _dbSet.AddAsync(fornecedor);
        }

        public void Update(Fornecedor fornecedor)
        {
            _dbSet.Update(fornecedor);
        }

        public void Delete(int id)
        { 
            var fornecedor = _dbSet.Find(id);
            _dbSet.Remove(fornecedor);
        }

        public Fornecedor Find(int id) =>
            _dbSet.AsNoTracking().FirstOrDefault(f => f.Id.Equals(id));
    }
}
