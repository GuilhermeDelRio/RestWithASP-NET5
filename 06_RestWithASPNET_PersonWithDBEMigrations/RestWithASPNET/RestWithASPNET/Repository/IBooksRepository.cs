using System.Collections.Generic;
using RestWithASPNET.Model;

namespace RestWithASPNET.Repository {
    public interface IBooksRepository {
        Books Create(Books books);
        Books FindById(long id);
        Books Update(Books books);
        void Delete(long id);
        List<Books> FindAll();
        bool Exists(long id);
    }
}
