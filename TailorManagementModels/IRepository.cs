using System.Collections.Generic;

namespace TailorManagementModels
{

    public interface IRepository<T>
    {
        List<T> GetAll();
        T GetById(int id);
        T Insert(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
