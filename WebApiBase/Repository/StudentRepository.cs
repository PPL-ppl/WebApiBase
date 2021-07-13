using System.Collections.Generic;
using FreeSql;
using WebApiBase.IRepository;
using WebApiBase.Model;

namespace WebApiBase.Repository
{
    //仓储模式的使用
    public class StudentRepository : BaseRepository<StudentModel, int>, StudentIRepository
    {
        private IFreeSql _sql;

        public StudentRepository(IFreeSql sql) : base(sql, null, null)
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