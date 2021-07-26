using System.ComponentModel.DataAnnotations;
using WebApiBase.Common;
using WebApiBase.Model;

namespace WebApiBase.DTO
{
    public class StudentDTO
    {
        [Required] public int id { get; set; }
        public string name { get; set; }
    }
}