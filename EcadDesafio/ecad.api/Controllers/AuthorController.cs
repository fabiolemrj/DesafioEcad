using ecad.domain.MusicContext.Commands.CreateAuthorCommands;
using ecad.domain.MusicContext.Commands.CreateMusicCommands;
using ecad.domain.MusicContext.Handlers;
using ecad.domain.MusicContext.Queries;
using ecad.domain.MusicContext.Repositories;
using ecad.shared.Commands;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecad.api.Controllers
{
    public class AuthorController:Controller
    {

        private readonly IAuthorRepository _repository;
        private readonly AuthorHandler _handler;

        public AuthorController(IAuthorRepository repository, AuthorHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        /// <summary>
        /// retorna uma lista de objetos autores filtrados pelo nome
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("v1/authorsbyname/{id}")]
        public ICommandResult GetAuthor(string id)
        {
            return _handler.GetAuthorByName(id);
        }

        /// <summary>
        /// lista de autores disponiveis para a musica selecionada, ou seja, que ainda não foram associados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("v1/authorsavailable/{id}")]
        public ICommandResult GetAuthorAvailableToMusic(Guid id)
        {
            return _handler.GetAuthorAvailableToMusic(id);
        }

        /// <summary>
        /// lista todos os autores
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("v1/authors")]
        public ICommandResult Get()
        {
            return _handler.GetAuthor();            
        }

        /// <summary>
        /// Grava um novo objeto do tipo autor
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("v1/authors")]
        public ICommandResult Post([FromBody]CreateAuthorCommand command)
        {
            return _handler.Handler(command);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Busca lista de autores pelo ID</param>
        /// <returns></returns>
        [HttpGet]
        [Route("v1/authors/{id}")]
        public ICommandResult Get(Guid id)
        {
            return _handler.GetAuthorById(id);
        }

        /// <summary>
        /// Atualiza novo registro no banco
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("v1/authors")]
        public ICommandResult Put([FromBody]CreateAuthorCommand command)
        {
            return _handler.Handler(command);
        }

        /// <summary>
        /// apagar registro no banco pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("v1/authors/{id}")]
        public ICommandResult Delete(Guid id)
        {
            return _handler.DeleteById(id);
        }
    }
}
