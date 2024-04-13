using Microsoft.Extensions.DependencyInjection;
using Student_Management_No_Sql.Repository.Base;
using Student_Management_No_Sql.Repository.implementations;
using Student_Management_No_Sql.Repository.Interfaces;

namespace Student_Management_No_Sql.Repository
{
    public static class RepositoryDependency
    {
        public static void AddRepositoryDependency(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IStudentRepository, StudentRepository>();
        }
    }
}
