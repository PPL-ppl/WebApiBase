using System;
using System.Reflection;
using AutoMapper;
using WebApiBase.DTO;
using WebApiBase.Model;

namespace WebApiBase.AutoMapper
{
    public class StudentProfile : Profile
    {
        /// <summary>
        /// 配置构造函数，用来创建关系映射
        /// </summary>
        public StudentProfile()
        {
            CreateMap<Model.StudentModel, StudentDTO>();
        }
    }
}