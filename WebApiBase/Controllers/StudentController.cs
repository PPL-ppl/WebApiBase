using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApiBase.Common;
using WebApiBase.DTO;
using WebApiBase.IService;
using WebApiBase.Model;
using WebApiBase.Service;

namespace WebApiBase.Controllers
{
    [ApiController]
    public class StudentController : BaseController
    {
        private readonly StudentService _service;

        public StudentController(StudentService studentServiceService)
        {
            _service = studentServiceService;
        }

        [HttpGet]
        public string FindAll()
        {
            List<StudentDTO> studentDto = _service.FindAll();
            return Newtonsoft.Json.JsonConvert.SerializeObject(studentDto);
        }

        [HttpPost]
        public long InsertOne(StudentModel studentModel)
        {
            long one = _service.InsertOne(studentModel);
            return one;
        }

        [HttpPost]
        public String InsertModel(StudentModel studentModel)
        {
            StudentModel model = _service.Insert(studentModel);
            return Newtonsoft.Json.JsonConvert.SerializeObject(model);
        }

        [HttpDelete]
        public long AHello(int id,string name)
        {
  
            return id;
        }
        
    }
}