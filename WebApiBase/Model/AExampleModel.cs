using FreeSql.DataAnnotations;

namespace WebApiBase.Model
{
    [Table(Name = "student_model")]
    public class AExampleModel
    {
       
        public int UUID { get; set; }

        public int id { get; set; }

        public string name { get; set; }
        
    }
}