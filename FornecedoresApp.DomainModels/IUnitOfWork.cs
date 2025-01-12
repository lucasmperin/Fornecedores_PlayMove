namespace FornecedoresApp.DomainModels
{
    public interface IUnitOfWork : IDisposable
    {
        IFornecedoresRepository FornecedoresRepository { get; }
        Task<int> CompleteAsync();
        int Complete();
    }
}
