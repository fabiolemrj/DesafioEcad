using ecad.shared.Entities;
using FluentValidator;
using System;
using System.Collections.Generic;
using System.Text;

namespace ecad.domain.MusicContext.Entities
{
    public class MusicAuthor: Notifiable
    {
        public Guid MusicId { get; private set; }
        public Music Music { get; private set; }

        public Guid AuthorId { get; private set; }
        public Author Author { get; private set; }
               
        public MusicAuthor(Guid musicId, Guid authorId)
        {
            MusicId = musicId;
            AuthorId = authorId;
        }

        public MusicAuthor(Music music, Author author)
        {
            Music = music;
            Author = author;
            MusicId = music.Id;
            AuthorId = author.Id;
        }

        public MusicAuthor()
        {

        }
        
    }
}
