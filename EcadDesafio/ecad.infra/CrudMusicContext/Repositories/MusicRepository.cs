using ecad.domain.MusicContext.Entities;
using ecad.domain.MusicContext.Queries;
using ecad.domain.MusicContext.Repositories;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ecad.infra.CrudMusicContext.Repositories
{
    public class MusicRepository : IMusicRepository
    {

        private readonly EcadDataContext _context;

        public MusicRepository(EcadDataContext context)
        {
            _context = context;
        }

        public void Delete(Music music)
        {
            _context.Musics.Remove(music);
            _context.SaveChanges();
        }

        public IEnumerable<GetMusicAuthorQueryResult> GetMusic(string name)
        {
            var result = _context.Musics.Where(x=>x.Name.Contains(name));
            var lst = new List<GetMusicAuthorQueryResult>();
            foreach (var item in result)
            {
                lst.Add(new GetMusicAuthorQueryResult()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Genre = item.Genre.ToString()
                });
            }
            return lst;
        }


        public IEnumerable<GetMusicAuthorQueryResult> GetMusic()
        {
            var result = _context.Musics;
            var lst = new List<GetMusicAuthorQueryResult>();
            foreach(var item in result)
            {
                lst.Add(new GetMusicAuthorQueryResult()
                {
                    Id =item.Id,
                    Name = item.Name,
                    Genre = item.Genre.ToString()
                });
            }
            return lst;
        }

        public GetMusicAuthorQueryResult GetMusic(Guid id)
        {
            var music = _context.Musics.Single(x => x.Id == id);
            var query = new GetMusicAuthorQueryResult();
            if(music != null)
            {
                query.Id = music.Id;
                query.Name = music.Name;
                query.Genre = music.Genre.ToString();
                query.Code = music.Code;
            }
            return query;
        }

        public Music GetMusicById(Guid id)
        {
            return  _context.Musics.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<GetMusicAuthorQueryResult> GetMusicByName(string name)
        {
            var result = _context.Musics.Where(x=>x.Name.Contains(name));
            var lst = new List<GetMusicAuthorQueryResult>();
            foreach (var item in result)
            {
                lst.Add(new GetMusicAuthorQueryResult()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Genre = item.Genre.ToString()
                });
            }
            return lst;
        }

        public void Save(Music music)
        {
            if(_context.Musics.Find(music.Id) == null)
            {
                _context.Add(music);
            }
            _context.SaveChanges();
        }
    }
}
