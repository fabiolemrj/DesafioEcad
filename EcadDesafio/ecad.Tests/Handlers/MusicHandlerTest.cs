using ecad.domain.MusicContext.Commands.CreateMusicCommands;
using ecad.domain.MusicContext.Enums;
using ecad.domain.MusicContext.Handlers;
using ecad.Tests.FakeRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ecad.Tests.Handlers
{
    [TestClass]
    public class MusicHandlerTest
    {
        CreateMusicCommand command;
        MusicFakeRepository _repository;
        MusicAuthorFakeRepository _repositoryMusicAuthor;

        public MusicHandlerTest()
        {
            _repository = new MusicFakeRepository();
            _repositoryMusicAuthor = new MusicAuthorFakeRepository();

            command = new CreateMusicCommand();
            command.Name = "Musica Teste Command";
            command.Genre = (int)ETypeGenreMusic.Samba;
            command.Code = "123456";
        }

        [TestMethod]
        public void MusicRegisterCommandIsValid()
        {
            var handler = new MusicHandler(_repository,_repositoryMusicAuthor);
            var result = handler.Handler(command);
            Assert.AreEqual(true, handler.IsValid);           
        }

        [TestMethod]
        public void GetListMusic()
        {
            var lst = _repository.GetMusic();
            Assert.AreEqual(true, lst.Count() > 0);
        }

        [TestMethod]
        public void GetListMusicByName()
        {
            var lst = _repository.GetMusicByName("Musica");
            Assert.AreEqual(true, lst.Count() > 0);
        }

        
    }
}
