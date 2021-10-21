namespace AuthenticationService.Domain.Interfaces
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork StartUnitOfWork(bool usingTransaction = false);
    }
}
