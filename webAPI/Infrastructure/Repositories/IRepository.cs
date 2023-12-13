namespace webAPI.Infrastructure.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> FindAll();

        T? FindById(int id);

        bool Add(T entity);

        bool Edit(T entity);

        bool Delete(T entity);
    }
}