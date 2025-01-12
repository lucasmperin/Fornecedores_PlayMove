using FornecedoresApp.DomainModels;

namespace FornecedoresApp.DomainServices.Interfaces
{
    public interface IFornecedoresService
    {
        Task<Fornecedor> GetByIdAsync(int id);
        Task<IEnumerable<Fornecedor>> GetAllAsync();
        Task AddAsync(Fornecedor fornecedor);
        void Update(Fornecedor fornecedor);
        void Delete(int id);
        Fornecedor Find(int id);
    }
}
