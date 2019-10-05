using System;
using System.Collections.Generic;
using System.Text;

namespace ecad.domain.MusicContext.Queries
{
    public class GetAuthorByIdModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Category { get; set; }
        public string Code { get; set; }
    }
}
