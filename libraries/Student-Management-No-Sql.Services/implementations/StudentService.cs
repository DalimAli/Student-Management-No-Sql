using Student_Management_No_Sql.Entities.Entities;
using Student_Management_No_Sql.Repository.Interfaces;
using Student_Management_No_Sql.Services.Interfaces;

namespace Student_Management_No_Sql.Services.implementations
{

    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<List<Student>> GetAsync() =>
                await _studentRepository.GetAsync();

        public async Task<Student?> GetAsync(string id) =>
            await _studentRepository.GetAsync(id);

        public async Task CreateAsync(Student newStudent) =>
            await _studentRepository.CreateAsync(newStudent);

        public async Task UpdateAsync(string id, Student updatedStudent) =>
            await _studentRepository.UpdateAsync(id, updatedStudent);

        public async Task RemoveAsync(string id) =>
            await _studentRepository.RemoveAsync(id);
    }
}
