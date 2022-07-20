namespace PrototypeBankSystem.DAL.DataBase
{
    public interface IRepository<T>
        where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(string id);
        Task<T> GetByID(string id);
    }
}
