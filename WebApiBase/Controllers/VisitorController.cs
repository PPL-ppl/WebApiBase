using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApiBase.Common;
using WebApiBase.Models;
using WebApiBase.Service;

namespace WebApiBase.Controllers
{
    /// <summary>
    /// 访客业务对外接口
    /// </summary>
    public class VisitorController : BaseController
    {
        private readonly VisitorService _visitorService;
        private readonly MessageModel _model;

        public VisitorController(VisitorService visitorService, MessageModel model)
        {
            _visitorService = visitorService;
            _model = model;
        }


        /// <summary>
        /// 查询当前有效的所有访客车牌
        /// </summary>
        /// <returns>
        /// </returns>
        [HttpGet]
        [Route("GetAll")]
        public MessageModel GetAll()
        {
            List<VisitorUserModel> visitorUserModels = _visitorService.GetAll();

            if (visitorUserModels.Count > 0)
            {
                _model.result = true;
                _model.message = "";
                _model.data = visitorUserModels;
            }
            else
            {
                _model.result = false;
                _model.message = "没有内容";
                _model.data = null;
            }

            return _model;
        }

        /// <summary>
        /// 查询当前符合条件的有效的所有访客车牌
        /// </summary>
        /// <returns>
        /// </returns>
        [HttpGet]
        [Route("GetAll")]
        public MessageModel Search(string str)
        {
            List<VisitorUserModel> visitorUserModels;

            if (str == null || str.Equals(""))
            {
                visitorUserModels = _visitorService.GetAll();
                _model.result = true;
                _model.message = "";
                _model.data = visitorUserModels;
            }
            else
            {
                str = Convert.ToString(str.Replace(" ", ""));
                visitorUserModels = _visitorService.Search(str);
                if (visitorUserModels.Count > 0)
                {
                    _model.result = true;
                    _model.message = "";
                    _model.data = visitorUserModels;
                }
                else
                {
                    _model.result = false;
                    _model.message = "没有内容";
                    _model.data = null;
                }
            }

            return _model;
        }

        /// <summary>
        /// 通过KeyId删除车辆信息
        /// </summary>
        /// <param name="keyId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("DeleteById")]
        public MessageModel DeleteById(string keyId)
        {
            try
            {
                int result;
                int.TryParse(keyId, out result);
                List<VisitorUserModel> deleteById = _visitorService.DeleteById(result);
                if (deleteById.Count != 0)
                {
                    _model.result = true;
                    _model.message = "删除成功";
                    _model.data = null;
                }
                else
                {
                    _model.result = false;
                    _model.message = "不存在";
                    _model.data = null;
                }
            }
            catch (Exception e)
            {
                _model.result = false;
                _model.message = "请输入正确数值";
                _model.data = null;
            }

            return _model;
        }

        /// <summary>
        /// 添加车辆信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Add")]
        public MessageModel Add(VisitorUserModel model)
        {
            DateTime begin = model.BeginTime;
            DateTime ending = model.EndingTime;
            if (begin.ToString() == "0001/1/1 0:00:00" | ending.ToString() == "0001/1/1 0:00:00" |
                DateTime.Compare(begin, ending) > 0)
            {
                _model.result = false;
                _model.message = "时间有问题";
                _model.data = null;
            }
            else
            {
                TimeSpan sp = model.EndingTime - model.BeginTime;
                model.EffectiveTime = sp.Days + "天" + sp.Hours + "小时" + sp.Minutes + "分钟";
                _visitorService.Add(model);
                _model.result = true;
                _model.message = "添加成功";
                _model.data = null;
            }

            return _model;
        }

        /// <summary>
        /// 更新车辆信息 KeyId必填
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Update")]
        public MessageModel Update(VisitorUserModel model)
        {
            DateTime begin = model.BeginTime;
            DateTime ending = model.EndingTime;
            if (begin.ToString() == "0001/1/1 0:00:00" | ending.ToString() == "0001/1/1 0:00:00" |
                DateTime.Compare(begin, ending) > 0 | DateTime.Compare(DateTime.Now, begin) > 0)
            {
                _model.result = false;
                _model.message = "时间有问题";
                _model.data = null;
                return _model;
            }

            long id = _visitorService.Update(model);

            if (id != 0)
            {
                _model.result = true;
                _model.message = "修改成功";
                _model.data = model;
            }
            else
            {
                _model.result = false;
                _model.message = "KeyId不存在，修改失败";
                _model.data = null;
            }

            return _model;
        }
    }
}