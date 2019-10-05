using System;
using System.Collections.Generic;
using System.Text;

namespace ecad.domain.MusicContext.Queries
{
    public class GetAuthorQueryResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Code { get; set; }

    }
}
