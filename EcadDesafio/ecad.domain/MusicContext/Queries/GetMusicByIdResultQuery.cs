using System;
using System.Collections.Generic;
using System.Text;

namespace ecad.domain.MusicContext.Queries
{
    public class GetMusicByIdResultQuery
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Genre { get; set; }
        public string Code { get; set; }
    }
}
