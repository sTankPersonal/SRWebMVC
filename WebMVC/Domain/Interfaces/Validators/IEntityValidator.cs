namespace WebMVC.Domain.Interfaces.Validators
{
    public interface IEntityValidator<T> where T : class
    {
        Task ValidateAsync(T entity);
        Task ValidateCreateAsync(T entity);
        Task ValidateUpdateAsync(T entity);
        Task ValidateDeleteAsync(T entity);
    }
}
