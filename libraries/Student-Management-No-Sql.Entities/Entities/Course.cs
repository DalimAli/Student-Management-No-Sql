using System.ComponentModel.DataAnnotations;
using Student_Management_No_Sql.Entities.Base;

namespace Student_Management_No_Sql.Entities.Entities;
[BsonCollection("Courses")]
public class Course: BaseDocument
{
    [Required]
    [MaxLength(5)]
    [MinLength(5)]
    public string Code { get; set; }
    [Required]
    public string Name { get; set; } 
}