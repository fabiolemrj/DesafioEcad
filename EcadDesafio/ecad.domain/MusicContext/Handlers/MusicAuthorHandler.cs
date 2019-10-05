using ecad.domain.MusicContext.Commands.CreateAuthorCommands;
using ecad.domain.MusicContext.Commands.CreateMusicAuthorCommands;
using ecad.domain.MusicContext.Commands.CreateMusicCommands;
using ecad.domain.MusicContext.Entities;
using ecad.domain.MusicContext.Queries;
using ecad.domain.MusicContext.Repositories;
using ecad.shared.Commands;
using FluentValidator;
using System;
using System.Collections.Generic;
using System.Text;

namespace ecad.domain.MusicContext.Handlers
{
    public class MusicAuthorHandler : Notifiable, ICommandHandler<CreateMusicAuthorCommand>
    {

        private readonly IMusicAuthorRepository _repository;
        private readonly IMusicRepository _repositoryMusic;
        private readonly IAuthorRepository _repositoryAuthor;

        public MusicAuthorHandler(IMusicAuthorRepository repository, IMusicRepository repositoryMusic, IAuthorRepository repositoryAuthor)
        {
            _repository = repository;
            _repositoryMusic = repositoryMusic;
            _repositoryAuthor = repositoryAuthor;
        }

        public ICommandResult GelAuthorsByMusicId(Guid musicId, Guid authorId)
        {
            var result = new CreateMusicAuthorCommandResult(false, "", null);
            var queryResult = new GetAuthorByMusicQuery();

            if (musicId == null)
            {

                result.Success = false;
                result.Message = "MusicId não informado";
                result.Data = queryResult;
                AddNotification(new Notification("Command", "MusicId não informado"));
            }

            if (authorId == null)
            {
                result.Success = false;
                result.Message = "AuthorId não localizados";
                result.Data = queryResult;
                AddNotification(new Notification("Command", "AuthorId não localizados"));
            }

            var musicauthor = _repository.GetById(musicId, authorId);
            var author = GetAuthorById(authorId);
            var music = GetMusicById(musicId);

            if (musicauthor == null)
            {
                result.Success = false;
                result.Message = "associacao entre musica e autor não localizada não localizada";
                result.Data = queryResult;
                AddNotification(new Notification("Command", "associacao entre musica e autor não localizada não localizada"));
            }
           

            if (!IsValid)
            {
                result.Success = false;
                result.Message = Notifications.ToString();
                result.Data = new CreateMusicCommand();
                return result;
            }


            queryResult.AuthorId = musicauthor.AuthorId;
            queryResult.MusicId = musicauthor.MusicId;
            queryResult.NameMusic = music.Name;
            queryResult.NameAuthor = author.Name;
            queryResult.CategoryAuthor = author.Category.ToString();
            


            result.Success = true;
            result.Message = "Sucesso";
            result.Data = queryResult;

            return result;
        }

        public ICommandResult GelAuthorsByMusicId(CreateMusicAuthorCommand command)
        {
            var result = new CreateMusicAuthorCommandResult(false, "", null);
            var queryResult = new GetAuthorByMusicQuery();
            
            if (command == null)
            {
                result.Success = false;
                result.Message = "Parametros não localizados";
                result.Data = queryResult;
                return result;
            }
            
            if (command.MusicId == null)
            {

                result.Success = false;
                result.Message = "MusicId não informado";
                result.Data = queryResult;
                AddNotification(new Notification("Command", "MusicId não informado"));
            }

            if (command.AuthorId == null)
            {
                result.Success = false;
                result.Message = "AuthorId não localizados";
                result.Data = queryResult;
                AddNotification(new Notification("Command", "AuthorId não localizados"));
            }

            var musicauthor = _repository.GetById(command.MusicId, command.AuthorId);
            var author = GetAuthorById(command.AuthorId);
            var music = GetMusicById(command.MusicId);

            if (musicauthor == null)
            {
                result.Success = false;
                result.Message = "associacao entre musica e autor não localizada não localizada";
                result.Data = queryResult;
                AddNotification(new Notification("Command", "associacao entre musica e autor não localizada não localizada"));
            }

            if (!IsValid)
            {
                result.Success = false;
                result.Message = Notifications.ToString();
                result.Data = new CreateMusicCommand();
                return result;
            }

            queryResult.NameAuthor = author.Name;
            queryResult.NameMusic = music.Name;
            queryResult.CategoryAuthor = author.Category.ToString();
            queryResult.MusicId = musicauthor.AuthorId;
            queryResult.AuthorId = musicauthor.MusicId;

            result.Success = true;
            result.Message = "Sucesso";
            result.Data = queryResult;

            return result;
        }


        public ICommandResult GetAuthorAvailableToMusic(Guid authorId)
        {
            var result = new CreateMusicAuthorCommandResult(false, "", null);
            var lstquery = new List<GetAuthorByIdResultQuery>();

            var query = _repository.GetAuthorAvailableToMusic(authorId);

            foreach (var item in query)
            {
                lstquery.Add(new GetAuthorByIdResultQuery()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Code = item.Code.ToString()
                });
            }
            result.Success = true;
            result.Message = "Sucesso";
            result.Data = lstquery;
            return result;
        }

