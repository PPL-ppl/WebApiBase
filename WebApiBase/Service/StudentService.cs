using System.Collections.Generic;
using AutoMapper;
using WebApiBase.AutoMapper;
using WebApiBase.Common;
using WebApiBase.DTO;
using WebApiBase.IRepository;
using WebApiBase.IService;
using WebApiBase.Model;
using WebApiBase.Repository;

namespace WebApiBase.Service
{
    public class StudentService : StudentIService
    {
        private readonly StudentRepository _studentRepository;
        private readonly IMapper _iMapper;

        public StudentService(StudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _iMapper = mapper;
        }

        public List<StudentDTO> FindAll()
        {
            List<StudentModel> studentModels = _studentRepository.FindAll();
            if (studentModels != null)
            {
                var studentDto = _iMapper.Map<List<StudentModel>, List<StudentDTO>>(studentModels);
                return studentDto;
            }
            else
            {
                return null;
            }
        }

        public long InsertOne(StudentModel studentModel)
        {
            long one = _studentRepository.InsertOne(studentModel);
            return one;
        }
    }
}