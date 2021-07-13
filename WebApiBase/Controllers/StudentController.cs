using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApiBase.Common;
using WebApiBase.DTO;
using WebApiBase.Model;
using WebApiBase.Service;

namespace WebApiBase.Controllers
{
    [ApiController]
    public class StudentController : BaseController
    {
        private readonly StudentService _service;

        public StudentController(StudentService studentService)
        {
            _service = studentService;
        }

        [HttpGet]
        public string AHello()
        {
            List<StudentDTO>   studentDto = _service.FindAll();
            return Newtonsoft.Json.JsonConvert.SerializeObject(studentDto);
        }

        [HttpPost]
        public long InsertOne(StudentModel studentModel)
        {
            long one = _service.InsertOne(studentModel);
            return one;
        }

        [HttpDelete]
        public long AHello(int id)
        {
            return id;
        }
    }
}