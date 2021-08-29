using System.Collections.Generic;
using RestWithASPNET.Model;
using RestWithASPNET.Model.Base;

namespace RestWithASPNET.Repository {
    public interface IRepository<T> where T : BaseEntity {
        T Create(T item);
        T FindById(long id);
        T Update(T item);
        void Delete(long id);
        List<T> FindAll();
        bool Exists(long id);
    }
}
