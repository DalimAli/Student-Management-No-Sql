using Student_Management_No_Sql.Entities.Entities;
using Student_Management_No_Sql.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_No_Sql.Repository.Interfaces
{
    public interface IStudentRepository: IBaseRepository<Student, string>
    {

    }
}
