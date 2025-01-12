using FornecedoresApp.ApplicationModels.Entities;

namespace FornecedoresApp.ApplicationServices.Interfaces
{
    public interface IFornecedoresAppService
    {
        Task<FornecedoresResponse> GetByIdAsync(int id);
        Task<IEnumerable<FornecedoresResponse>> GetAllAsync();
        Task AddAsync(FornecedoresRequest fornecedor);
        void Update(FornecedoresRequest fornecedor, int id);
        void Delete(int id);
    }
}
