using System.ComponentModel.DataAnnotations;
using FreeSql.DataAnnotations;

namespace WebApiBase.Model
{
    [Table(Name = "student_model")]
    public class StudentModel
    {
       
        public int UUID { get; set; }

        public int id { get; set; }

        public string name { get; set; }
        
    }
}