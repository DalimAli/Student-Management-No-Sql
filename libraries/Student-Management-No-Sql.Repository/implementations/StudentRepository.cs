using Student_Management_No_Sql.Entities.Entities;
using Student_Management_No_Sql.Infratructure;
using Student_Management_No_Sql.Repository.Base;
using Student_Management_No_Sql.Repository.Interfaces;

namespace Student_Management_No_Sql.Repository.implementations
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(IStudentDbSettings studentDbSettings)  : base(studentDbSettings)
        {

        }

    }
}
