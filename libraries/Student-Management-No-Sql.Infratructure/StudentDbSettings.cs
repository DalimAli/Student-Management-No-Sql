using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_No_Sql.Infratructure
{
    public class StudentDbSettings
    {
        public string ConnectionString { get; set; } = null!; 

        public string DatabaseName { get; set; } = null!;

        public string StudentCollectionName { get; set; } = null!;
    }
}
