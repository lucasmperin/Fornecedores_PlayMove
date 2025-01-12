using FornecedoresApp.DomainModels;
using FornecedoresApp.Infrastructure;

namespace FornecedoresApp.Infrastructure.Repositories
{
    public class UnitOfWork(FornecedoresDbContext fornecedoresContext) : IUnitOfWork
    {
        private readonly FornecedoresDbContext _fornecedoresContext = fornecedoresContext;
        private readonly FornecedoresRepository _fornecedoresRepository;

        public IFornecedoresRepository FornecedoresRepository =>
            _fornecedoresRepository ?? new FornecedoresRepository(_fornecedoresContext);

        public int Complete() =>
            _fornecedoresContext.SaveChanges();

        public Task<int> CompleteAsync() =>
            _fornecedoresContext.SaveChangesAsync();
            
        public void Dispose() =>
            _fornecedoresContext.Dispose();

    }
}
