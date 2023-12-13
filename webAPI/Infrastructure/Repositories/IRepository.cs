namespace webAPI.Infrastructure.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();

        T? GetById(int id);

        bool Add(T entity);

        bool Edit(T entity);

        bool Delete(T entity);
    }
}