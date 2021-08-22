using System.Collections.Generic;
using RestWithASPNET.Model;

namespace RestWithASPNET.Repository {
    public interface IPersonRepository {
        Person Create(Person person);
        Person FindById(long id);
        Person Update(Person person);
        void Delete(long id);
        List<Person> FindAll();
        bool Exists(long id);
    }
}
