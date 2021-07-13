using System.Collections.Generic;
using WebApiBase.IRepository;
using WebApiBase.Model;

namespace WebApiBase.Repository
{
    public class StudentRepository : StudentIRepository
    {
        private IFreeSql _sql;

        public StudentRepository(IFreeSql sql)
        {
            _sql = sql;
        }

        public List<StudentModel> FindAll()
        {
            List<StudentModel> studentModels = _sql.Select<StudentModel>().ToList();
            return studentModels;
        }

        public long InsertOne(StudentModel studentModel)
        {
            var count = _sql.Insert<StudentModel>().AppendData(studentModel)
                .ExecuteIdentity();
            return count;
        }
    }
}