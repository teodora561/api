namespace KbstAPI.Repository.BaseRepositories
{
    public interface IBaseRepository<T> where T : class 
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<bool> Add(T entity);
        void Update(T entity);
        void Delete(int id);
        Task<int> Save();
    }
}
