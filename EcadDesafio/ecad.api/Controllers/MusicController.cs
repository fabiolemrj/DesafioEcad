using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecad.domain.MusicContext.Commands.CreateMusicCommands;
using ecad.domain.MusicContext.Handlers;
using ecad.domain.MusicContext.Queries;
using ecad.domain.MusicContext.Repositories;
using ecad.shared.Commands;
using Microsoft.AspNetCore.Mvc;

namespace ecad.api.Controllers
{
    public class MusicController:Controller
    {

        private readonly IMusicRepository _repository;
        private readonly MusicHandler _handler;

        public MusicController(IMusicRepository repository, MusicHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        /// <summary>
        /// retorna uma lista de objetos do tipo musica pela descrição do nome da musica
        /// </summary>
        /// <param name="id">campo do tipo GUID</param>
        /// <returns></returns>
        [HttpGet]
        [Route("v1/musicsbyname/{id}")]
        public ICommandResult GetMusic(string id)
        {
            return _handler.GetMusic(id);
        }

        /// <summary>
        /// retorna toda lista de musicas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("v1/musics")]
        public ICommandResult Get()
        {
            return _handler.GetMusic();
        }

        /// <summary>
        /// retorna u objeto musica pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("v1/musics/{id}")]
        public ICommandResult Get(Guid id)
        {
            return _handler.GetMusicById(id);
        }

        /// <summary>
        /// Grava (cria ou atualiza) um objeto do tipo musica
        /// </summary>
        /// <param name="command">objeto adaptado para buscar valores da visão</param>
        /// <returns></returns>
        [HttpPost]
        [Route("v1/musics")]
        public ICommandResult Post([FromBody]CreateMusicCommand command)
        {
            return _handler.Handler(command);
        }

        /// <summary>
        /// Grava (cria ou atualiza) um objeto do tipo musica
        /// </summary>
        /// <param name="command">objeto adaptado para buscar valores da visão</param>
        /// <returns></returns>
        [HttpPut]
        [Route("v1/musics")]
        public ICommandResult Put([FromBody]CreateMusicCommand command)
        {
            return _handler.Handler(command);
        }

        /// <summary>
        /// apagar um objeto objeto do banco
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("v1/musics/{id}")]
        public ICommandResult Delete(Guid id)
        {
            return _handler.DeleteById(id);
        }
    }
}
