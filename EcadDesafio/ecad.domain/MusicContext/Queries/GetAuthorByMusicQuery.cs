using System;
using System.Collections.Generic;
using System.Text;

namespace ecad.domain.MusicContext.Queries
{
    public class GetAuthorByMusicQuery
    {
        public Guid MusicId { get; set; }
        public string NameMusic { get; set; }
        public Guid AuthorId { get; set; }
        public string NameAuthor { get; set; }
        public string CategoryAuthor { get; set; }
    }
}
