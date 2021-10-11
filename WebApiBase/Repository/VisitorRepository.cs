using System.Collections.Generic;
using WebApiBase.Common;
using WebApiBase.IRepository;
using WebApiBase.Models;

namespace WebApiBase.Repository
{
    /// <summary>
    /// 访客数据层接口实现
    /// </summary>
    public class VisitorRepository : VisitorIRepository
    {
        
        private IFreeSql _freeSql;
        public VisitorRepository(IFreeSql sql) 
        {
            _freeSql = sql;
        }
        /// <summary>
        /// 获取当前有效的访客车牌信息
        /// </summary>
        /// <returns></returns>
        public List<VisitorUserModel> GetAll()
        {
            List<VisitorUserModel> models = _freeSql.Select<VisitorUserModel>().ToList();
            return models;
        }

        /// <summary>
        /// 通过Id删除访客车牌信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<VisitorUserModel> DeleteById(int id)
        {
            List<VisitorUserModel> models = _freeSql.Delete<VisitorUserModel>(new { KeyId = id }).ExecuteDeleted();
            return models;
        }

        /// <summary>
        /// 添加访客车牌信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public long Add(VisitorUserModel model)
        {
            long count = _freeSql.Insert(model).ExecuteIdentity();
            return count;
        }

        /// <summary>
        /// 查询访客车牌信息
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public List<VisitorUserModel> Search(string str)
        {
            List<VisitorUserModel> list = _freeSql.Select<VisitorUserModel>()
                .Where((a) => a.CarNumber.Contains(str) || a.Name.Contains(str))
                .ToList();
            return list;
        }


        /// <summary>
        /// 修改访客车牌信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public long Update(VisitorUserModel model)
        {
            long count = _freeSql.Update<VisitorUserModel>()
                .Set(a => a.Name, model.Name)
                .Set(a => a.Company, model.Company)
                .Set(a => a.BeginTime, model.BeginTime)
                .Set(a => a.EndingTime, model.EndingTime)
                .Set(a => a.Message, model.Message)
                .Set(a => a.CarNumber, model.CarNumber)
                .Where(a => a.KeyId == model.KeyId)
                .ExecuteAffrows();
            return count;
        }
    }
}