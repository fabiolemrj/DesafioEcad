using ecad.domain.MusicContext.Entities;
using ecad.domain.MusicContext.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ecad.Tests.Entities
{
    [TestClass]
    public class MusicTests
    {
        Music _music; 
        public MusicTests()
        {
            _music = new Music("123456", "Musica Teste 1", ETypeGenreMusic.Samba);
        }

        [TestMethod]
        public void MusicIsValid()
        {
            Assert.AreEqual(true, _music.IsValid);
            Assert.AreEqual(0, _music.Notifications.Count);
        }


    }
}
