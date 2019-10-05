using ecad.domain.MusicContext.Entities;
using ecad.domain.MusicContext.Enums;
using ecad.infra.CrudMusicContext.MapsContext;
using ecad.shared;
using FluentValidator;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ecad.infra.CrudMusicContext
{
    public class EcadDataContext: DbContext
    {
        public DbSet<Music> Musics { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<MusicAuthor> MusicsAuthors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var str = "Server=localhost;Database=ecad;Integrated Security=True;";
            var str = Settings.ConnectionString;
            optionsBuilder.UseSqlServer(str);
            //base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MusicMap());
            modelBuilder.ApplyConfiguration(new AuthorMap());
            modelBuilder.ApplyConfiguration(new MusicAuthorMap());
            modelBuilder.Ignore<Notification>();
        }
    }
}
