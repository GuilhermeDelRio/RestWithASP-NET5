using System.Collections.Generic;
using RestWithASPNET.Data.VO;
using RestWithASPNET.Hypermedia.Utils;

namespace RestWithASPNET.Business {
    public interface IPersonBusiness {
        PersonVO Create(PersonVO person);
        PersonVO FindById(long id);
        PersonVO Update(PersonVO person);
        PersonVO Disable(long id);
        void Delete(long id);
        List<PersonVO> FindAll();
        List<PersonVO> FindByName(string firstName, string lastName);
        PagedSearchVO<PersonVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page);
    }
}
