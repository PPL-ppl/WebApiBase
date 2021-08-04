using AutoMapper;
using WebApiBase.IService;
using WebApiBase.Model;
using WebApiBase.Repository;

namespace WebApiBase.Service
{
    public class AExampleService : AExampleIService
    {
        private readonly AExampleRepository _repository;
        private readonly IMapper _iMapper;

        public AExampleService(AExampleRepository Repository, IMapper mapper)
        {
            _repository = Repository;
            _iMapper = mapper;
        }


        public long InsertOne(AExampleModel model)
        {
            long one = _repository.InsertOne(model);
            return one;
        }

        public AExampleModel Insert(AExampleModel model)
        {
            AExampleModel models = _repository.Insert(model);
            return models;
        }

        public int DeleteById(int id)
        {
            int delete = _repository.Delete(id);
            return delete;
        }
    }
}