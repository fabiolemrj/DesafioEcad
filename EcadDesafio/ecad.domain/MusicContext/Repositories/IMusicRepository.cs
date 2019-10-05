using ecad.domain.MusicContext.Entities;
using ecad.domain.MusicContext.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace ecad.domain.MusicContext.Repositories
{
    public interface IMusicRepository
    {
        void Save(Music music);
        void Delete(Music music);
        IEnumerable<GetMusicAuthorQueryResult> GetMusic();
   
        GetMusicAuthorQueryResult GetMusic(Guid id);
        IEnumerable<GetMusicAuthorQueryResult> GetMusicByName(string name);
        Music GetMusicById(Guid id);
    }
}
