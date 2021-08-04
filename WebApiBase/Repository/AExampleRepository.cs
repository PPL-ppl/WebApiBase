using System.Collections.Generic;
using FreeSql;
using WebApiBase.IRepository;
using WebApiBase.Model;

namespace WebApiBase.Repository
{
    //仓储模式的使用
    public class AExampleRepository : BaseRepository<AExampleModel, int>, AExampleIRepository
    {
        private IFreeSql _sql;

        public AExampleRepository(IFreeSql sql) : base(sql, null, null)
        {
            _sql = sql;
        }

        public List<AExampleModel> FindAll()
        {
            List<AExampleModel> Models = _sql.Select<AExampleModel>().ToList();
            return Models;
        }

        public long InsertOne(AExampleModel model)
        {
            var count = _sql.Insert<AExampleModel>().AppendData(model)
                .ExecuteIdentity();
            return count;
        }
    }
}