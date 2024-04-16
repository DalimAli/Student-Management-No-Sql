using Student_Management_No_Sql.Entities.Entities;

namespace Student_Management_No_Sql.Services.Interfaces;

public interface ICourseService
{
    public Task<IList<Course>> GetsAsync();
    public Task<Course?> FindByIdAsync(string id); 
    public Task CreateAsync(Course course);
    public Task UpdateAsync(Course course);
    public Task RemoveAsync(string id);
}