using System.Collections.Generic;
using WebApiBase.Models;

namespace WebApiBase.IRepository
{
    /// <summary>
    /// 访客数据层接口
    /// </summary>
    public interface VisitorIRepository
    {
        /// <summary>
        /// 获取所有有效的访客信息
        /// </summary>
        /// <returns></returns>
        List<VisitorUserModel> GetAll();
        /// <summary>
        /// 通过Id删除访客信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<VisitorUserModel> DeleteById(int id);
        /// <summary>
        /// 添加访客车牌信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        long Add(VisitorUserModel model);
        /// <summary>
        /// 查询访客车牌信息
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        List<VisitorUserModel> Search(string str);
        
    }
}