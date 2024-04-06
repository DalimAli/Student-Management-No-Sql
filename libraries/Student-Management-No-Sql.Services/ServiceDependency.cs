using Microsoft.Extensions.DependencyInjection;
using Student_Management_No_Sql.Services.implementations;
using Student_Management_No_Sql.Services.Interfaces;

namespace Student_Management_No_Sql.Services
{
    public static class ServiceDependency
    {
        public static void AddServiceDependency(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IStudentService, StudentService>();
        }
    }
}
