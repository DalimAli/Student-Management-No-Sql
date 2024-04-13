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

        public async Task<IList<Student>> GetsAsync() =>
                await _studentRepository.GetsAsync();

        public async Task<Student?> FindByIdAsync(string id) =>
            await _studentRepository.FindByIdAsync(id); 

        public async Task CreateAsync(Student newStudent) =>
            await _studentRepository.InsertOneAsync(newStudent);

        public async Task UpdateAsync(Student updatedStudent) =>
            await _studentRepository.ReplaceOneAsync( updatedStudent);

        public async Task RemoveAsync(string id) =>
            await _studentRepository.DeleteByIdAsync(id);
    }
}
