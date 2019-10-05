using ecad.domain.MusicContext.Entities;
using ecad.domain.MusicContext.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace ecad.domain.MusicContext.Repositories
{
    public interface IMusicAuthorRepository
    {
        void Save(MusicAuthor musicAuthor);
        void Delete(MusicAuthor musicAuthor);

        IEnumerable<GetAuthorByMusicQuery> GetAuthorsByMusic(Guid MusicId);
        IEnumerable<GetAuthorByMusicQuery> GetAuthorsByAuthor(Guid authorId);
        MusicAuthor GetById(Guid musicId, Guid authorId);
        IEnumerable<GetAuthorQueryResult> GetAuthorAvailableToMusic(Guid musicId);


    }
}
