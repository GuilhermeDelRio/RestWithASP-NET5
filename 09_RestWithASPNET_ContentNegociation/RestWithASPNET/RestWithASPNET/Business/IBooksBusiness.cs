using System.Collections.Generic;
using RestWithASPNET.Data.VO;

namespace RestWithASPNET.Business {
    public interface IBooksBusiness {
        BooksVO Create(BooksVO books);
        BooksVO FindById(long id);
        BooksVO Update(BooksVO books);
        void Delete(long id);
        List<BooksVO> FindAll();
    }
}
