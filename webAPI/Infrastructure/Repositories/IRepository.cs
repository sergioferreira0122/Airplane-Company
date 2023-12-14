namespace webAPI.Infrastructure.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();

        T? GetById(int id);

        void Add(T entity);

        void Edit(T entity);

        void Delete(T entity);
    }
}