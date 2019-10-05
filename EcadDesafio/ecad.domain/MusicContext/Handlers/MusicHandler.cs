using ecad.domain.MusicContext.Commands;
using ecad.domain.MusicContext.Commands.CreateMusicCommands;
using ecad.domain.MusicContext.Entities;
using ecad.domain.MusicContext.Enums;
using ecad.domain.MusicContext.Queries;
using ecad.domain.MusicContext.Repositories;
using ecad.shared.Commands;
using FluentValidator;
using System;
using System.Collections.Generic;
using System.Text;

namespace ecad.domain.MusicContext.Handlers
{
    public class MusicHandler : Notifiable, ICommandHandler<CreateMusicCommand>
    {
        private readonly IMusicRepository _repository;
        private readonly IMusicAuthorRepository _repositoryMusicAuthor;

        public MusicHandler(IMusicRepository repository, IMusicAuthorRepository repositoryMusicAuthor)
        {
            _repository = repository;
            _repositoryMusicAuthor = repositoryMusicAuthor;
        }

        private bool HasAuthor(Guid musicid)
        {
            return _repositoryMusicAuthor.GetAuthorsByMusic(musicid) == null;
            
        }

        public ICommandResult GetMusic()
        {
            var createMusic = new CreateMusicCommandResult(false, "", null);
            var lstquery = new List<GetMusicAuthorQueryResult>();

            var query = _repository.GetMusic();

            foreach (var item in query)
            {
                lstquery.Add(new GetMusicAuthorQueryResult()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Genre = item.Genre
                });
            }
            createMusic.Success = true;
            createMusic.Message = "Sucesso";
            createMusic.Data = lstquery;
            return createMusic;
        }

        public ICommandResult GetMusicById(Guid id)
        {

            var createMusic = new CreateMusicCommandResult(false, "", null);
            
            if(id == null || id == Guid.Empty)
            {

                createMusic.Success = false;
                createMusic.Message = "parametro Id é nulo";
                createMusic.Data = new GetMusicByIdResultQuery();
                return createMusic;
            }

            var query = _repository.GetMusicById(id);
            var objeto = new GetMusicByIdResultQuery()
                                {   Id = query.Id,
                                    Name = query.Name,
                                    Genre = (int)query.Genre,
                                    Code = query.Code
                                };
            
            createMusic.Success = true;
            createMusic.Message = "Sucesso";
            createMusic.Data = objeto;
            return createMusic;
        }

        public ICommandResult DeleteById(Guid id)
        {
           

            var createMusic = new CreateMusicCommandResult(false, "", null);
            var queryResult = new GetMusicByIdResultQuery();
            if (id == null)
            {
                createMusic.Success = false;
                createMusic.Message = "Parametros não localizados";
                createMusic.Data = queryResult;
                return createMusic;
            }

            var musica = _repository.GetMusicById(id);

            if (musica == null)
            {
                createMusic.Success = false;
                createMusic.Message = "Musica não localizada para exclusao";
                createMusic.Data = queryResult;
                return createMusic;
            }

            if (HasAuthor(id))
            {
                createMusic.Success = false;
                createMusic.Message = "Não é possivel excluir a musica,pois existem associaçoes com autores";
                createMusic.Data = queryResult;
                return createMusic;
            }

            if (!IsValid)
            {
                createMusic.Success = false;
                createMusic.Message = "Não foi possivel apagar a musica";
                createMusic.Data = new CreateMusicCommand();
                return createMusic;
            }

            try
            {
                _repository.Delete(musica);
            }
            catch (Exception e)
            {
                createMusic.Success = false;
                createMusic.Message = e.Message;
                createMusic.Data = new CreateMusicCommand();
                return createMusic;
            }

            var objeto = new GetMusicByIdResultQuery()
            {
                Id = musica.Id,
                Name = musica.Name,
                Genre = (int)musica.Genre,
                Code = musica.Code
            };

            createMusic.Success = true;
            createMusic.Message = "Musica apagada";
            createMusic.Data = objeto;
            return createMusic;
        }


        public ICommandResult GetMusic(string name)
        {
            var createMusic = new CreateMusicCommandResult(false, "", null);
            var lstquery = new List<GetMusicAuthorQueryResult>();

            var query = _repository.GetMusicByName(name);

            if (query == null)
            {
                createMusic.Success = false;
                createMusic.Message = "Parametros não localizados";
                createMusic.Data = new GetMusicAuthorQueryResult();
                return createMusic;
            }

            foreach (var item in query)
            {
                lstquery.Add(new GetMusicAuthorQueryResult() {
                    Id = item.Id,
                    Name = item.Name,
                    Genre = item.Genre
                });
            }
            createMusic.Success = true;
            createMusic.Message = "Sucesso";
            createMusic.Data = lstquery; 
            return createMusic;
        }

        public ICommandResult Handler(CreateMusicCommand command)
        {
            var createMusic = new CreateMusicCommandResult(false,"",null);
            var queryResult = new GetMusicAuthorQueryResult();

            if (command == null)
            {
                createMusic.Success = false;
                createMusic.Message = "Parametros não localizados";
                createMusic.Data = queryResult;
                return createMusic;
            }

            ETypeGenreMusic genre;
            try
            {                
                genre = (ETypeGenreMusic)command.Genre;
                if(command.Genre < 1 && command.Genre > 5)
                {
                    createMusic.Success = false;
                    createMusic.Message = "Genero da musica invalido";
                    createMusic.Data = queryResult;
                    return createMusic;
                }
            }
            catch
            {
                createMusic.Success = false;
                createMusic.Message = "Genero da musica invalido";
                createMusic.Data = queryResult;
                return createMusic;
            }

            var music = _repository.GetMusicById(command.Id);
            
            if(music == null)
                music = new Music(command.Code,command.Name,genre);
            else
                music.Update(command.Code,command.Name,genre);
                        
            if(string.IsNullOrEmpty(command.Name) && (command.Name.Length <3 || command.Name.Length > 50))
            {
                createMusic.Success = false;
                createMusic.Message = "O nome da musica deve ter entre 3 e 50 caracteres";
                createMusic.Data = new CreateMusicCommand();
                return createMusic;
            }
                      

            if (!IsValid)
            {
                createMusic.Success = false;
                createMusic.Message = "Não foi possivel criar a musica";
                createMusic.Data = new CreateMusicCommand();
                return createMusic;
            }

            try
            {
                _repository.Save(music);
            }
            catch(Exception e)
            {
                createMusic.Success = false;
                createMusic.Message = e.Message;
                createMusic.Data = new CreateMusicCommand();
                return createMusic;
            }           

            queryResult.Name = music.Name;
            queryResult.Genre = music.Genre.ToString();
            queryResult.Id = music.Id;

            createMusic.Success = true;
            createMusic.Message = "Musica criada com sucesso";
            createMusic.Data = queryResult;

            return createMusic;
        }
    }
}
