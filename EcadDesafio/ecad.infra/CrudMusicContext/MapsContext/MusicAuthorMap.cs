using ecad.domain.MusicContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ecad.infra.CrudMusicContext.MapsContext
{
    public class MusicAuthorMap : IEntityTypeConfiguration<MusicAuthor>
    {
        public void Configure(EntityTypeBuilder<MusicAuthor> builder)
        {
            builder.ToTable("MusicAuthor");
            builder.HasKey(x => new { x.MusicId, x.AuthorId });
            
        }
    }
}
