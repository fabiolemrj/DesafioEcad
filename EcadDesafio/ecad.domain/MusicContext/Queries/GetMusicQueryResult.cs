using System;
using System.Collections.Generic;
using System.Text;

namespace ecad.domain.MusicContext.Queries
{
    public class GetMusicAuthorQueryResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Code { get; set; }
    }
}
