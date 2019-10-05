using ecad.domain.MusicContext.Entities;
using ecad.domain.MusicContext.Queries;
using ecad.domain.MusicContext.Repositories;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ecad.infra.CrudMusicContext.Repositories
{
    public class MusicAuthorRepository : IMusicAuthorRepository
    {
        private readonly EcadDataContext _context;

        public MusicAuthorRepository(EcadDataContext context)
        {
            _context = context;
        }

        public void Delete(MusicAuthor musicAuthor)
        {
            _context.MusicsAuthors.Remove(musicAuthor);
            _context.SaveChanges();
        }

        public IEnumerable<GetAuthorQueryResult> GetAuthorAvailableToMusic(Guid musicId)
        {

            var lstauthor = _context.Authors.ToList();
            var lstmusicauthor = _context.MusicsAuthors.Where(x => x.MusicId == musicId);

            var lst = new List<GetAuthorQueryResult>();
            foreach(var item in lstauthor)
            {
                if (lstmusicauthor.SingleOrDefault(x => x.AuthorId == item.Id) == null)
                {
                    lst.Add(new GetAuthorQueryResult() {
                        Id = item.Id,
                        Name = item.Name,
                        Category = item.Category.ToString(),
                        Code = item.Code                    
                    });
                }
            }

            return lst;

        }

        public IEnumerable<GetAuthorByMusicQuery> GetAuthorsByAuthor(Guid authorId)
        {
            var result = from musicAuthor in _context.MusicsAuthors.Where(x => x.MusicId == authorId)
                         join music in _context.Musics on musicAuthor.MusicId equals music.Id
                         join author in _context.Authors on musicAuthor.AuthorId equals author.Id
                         select new { music.Id, music.Name, musicAuthor.AuthorId, nameauthor = author.Name, author.Category };

            var lst = new List<GetAuthorByMusicQuery>();

            foreach (var item in result)
            {
                lst.Add(new GetAuthorByMusicQuery()
                {
                    MusicId = item.Id,
                    NameMusic = item.Name,
                    AuthorId = item.AuthorId,
                    NameAuthor = item.nameauthor,
                    CategoryAuthor = item.Category.ToString()
                });
            }
            return lst;


        }

        public IEnumerable<GetAuthorByMusicQuery> GetAuthorsByMusic(Guid musicId)
        {

            var result = from musicAuthor in _context.MusicsAuthors.Where(x=>x.MusicId == musicId)
                         join music in _context.Musics on musicAuthor.MusicId equals music.Id
                         join author in _context.Authors on musicAuthor.AuthorId equals author.Id
                         select new { music.Id, music.Name,musicAuthor.AuthorId, nameauthor=author.Name, author.Category};

            var lst = new List<GetAuthorByMusicQuery>();

            foreach (var item in result)
            {
                lst.Add(new GetAuthorByMusicQuery()
                {
                    MusicId = item.Id,
                    NameMusic = item.Name,
                    AuthorId = item.AuthorId,
                    NameAuthor = item.nameauthor,
                    CategoryAuthor = item.Category.ToString()
                });
            }
            return lst;
        }

        public MusicAuthor GetById(Guid musicId, Guid authorId)
        {
            return _context.MusicsAuthors.Find(musicId, authorId);
        }

        public void Save(MusicAuthor musicAuthor)
        {
            if (!_context.MusicsAuthors.Any(x=>x.AuthorId== musicAuthor.AuthorId && x.MusicId == musicAuthor.MusicId))
            {
                _context.Add(musicAuthor);
            }
            _context.SaveChanges();
        }
    }
}
