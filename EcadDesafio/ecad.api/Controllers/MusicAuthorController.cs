using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecad.domain.MusicContext.Commands.CreateMusicAuthorCommands;
using ecad.domain.MusicContext.Commands.CreateMusicCommands;
using ecad.domain.MusicContext.Handlers;
using ecad.domain.MusicContext.Queries;
using ecad.domain.MusicContext.Repositories;
using ecad.shared.Commands;
using Microsoft.AspNetCore.Mvc;

namespace ecad.api.Controllers
{
    public class MusicAuthorController : Controller
    {
        private readonly IMusicAuthorRepository _repository;
        private readonly MusicAuthorHandler _handler;
        private readonly IMusicRepository _repositoryMusic;
        private readonly IAuthorRepository _repositoryAuthor;

        public MusicAuthorController(IMusicAuthorRepository repository, MusicAuthorHandler handler, 
                IMusicRepository musicRepository, IAuthorRepository authorRepository)
        {
            _repository = repository;
            _handler = handler;
            _repositoryMusic = musicRepository;
            _repositoryAuthor = authorRepository;
        }

        /// <summary>
        /// Busca todos os autores associados a uma musica
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("v1/musics/{id}/authors")]
        public ICommandResult GetAuthorByMusic(Guid id)
        {
            return _handler.GelAuthorsMusicById(id);
        }

        /// <summary>
        /// busca lista de associacoes pelos IDs de musica autor
        /// </summary>
        /// <param name="musicId"></param>
        /// <param name="authorId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("v1/musicsauthorsbyid/{musicid}/{authorid}")]
        public ICommandResult GetMusicAuthorById(Guid musicId, Guid authorId)
        {
            return _handler.GelAuthorsByMusicId(musicId,authorId);
        }

        /// <summary>
        /// Grava um nova associação entre musica e autor
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("v1/musicsauthors")]
        public ICommandResult Post([FromBody]CreateMusicAuthorCommand command)
        {
            return _handler.Handler(command);
        }

        /// <summary>
        /// lista de autores disponiveis para a musica selecionada, ou seja, que ainda não foram associados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("v1/musicauthorsavailable/{id}")]
        public ICommandResult GetAuthorAvailableToMusic(Guid id)
        {
            return _handler.GetAuthorAvailableToMusic(id);
        }
                
        /// <summary>
        /// apaga um registro no banco filtrados pelos IDs de musica e autor
        /// </summary>
        /// <param name="musicId"></param>
        /// <param name="authorId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("v1/deletemusicsauthors/{musicid}/{authorid}")]
        public ICommandResult Delete(Guid musicId, Guid authorId)
        {
            return _handler.DeleteById(musicId,authorId);
        }
    }
}