using AutoMapper;
using FornecedoresApp.ApplicationModels.Entities;
using FornecedoresApp.ApplicationServices.Interfaces;
using FornecedoresApp.DomainModels;
using FornecedoresApp.DomainServices.Interfaces;

namespace FornecedoresApp.ApplicationServices.Services
{
    public class FornecedoresAppService(IFornecedoresService fornecedoresService, IMapper mapper) : IFornecedoresAppService
    {
        private readonly IFornecedoresService _fornecedoresService = fornecedoresService;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<FornecedoresResponse>> GetAllAsync()
        {
            var fornecedores = await _fornecedoresService.GetAllAsync();
            return _mapper.Map<IEnumerable<FornecedoresResponse>>(fornecedores);
        }

        public async Task<FornecedoresResponse> GetByIdAsync(int id)
        {
            var fornecedor = await _fornecedoresService.GetByIdAsync(id);
            return _mapper.Map<FornecedoresResponse>(fornecedor);
        }

        public async Task AddAsync(FornecedoresRequest fornecedor)
        {
            var fornecedorMapped = _mapper.Map<Fornecedor>(fornecedor);
            await _fornecedoresService.AddAsync(fornecedorMapped);
        }

        public void Update(FornecedoresRequest fornecedor, int id)
        {
            var fornecedorMapped = _mapper.Map<Fornecedor>(fornecedor);
            fornecedorMapped.Id = id;
            _fornecedoresService.Update(fornecedorMapped);
        }

        public void Delete(int id)
        {
            _fornecedoresService.Delete(id);
        }
    }
}
