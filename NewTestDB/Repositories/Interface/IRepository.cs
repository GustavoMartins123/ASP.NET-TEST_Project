namespace NewTestDB.Repositories.Interface
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Add(T entity);
        Task<T> Update(T entity, int id);
        Task<bool> Delete(int id);
    }
}
