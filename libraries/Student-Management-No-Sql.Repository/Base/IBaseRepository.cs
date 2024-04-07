namespace Student_Management_No_Sql.Repository.Base
{
    public interface IBaseRepository<T, CN>  
        where T : class 
    {
        public Task<List<T>> GetAsync();

        public Task<T?> GetAsync(string id);

        public Task CreateAsync(T collection);

        public Task UpdateAsync(string id, T updatableCollection);

        public Task RemoveAsync(string id);
    }
}
