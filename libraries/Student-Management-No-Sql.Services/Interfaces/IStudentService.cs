using Student_Management_No_Sql.Entities.Entities;

namespace Student_Management_No_Sql.Services.Interfaces
{
    public interface IStudentService
    {
        public Task<IList<Student>> GetsAsync();
        public Task<Student?> FindByIdAsync(string id); 
        public Task CreateAsync(Student newStudent);
        public Task UpdateAsync(Student updatedStudent);
        public Task RemoveAsync(string id);
    }
}
