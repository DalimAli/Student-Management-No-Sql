
using Microsoft.Extensions.Options;
using Student_Management_No_Sql.Cache;
using Student_Management_No_Sql.Infratructure;
using Student_Management_No_Sql.Repository;
using Student_Management_No_Sql.Services;

namespace Student_Management_No_Sql
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.Configure<StudentDbSettings>(builder.Configuration.GetSection("StudentDatabase"));

            builder.Services.AddSingleton<IStudentDbSettings>(sp => 
            sp.GetRequiredService<IOptions<StudentDbSettings>>().Value);

            builder.Services.AddRepositoryDependency();
            builder.Services.AddServiceDependency();
            builder.Services.AddScoped<ICacheService, CacheService>();

            builder.Services.AddControllers().AddJsonOptions(
            options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

            var redisConfig = builder.Configuration.GetSection("AppSettings:Redis");
            var redisConnectionString = redisConfig["Connection"];
            builder.Services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = redisConnectionString;
                options.InstanceName = "StudentManagementNoSql";
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
