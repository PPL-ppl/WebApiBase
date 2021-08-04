using WebApiBase.Model;

namespace WebApiBase.IService
{
    public interface AExampleIService
    {
        long InsertOne(AExampleModel model);
        AExampleModel Insert(AExampleModel model);
        int DeleteById(int id);
    }
}