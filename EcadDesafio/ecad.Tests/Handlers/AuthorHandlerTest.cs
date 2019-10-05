using ecad.domain.MusicContext.Commands.CreateAuthorCommands;
using ecad.Tests.FakeRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ecad.domain.MusicContext.Enums;
using ecad.domain.MusicContext.Handlers;

namespace ecad.Tests.Handlers
{
    [TestClass]
    public class AuthorHandlerTest
    {
        CreateAuthorCommand command;
        AutorFakeRepository _repository;

        MusicAuthorFakeRepository _repositoryMusicAuthor;
        MusicFakeRepository _repositoryMusic;

        public AuthorHandlerTest()
        {
            _repositoryMusicAuthor = new MusicAuthorFakeRepository();
            _repositoryMusic = new MusicFakeRepository();

            _repository = new AutorFakeRepository();

            command = new CreateAuthorCommand();
            command.Name = "Joao Musico";
            command.Category = (int)ECategoryAuthor.Author;
            command.Code = "543210";
        }

        [TestMethod]
        public void AuthorRegisterCommandIsValid()
        {
            var handler = new AuthorHandler(_repository,_repositoryMusicAuthor);
            var result = handler.Handler(command);
            Assert.AreEqual(true, handler.IsValid);
        }

        [TestMethod]
        public void GetListAuthor()
        {
            var lst = _repository.GetAuthor();
            Assert.AreEqual(true, lst.Count() > 0);
        }

        [TestMethod]
        public void GetListAuthorByName()
        {
            var lst = _repository.GetAuthor("Joao");
            Assert.AreEqual(true, lst.Count() > 0);
        }
    }
}
