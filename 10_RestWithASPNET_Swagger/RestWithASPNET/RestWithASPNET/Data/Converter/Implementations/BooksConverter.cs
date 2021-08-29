using RestWithASPNET.Data.Converter.Contract;
using RestWithASPNET.Data.VO;
using RestWithASPNET.Model;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNET.Data.Converter.Implementations {
    public class BooksConverter : IParser<BooksVO, Books>, IParser<Books, BooksVO> {
        public Books Parse(BooksVO origin) {
            if (origin == null) return null;
            return new Books {
                Id = origin.Id,
                Author = origin.Author,
                LaunchDate = origin.LaunchDate,
                Price = origin.Price,
                Title = origin.Title
            };
        }

        public BooksVO Parse(Books origin) {
            if (origin == null) return null;
            return new BooksVO {
                Id = origin.Id,
                Author = origin.Author,
                LaunchDate = origin.LaunchDate,
                Price = origin.Price,
                Title = origin.Title
            };
        }

        public List<BooksVO> Parse(List<Books> origin) {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<Books> Parse(List<BooksVO> origin) {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
