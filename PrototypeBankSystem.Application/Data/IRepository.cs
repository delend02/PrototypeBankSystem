namespace PrototypeBankSystem.Application.DateBase
{
    public  interface IRepository<T>
        where T : class
    {
        IEnumerable<T> GetAll();
        void Create(T entity);
        void Update(T entity, T entityOld);
        void Delete(T entity);
        void Save(IEnumerable<T> ts); 
    }
}
