using ecad.domain.MusicContext.Entities;
using ecad.domain.MusicContext.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace ecad.domain.MusicContext.Repositories
{
    public interface IAuthorRepository
    {
        void Save(Author author);
        void Delete(Author author);
        IEnumerable<GetAuthorQueryResult> GetAuthor();
        GetAuthorQueryResult GetAuthor(Guid id);
        IEnumerable<GetAuthorQueryResult> GetAuthor(string name);

        IEnumerable<GetAuthorQueryResult> GetAuthorAvailableToMusic(Guid authorId);
        Author GetAuthorById(Guid id);
    }
}
