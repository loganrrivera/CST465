using System.Collections.Generic;
namespace Assignment3
{ 
    public interface IDataEntityRepository<T> where T : IDataEntity
    {
        T Get(int id);
        void Save(T entity);
        List<T> GetList();
    }
}