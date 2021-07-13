using System.Collections.Generic;
using WebApiBase.Model;

namespace WebApiBase.IRepository
{
    public interface StudentIRepository
    {
        List<StudentModel> FindAll();
        long InsertOne(StudentModel studentModel);
    }
}