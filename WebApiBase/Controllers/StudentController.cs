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
        private readonly Message _message;

        public StudentController(StudentService studentServiceService, Message message)
        {
            _service = studentServiceService;
            _message = message;
        }

        [HttpGet]
        public string FindAll()
        {
            List<StudentDTO> studentDto = _service.FindAll();
            _message.code = true;
            _message.msg = "";
            _message.data = studentDto;
            return JsonHelper.toJson(_message);
        }

        [HttpPost]
        public long InsertOne(StudentModel studentModel)
        {
            long one = _service.InsertOne(studentModel);
            return one;
        }

        [HttpPost]
        public String InsertStudent(StudentModel studentModel)
        {
            StudentModel model = _service.Insert(studentModel);
            return JsonHelper.toJson(model);
        }

        [HttpDelete]
        public int DeleteById(int id)
        {
            int delete = _service.DeleteById(id);
            return delete;
        }
    }
}