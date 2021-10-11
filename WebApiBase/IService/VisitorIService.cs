using System.Collections.Generic;
using WebApiBase.Models;

namespace WebApiBase.IService
{
    /// <summary>
    /// 访客业务接口
    /// </summary>
    public interface VisitorIService
    {
        /// <summary>
        /// 获取所有有效的访客车牌信息
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
        /// 添加访客信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        long Add(VisitorUserModel model);

        /// <summary>
        /// 更新车牌信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        long Update(VisitorUserModel model);
        
        
        /// <summary>
        /// 查询符合条件的访客车牌信息
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        List<VisitorUserModel> Search(string str);
    }
}