        public ICommandResult DeleteById(Guid musicId, Guid authorId)
        {
            var result = new CreateMusicAuthorCommandResult(false, "", null);
            var queryResult = new GetAuthorByMusicQuery();
                        
            if (musicId == null)
            {

                result.Success = false;
                result.Message = "MusicId não informado";
                result.Data = queryResult;
                AddNotification(new Notification("Command", "MusicId não informado"));
            }

            if (authorId == null)
            {
                result.Success = false;
                result.Message = "AuthorId não localizados";
                result.Data = queryResult;
                AddNotification(new Notification("Command", "AuthorId não localizados"));
            }

            var musicauthor = _repository.GetById(musicId,authorId);
            var author = GetAuthorById(authorId);
            var music = GetMusicById(musicId);

            if (musicauthor == null)
            {
                result.Success = false;
                result.Message = "associção não localizada";
                result.Data = queryResult;
                AddNotification(new Notification("Command", "associacao não localizada"));
            }

            if (!IsValid)
            {
                result.Success = false;
                result.Data = new CreateMusicCommand();
                return result;
            }

            try
            {
                _repository.Delete(musicauthor);
            }
            catch (Exception e)
            {
                result.Success = false;
                result.Message = e.Message;
                result.Data = new CreateMusicCommand();
                return result;
            }

            queryResult.NameAuthor = author.Name;
            queryResult.NameMusic = music.Name;
            queryResult.CategoryAuthor = author.Category.ToString();
            queryResult.MusicId = musicauthor.AuthorId;
            queryResult.AuthorId = musicauthor.MusicId;
            
            result.Success = true;
            result.Message = "Associação de autor com musica realizada com sucesso com sucesso";
            result.Data = queryResult;

            return result;
        }

        private Music GetMusicById(Guid id)
        {
            return _repositoryMusic.GetMusicById(id);
        }

        private Author GetAuthorById(Guid id)
        {
            return _repositoryAuthor.GetAuthorById(id);
        }

        public ICommandResult GelAuthorsMusicById(Guid id)
        {
            var result = new CreateMusicAuthorCommandResult(false, "", null);
            var lstquery = new List<GetAuthorByMusicQuery>();

            var query = _repository.GetAuthorsByMusic(id);

            foreach (var item in query)
            {
                lstquery.Add(new GetAuthorByMusicQuery()
                {
                    AuthorId = item.AuthorId,
                    CategoryAuthor = item.CategoryAuthor,
                    MusicId = item.MusicId,
                    NameAuthor = item.NameAuthor,
                    NameMusic = item.NameMusic
                });

            }
             if(lstquery.Count == 0)
            {
                lstquery.Add(new GetAuthorByMusicQuery()
                {
                    MusicId = id
                    });
            }

            result.Success = true;
            result.Message = "Sucesso";
            result.Data = lstquery;
            return result;
        }

        public ICommandResult Handler(CreateMusicAuthorCommand command)
        {
            var result = new CreateMusicAuthorCommandResult(false, "", null);
            var queryResult = new GetAuthorByMusicQuery();

            if (command == null)
            {
                result.Success = false;
                result.Message = "Parametros não localizados";
                result.Data = queryResult;
                return result;
            }

            
            if(command.MusicId == null)
            {

                result.Success = false;
                result.Message = "MusicId não informado";
                result.Data = queryResult;
                AddNotification(new Notification("Command", "MusicId não informado"));
            }

            if (command.AuthorId == null)
            {
                result.Success = false;
                result.Message = "AuthorId não localizados";
                result.Data = queryResult;
                AddNotification(new Notification("Command", "AuthorId não localizados"));
            }

            var music = _repositoryMusic.GetMusicById(command.MusicId);
            if(music == null)
            {
                result.Success = false;
                result.Message = "Musica não localizada";
                result.Data = queryResult;
                AddNotification(new Notification("Command", "Musica não localizada"));
            }

            var author = _repositoryAuthor.GetAuthorById(command.AuthorId);
            if (author == null)
            {
                result.Success = false;
                result.Message = "Autor não localizado";
                result.Data = queryResult;
                AddNotification(new Notification("Command", "Musica não localizado"));
            }

            if(_repository.GetById(music.Id,author.Id) != null)
            {
                result.Success = false;
                result.Message = "Esta associação já existe!";
                result.Data = queryResult;
                AddNotification(new Notification("Command", "Esta associação já existe!"));
            }

            var musicAuthor = new MusicAuthor(music,author);

            if (!IsValid)
            {
                result.Success = false;            
                result.Data = new CreateMusicCommand();
                return result;
            }

            try
            {
                _repository.Save(musicAuthor);
            }
            catch (Exception e)
            {
                result.Success = false;
                result.Message = e.Message;
                result.Data = new CreateMusicCommand();
                return result;
            }

            queryResult.NameAuthor = music.Name;
            queryResult.AuthorId = author.Id;
            queryResult.MusicId = music.Id;
            queryResult.NameMusic = music.Name;
            queryResult.CategoryAuthor = author.Category.ToString();

            result.Success = true;
            result.Message = "Associação de autor com musica realizada com sucesso com sucesso";
            result.Data = queryResult;

            return result;
        }
    }
}
