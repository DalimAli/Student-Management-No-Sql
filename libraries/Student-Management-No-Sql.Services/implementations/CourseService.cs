using Student_Management_No_Sql.Entities.Entities;
using Student_Management_No_Sql.Repository.Interfaces;
using Student_Management_No_Sql.Services.Interfaces;

namespace Student_Management_No_Sql.Services.implementations;

public class CourseService: ICourseService
{
    private readonly ICourseRepository _courseRepository;

    public CourseService(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<IList<Course>> GetsAsync() =>
        await _courseRepository.GetsAsync();

    public async Task<Course?> FindByIdAsync(string id) =>
        await _courseRepository.FindByIdAsync(id); 

    public async Task CreateAsync(Course newCourse) =>
        await _courseRepository.InsertOneAsync(newCourse);

    public async Task UpdateAsync(Course updatedCourse) =>
        await _courseRepository.ReplaceOneAsync( updatedCourse);

    public async Task RemoveAsync(string id) =>
        await _courseRepository.DeleteByIdAsync(id);
}