using System.Collections.Generic;
using FreeSql;
using WebApiBase.Model;

namespace WebApiBase.IRepository
{
    public interface StudentIRepository
    {
        List<StudentModel> FindAll();
        long InsertOne(StudentModel studentModel);
    }
}