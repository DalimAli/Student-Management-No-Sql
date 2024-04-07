using Student_Management_No_Sql.Entities.Entities;

namespace Student_Management_No_Sql.Services.Interfaces
{
    public interface IStudentService
    {
        public Task<List<Student>> GetAsync();
        public Task<Student?> GetAsync(string id);
        public Task CreateAsync(Student newStudent);
        public Task UpdateAsync(string id, Student updatedStudent);
        public Task RemoveAsync(string id);
    }
}
