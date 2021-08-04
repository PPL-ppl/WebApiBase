using System.Collections.Generic;
using WebApiBase.Model;

namespace WebApiBase.IRepository
{
    public interface AExampleIRepository
    {
        List<AExampleModel> FindAll();
        long InsertOne(AExampleModel studentModel);
    }
}