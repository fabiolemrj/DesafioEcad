using ecad.domain.MusicContext.Commands.CreateMusicAuthorCommands;
using ecad.domain.MusicContext.Entities;
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
    public class MusicAuthorHandlerTest
    {
       
        MusicAuthorFakeRepository _repository;
        MusicFakeRepository _repositoryMusic;
        AutorFakeRepository _repositoryAuthor;


        public MusicAuthorHandlerTest()
        {
            _repository = new MusicAuthorFakeRepository();
            _repositoryAuthor = new AutorFakeRepository();
            _repositoryMusic = new MusicFakeRepository();
        }
         

        [TestMethod]
        public void MusicAuthorRegisterCommandIsValid()
        {
            var music = _repositoryMusic.GetFirsMusic();
            var author = _repositoryAuthor.GetFirsMusic();
            CreateMusicAuthorCommand _command;
            _command = new CreateMusicAuthorCommand();
            _command.MusicId = music.Id;
            _command.AuthorId = author.Id;

            var handler = new MusicAuthorHandler(_repository,_repositoryMusic,_repositoryAuthor);
            var result = handler.Handler(_command);
            Assert.AreEqual(true, handler.IsValid);
        }



    }
}
