using ecad.domain.MusicContext.Entities;
using ecad.domain.MusicContext.Queries;
using ecad.domain.MusicContext.Repositories;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ecad.infra.CrudMusicContext.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly EcadDataContext _context;

        public AuthorRepository(EcadDataContext context)
        {
            _context = context;
        }

        public void Delete(Author author)
        {
            _context.Authors.Remove(author);
            _context.SaveChanges();
        }

        public IEnumerable<GetAuthorQueryResult> GetAuthor()
        {
            var result = _context.Authors;
            var lst = new List<GetAuthorQueryResult>();
            foreach (var item in result)
            {
                lst.Add(new GetAuthorQueryResult()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Category = item.Category.ToString(),
                    Code = item.Code
                });
            }
            return lst;
        }

        public GetAuthorQueryResult GetAuthor(Guid id)
        {
            var author = _context.Authors.Single(x => x.Id == id);
            var query = new GetAuthorQueryResult();
            if (author != null)
            {
                query.Id = author.Id;
                query.Name = author.Name;
                query.Category = author.Category.ToString();
            }
            return query;
        }

        public IEnumerable<GetAuthorQueryResult> GetAuthor(string name)
        {
            var result = _context.Authors.Where(x => x.Name.Contains(name));
            var lst = new List<GetAuthorQueryResult>();
            foreach (var item in result)
            {
                lst.Add(new GetAuthorQueryResult()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Category = item.Category.ToString()
                });
            }
            return lst;
        }

        public IEnumerable<GetAuthorQueryResult> GetAuthorAvailableToMusic(Guid authorId)
        {
            var result = _context.Authors.Where(x => x.Id != authorId);
            var lst = new List<GetAuthorQueryResult>();
            foreach (var item in result)
            {
                lst.Add(new GetAuthorQueryResult()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Category = item.Category.ToString()
                });
            }
            return lst;
        }

        public Author GetAuthorById(Guid id)
        {
            return _context.Authors.SingleOrDefault(x => x.Id == id);
        }

        public void Save(Author author)
        {
            if (_context.Authors.Find(author.Id) == null)
            {
                _context.Add(author);
            }
            _context.SaveChanges();
        }
    }
}
