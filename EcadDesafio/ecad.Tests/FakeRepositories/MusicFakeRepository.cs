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

    public class MusicFakeRepository : IMusicRepository
    {
        List<Music> _lstMusic;

        public MusicFakeRepository()
        {
            _lstMusic = new List<Music>();
            GetListMusic(_lstMusic);
        }

        private void GetListMusic(List<Music> lst)
        {
            lst.Add(new Music("012345", "Musica 1", ETypeGenreMusic.MPB));
            lst.Add(new Music("123451", "Musica 2", ETypeGenreMusic.Gospel));
            lst.Add(new Music("734781", "Musica 3", ETypeGenreMusic.MPB));
            lst.Add(new Music("873475", "Musica 5", ETypeGenreMusic.Pop));
            lst.Add(new Music("012345", "Musica 4", ETypeGenreMusic.Samba));

        }

        public void GetListMusicExtern(List<Music> lst)
        {
            lst.AddRange(_lstMusic);
        }

        public Music GetFirsMusic()
        {
            return _lstMusic.FirstOrDefault();
        }

        public IEnumerable<GetMusicAuthorQueryResult> GetMusic()
        {
            var lstQuery = new List<GetMusicAuthorQueryResult>();

            foreach (var item in _lstMusic)
            {
                lstQuery.Add(new GetMusicAuthorQueryResult()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Genre = item.Genre.ToString()
                });
            }

            return lstQuery;
        }

        public GetMusicAuthorQueryResult GetMusic(Guid id)
        {

            var music = _lstMusic.SingleOrDefault(x => x.Id == id);
            var query = new GetMusicAuthorQueryResult()
            {
                Id = music.Id,
                Name = music.Name,
                Genre = music.Genre.ToString()
            };
            return query;
        }

        public void Save(Music music)
        {
            _lstMusic.Add(music);
        }



        public Music GetMusicById(Guid id)
        {
            return _lstMusic.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<GetMusicAuthorQueryResult> GetMusicByName(string name)
        {
            var lstQuery = new List<GetMusicAuthorQueryResult>();

            var lstAux = _lstMusic.Where(x => x.Name.Contains(name));

            foreach (var item in lstAux)
            {
                lstQuery.Add(new GetMusicAuthorQueryResult()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Genre = item.Genre.ToString()
                });
            }
            return lstQuery;
        }

        public void Delete(Music music)
        {
            throw new NotImplementedException();
        }
    }
    }
