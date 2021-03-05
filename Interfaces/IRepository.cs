using System.Collections.Generic;

namespace Series.Interfaces
{
    public interface IRepository<T>
    {
        // CRUD
        bool Create(T entity);
        bool ReadAll();
        bool Update(int id, T entity);
        bool Delete(int id);

        // Aditional resources
        bool ReadByID(int id);
        List<T> GetAll();
        T GetById(int id);
    }
}