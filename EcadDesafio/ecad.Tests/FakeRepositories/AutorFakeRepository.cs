using ecad.domain.MusicContext.Entities;
using ecad.domain.MusicContext.Enums;
using ecad.domain.MusicContext.Queries;
using ecad.domain.MusicContext.Repositories;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ecad.Tests.FakeRepositories
{
    public class AutorFakeRepository : IAuthorRepository
    {
        List<Author> _lstAuthor;

        public AutorFakeRepository()
        {
            _lstAuthor = new List<Author>();
            GetListAuthor(_lstAuthor);
        }

   
        private void GetListAuthor(List<Author> lst)
        {
            lst.Add(new Author("012345","Joao", ECategoryAuthor.Author));
            lst.Add(new Author("012345", "Maria", ECategoryAuthor.Composer));
            lst.Add(new Author("012345", "Rosa", ECategoryAuthor.Musician));
            lst.Add(new Author("012345", "Cesar", ECategoryAuthor.Other));
            lst.Add(new Author("012345", "Nara", ECategoryAuthor.Author));
        }

        public void GetListAuthorExtern(List<Author> lst)
        {
            lst.AddRange(_lstAuthor);
        }

        public Author GetFirsMusic()
        {
            return _lstAuthor.FirstOrDefault();
        }


        public IEnumerable<GetAuthorQueryResult> GetAuthor()
        {
            
            var lstQuery = new List<GetAuthorQueryResult>();

            foreach (var item in _lstAuthor)
            {
                lstQuery.Add(new GetAuthorQueryResult()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Category = item.Category.ToString()
                });
            }

            return lstQuery;
        }

        public GetAuthorQueryResult GetAuthor(Guid id)
        {
            
            var author = _lstAuthor.SingleOrDefault(x => x.Id == id);
            var query = new GetAuthorQueryResult()
            {
                Id = author.Id,
                Name = author.Name,
                Category = author.Category.ToString()
            };
            return query;
        }

  
        public void Save(Author author)
        {
            _lstAuthor.Add(author);
        }

        public IEnumerable<GetAuthorQueryResult> GetAuthor(string name)
        {
            
            var lstQuery = new List<GetAuthorQueryResult>();

            var lstAux = _lstAuthor.Where(x => x.Name.Contains(name));

            foreach (var item in lstAux)
            {
                lstQuery.Add(new GetAuthorQueryResult()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Category = item.Category.ToString()
                });
            }
            return lstQuery;
        }

        public Author GetAuthorById(Guid id)
        {
            return _lstAuthor.SingleOrDefault(x => x.Id == id);
        }

        public void Delete(Author author)
        {
            _lstAuthor.Remove(author);
        }

        public IEnumerable<GetAuthorQueryResult> GetAuthorAvailableToMusic(Guid authorId)
        {
            throw new NotImplementedException();
        }
    }
}
