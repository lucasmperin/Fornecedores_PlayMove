using FornecedoresApp.DomainModels;
using FornecedoresApp.DomainServices.Interfaces;

namespace FornecedoresApp.DomainServices.Services
{

    public class FornecedoresService(IUnitOfWork unitOfWork) : IFornecedoresService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<IEnumerable<Fornecedor>> GetAllAsync()
        {
            try
            {
                var fornecedores = await _unitOfWork.FornecedoresRepository.GetAllAsync();

                if (!fornecedores.Any())
                {
                    throw new KeyNotFoundException("Nenhum fornecedor cadastrado.");
                }

                return fornecedores;
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException("Erro ao obter todos os fornecedores.", ex);
            }
        }

        public async Task<Fornecedor> GetByIdAsync(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentException("ID inválido. Informe um ID maior que 0.");
                }

                var fornecedor = await _unitOfWork.FornecedoresRepository.GetByIdAsync(id);

                return fornecedor ?? throw new KeyNotFoundException($"Fornecedor com ID: {id} não encontrado.");
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException("Erro ao obter fornecedor por ID.", ex);
            }
        }

        public async Task AddAsync(Fornecedor fornecedor)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(fornecedor, "Fornecedor não pode ser nulo");

                await _unitOfWork.FornecedoresRepository.AddAsync(fornecedor);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao adicionar fornecedor.", ex);
            }
        }

        public void Update(Fornecedor fornecedor)
        {
            try
            {
                var fornecedorExistente = _unitOfWork.FornecedoresRepository.Find(fornecedor.Id) ?? throw new KeyNotFoundException($"Fornecedor com ID: {fornecedor.Id} não encontrado");

                fornecedor.DataCadastro = DateTime.Now;

                fornecedor.Nome = fornecedor.Nome ?? fornecedorExistente.Nome;
                fornecedor.CNPJ = fornecedor.CNPJ ?? fornecedorExistente.CNPJ;
                fornecedor.NomeResponsavel = fornecedor.NomeResponsavel ?? fornecedorExistente.NomeResponsavel;
                fornecedor.Email = fornecedor.Email ?? fornecedorExistente.Email;
                fornecedor.Telefone = fornecedor.Telefone ?? fornecedorExistente.Telefone;
                fornecedor.Endereco = fornecedor.Endereco ?? fornecedorExistente.Endereco;
                fornecedor.Cidade = fornecedor.Cidade ?? fornecedorExistente.Cidade;
                fornecedor.Estado = fornecedor.Estado ?? fornecedorExistente.Estado;
                fornecedor.CEP = fornecedor.CEP ?? fornecedorExistente.CEP;

                _unitOfWork.FornecedoresRepository.Update(fornecedor);
                _unitOfWork.Complete();
            }
            catch (KeyNotFoundException ex)
            {
                throw new KeyNotFoundException($"Fornecedor com ID: {fornecedor.Id} não encontrado", ex);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException("Erro ao atualizar fornecedor.", ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                _unitOfWork.FornecedoresRepository.Delete(id);
                _unitOfWork.Complete();
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException("Erro ao excluir fornecedor.", ex);
            }
        }

        public Fornecedor Find(int id)
        {
            return _unitOfWork.FornecedoresRepository.Find(id);
        }
    }
}
