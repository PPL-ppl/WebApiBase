using System.Collections.Generic;
using WebApiBase.DTO;
using WebApiBase.Model;

namespace WebApiBase.IService
{
    public interface StudentIService
    {
        List<StudentDTO> FindAll();
        long InsertOne(StudentModel studentModel);
    }
}