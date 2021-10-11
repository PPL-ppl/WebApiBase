using System;
using System.Collections.Generic;
using WebApiBase.IService;
using WebApiBase.Models;
using WebApiBase.Repository;

namespace WebApiBase.Service
{
    /// <summary>
    /// 访客业务接口实现
    /// </summary>
    public class VisitorService : VisitorIService
    {
        private readonly VisitorRepository _visitorRepository;

        public VisitorService(VisitorRepository visitorRepository)
        {
            _visitorRepository = visitorRepository;
        }

        /// <summary>
        /// 获取所有当前时间有效访客信息
        /// </summary>
        /// <returns>访客列表</returns>
        public List<VisitorUserModel> GetAll()
        {
            List<VisitorUserModel> models = _visitorRepository.GetAll();
            List<VisitorUserModel> visitorUserModel = new List<VisitorUserModel>(models.ToArray());
            foreach (VisitorUserModel model in models)
            {
                if (DateTime.Compare(DateTime.Now, model.EndingTime) > 0)
                {
                    visitorUserModel.Remove(model);
                }
            }

            foreach (VisitorUserModel model in visitorUserModel)
            {
                if (DateTime.Compare(DateTime.Now, model.BeginTime) > 0)
                {
                    TimeSpan sp = model.EndingTime - DateTime.Now;

                    model.EffectiveTime = sp.Days + "天" + sp.Hours + "小时" + sp.Minutes + "分钟";
                }
                else
                {
                    TimeSpan sp = model.EndingTime - model.BeginTime;
                    model.EffectiveTime = sp.Days + "天" + sp.Hours + "小时" + sp.Minutes + "分钟";
                }
            }

            return visitorUserModel;
        }

        /// <summary>
        ///通过ID删除车牌信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<VisitorUserModel> DeleteById(int id)
        {
            return _visitorRepository.DeleteById(id);
        }

        /// <summary>
        /// 添加访客车牌信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public long Add(VisitorUserModel model)
        {
            return _visitorRepository.Add(model);
        }

        /// <summary>
        /// 修改访客车牌信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public long Update(VisitorUserModel model)
        {
            return _visitorRepository.Update(model);
        }

        /// <summary>
        /// 查询符合所有条件的访客车牌信息
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public List<VisitorUserModel> Search(string str)
        {
            return _visitorRepository.Search(str);
        }
    }
}