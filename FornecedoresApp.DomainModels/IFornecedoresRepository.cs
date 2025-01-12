namespace FornecedoresApp.DomainModels
{
    public interface IFornecedoresRepository
    {
        Task<IEnumerable<Fornecedor>> GetAllAsync();
        Task<Fornecedor> GetByIdAsync(int id);
        Task AddAsync(Fornecedor fornecedor);
        void Update(Fornecedor fornecedor);
        void Delete(int id);
        Fornecedor Find(int id);
    }
}
