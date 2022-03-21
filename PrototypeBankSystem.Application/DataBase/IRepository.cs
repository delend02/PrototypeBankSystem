namespace PrototypeBankSystem.Application.DateBase
{
    public  interface IRepository<T>
        where T : class
    {
        IEnumerable<T> GetAll();
        Task Create(T entity);
        Task Update(T entity, T entityOld);
        Task Delete(T entity);
        Task Save(IEnumerable<T> ts); 
    }
}
