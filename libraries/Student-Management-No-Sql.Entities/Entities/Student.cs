using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Student_Management_No_Sql.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Student_Management_No_Sql.Entities.Entities
{
    [BsonCollection("Students")]
    public class Student: BaseDocument
    {
        
        [Required]
        public string Name { get; set; }
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; } 
    }
}
