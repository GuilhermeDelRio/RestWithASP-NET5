using RestWithASPNET.Model;
using RestWithASPNET.Repository;
using System.Collections.Generic;

namespace RestWithASPNET.Business.Implementations {
    public class BooksBusinessImplementation : IBooksBusiness{

        private readonly IBooksRepository _repository;

        public BooksBusinessImplementation(IBooksRepository repository) {
            _repository = repository;
        }

        public Books Create(Books books) {
            return _repository.Create(books);
        }

        public void Delete(long id) {
            _repository.Delete(id);
        }

        public List<Books> FindAll() {
            return _repository.FindAll();
        }

        public Books FindById(long id) {
            return _repository.FindById(id);
        }

        public Books Update(Books books) {
            return _repository.Update(books);
        }
    }
}
