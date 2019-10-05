using ecad.domain.MusicContext.Entities;
using ecad.domain.MusicContext.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ecad.Tests.Entities
{
    [TestClass]
    public class AuthorTests
    {
        Author _author;
        public AuthorTests()
        {
            _author = new Author("012345","Joao", ECategoryAuthor.Author);
        }

        [TestMethod]
        public void AuthorIsValid()
        {
            Assert.AreEqual(true, _author.IsValid);
            Assert.AreEqual(0, _author.Notifications.Count);
        }
    }
}
