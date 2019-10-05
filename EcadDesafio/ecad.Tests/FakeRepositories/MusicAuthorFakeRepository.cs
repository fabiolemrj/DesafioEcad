using ecad.domain.MusicContext.Entities;
using ecad.domain.MusicContext.Enums;
using ecad.domain.MusicContext.Queries;
using ecad.domain.MusicContext.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ecad.Tests.FakeRepositories
{
    [TestClass]
    public class MusicAuthorFakeRepository : IMusicAuthorRepository
    {

        List<MusicAuthor> _lstMusicAuthor;
        List<Music> _lstMusic;
        List<Author> _lstAuthor;
        public MusicAuthorFakeRepository()
        {
            _lstMusicAuthor = new List<MusicAuthor>();
            _lstMusic = new List<Music>();
            _lstAuthor = new List<Author>();

            var repositoryMusic = new MusicFakeRepository();
            repositoryMusic.GetListMusicExtern(_lstMusic);
            var repositoryAuthor = new AutorFakeRepository();
            repositoryAuthor.GetListAuthorExtern(_lstAuthor);
          
        }

        public Music GetFirsMusic()
        {
            return _lstMusic.FirstOrDefault();
        }

        public Author GetFirstAuthor()
        {
            return _lstAuthor.FirstOrDefault();
        }

        public IEnumerable<GetAuthorByMusicQuery> GetAuthorsByMusic(Guid MusicId)
        {
            var lst = new List<MusicAuthor>();

            lst.Add(new MusicAuthor(_lstMusic[0], _lstAuthor[0]));
            lst.Add(new MusicAuthor(_lstMusic[0], _lstAuthor[1]));
            lst.Add(new MusicAuthor(_lstMusic[0], _lstAuthor[2]));
            lst.Add(new MusicAuthor(_lstMusic[1], _lstAuthor[1]));
            lst.Add(new MusicAuthor(_lstMusic[2], _lstAuthor[0]));
            lst.Add(new MusicAuthor(_lstMusic[3], _lstAuthor[4]));


            var lstAux = new List<GetAuthorByMusicQuery>() { };
            foreach (var item in lst.Where(x => x.Music.Id == MusicId))
            {
                lstAux.Add(new GetAuthorByMusicQuery()
                {
                    AuthorId = item.AuthorId,
                    MusicId = item.MusicId,
                    CategoryAuthor = item.Author.Category.ToString(),
                    NameAuthor = item.Author.Name,
                    NameMusic = item.Music.Name
                });
            }

            return lstAux;
        }

        public IEnumerable<GetAuthorByMusicQuery> GetAuthorsByMusic(Guid MusicId, List<Music> lstMusics, List<Author> lstAuthors)
        {
            var lst = new List<MusicAuthor>();

            lst.Add(new MusicAuthor(lstMusics[0], lstAuthors[0]));
            lst.Add(new MusicAuthor(lstMusics[0], lstAuthors[1]));
            lst.Add(new MusicAuthor(lstMusics[0], lstAuthors[2]));
            lst.Add(new MusicAuthor(lstMusics[1], lstAuthors[1]));
            lst.Add(new MusicAuthor(lstMusics[2], lstAuthors[0]));
            lst.Add(new MusicAuthor(lstMusics[3], lstAuthors[4]));


            var lstAux = new List<GetAuthorByMusicQuery>(){};
            foreach (var item in lst.Where(x => x.Music.Id == MusicId))
            {
                lstAux.Add(new GetAuthorByMusicQuery()
                {
                    AuthorId = item.AuthorId,
                    MusicId = item.MusicId,
                    CategoryAuthor = item.Author.Category.ToString(),
                    NameAuthor = item.Author.Name,
                    NameMusic = item.Music.Name
                });
            }

            return lstAux;
        }

        public void Save(MusicAuthor musicAuthor)
        {
            _lstMusicAuthor.Add(musicAuthor);
        }

        public void Delete(MusicAuthor musicAuthor)
        {
            _lstMusicAuthor.Remove(musicAuthor);
        }

        public MusicAuthor GetById(Guid musicId, Guid authorId)
        {
            return _lstMusicAuthor.SingleOrDefault(x => x.AuthorId == authorId && x.MusicId == musicId);
        }

        public IEnumerable<GetAuthorQueryResult> GetAuthorAvailableToMusic(Guid musicId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GetAuthorByMusicQuery> GetAuthorsByAuthor(Guid authorId)
        {
            throw new NotImplementedException();
        }
    }
}
