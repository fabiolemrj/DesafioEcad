using ecad.domain.MusicContext.Commands.CreateAuthorCommands;
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
    public class AuthorHandler : Notifiable, ICommandHandler<CreateAuthorCommand>
    {
        private readonly IAuthorRepository _repository;
        private readonly IMusicAuthorRepository _repositoryMusicAuthor;

        public AuthorHandler(IAuthorRepository repository, IMusicAuthorRepository repositoryMusicAuthor)
        {
            _repository = repository;
            _repositoryMusicAuthor = repositoryMusicAuthor;
        }

        private bool HasAuthor(Guid authorid)
        {
            return _repositoryMusicAuthor.GetAuthorsByAuthor(authorid) == null;

        }

        public ICommandResult GetAuthorAvailableToMusic(Guid authorId)
        {
            var result = new CreateAuthorCommandResult(false, "", null);
            var lstquery = new List<GetAuthorQueryResult>();

            var query = _repository.GetAuthorAvailableToMusic(authorId);

            foreach (var item in query)
            {
                lstquery.Add(new GetAuthorQueryResult()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Category = item.Category
                });
            }
            result.Success = true;
            result.Message = "Sucesso";
            result.Data = lstquery;
            return result;
        }

        public ICommandResult GetAuthorByName(string name)
        {
            var result = new CreateAuthorCommandResult(false, "", null);
            var lstquery = new List<GetAuthorQueryResult>();

            var query = _repository.GetAuthor(name);

            foreach (var item in query)
            {
                lstquery.Add(new GetAuthorQueryResult()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Category = item.Category
                });
            }
            result.Success = true;
            result.Message = "Sucesso";
            result.Data = lstquery;
            return result;
        }

        public ICommandResult GetAuthor()
        {
            var result = new CreateAuthorCommandResult(false, "", null);
            var lstquery = new List<GetAuthorQueryResult>();

            var query = _repository.GetAuthor();

            foreach (var item in query)
            {
                lstquery.Add(new GetAuthorQueryResult()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Category = item.Category,
                    Code = item.Code
                });
            }
            result.Success = true;
            result.Message = "Sucesso";
            result.Data = lstquery;
            return result;
        }

        public ICommandResult GetAuthorById(Guid id)
        {
            var result = new CreateAuthorCommandResult(false, "", null);

            if(id == null || id == Guid.Empty)
            {
                result.Success = false;
                result.Message = "Parametros não localizados";
                result.Data = new GetAuthorQueryResult();
                return result;
            }

            var query = _repository.GetAuthorById(id);
            var objeto = new GetAuthorByIdModel()
            {
                Id = query.Id,
                Name = query.Name,
                Category = (int)query.Category,
                Code = query.Code
            };

            result.Success = true;
            result.Message = "Sucesso";
            result.Data = query;
            return result;
        }

        public ICommandResult DeleteById(Guid id)
        {
            var result = new CreateAuthorCommandResult(false, "", null);
            var queryResult = new GetAuthorByIdResultQuery();
            if (id == null || id == Guid.Empty)
            {
                result.Success = false;
                result.Message = "Parametros não localizados";
                result.Data = queryResult;
                return result;
            }

            var author = _repository.GetAuthorById(id);

            if (author == null)
            {
                result.Success = false;
                result.Message = "author não localizada para exclusao";
                result.Data = queryResult;
                return result;
            }

            if (HasAuthor(id))
            {
                result.Success = false;
                result.Message = "Não é possivel excluir o autor,pois existem associaçoes com musicas";
                result.Data = queryResult;
                return result;
            }

            if (!IsValid)
            {
                result.Success = false;
                result.Message = "Não foi possivel apagar a autor";
                result.Data = new CreateAuthorCommand();
                return result;
            }

            try
            {
                _repository.Delete(author);
            }
            catch (Exception e)
            {
                result.Success = false;
                result.Message = e.Message;
                result.Data = new CreateAuthorCommand();
                return result;
            }

            var objeto = new GetAuthorByIdResultQuery()
            {
                Id = author.Id,
                Name = author.Name,
                Category = (int)author.Category,
                Code = author.Code
            };

            result.Success = true;
            result.Message = "Autor apagado";
            result.Data = objeto;
            return result;
        }

        public ICommandResult Handler(CreateAuthorCommand command)
        {
            var result = new CreateAuthorCommandResult(false,"",null);
            var queryResult = new GetAuthorQueryResult();

            if (command == null)
            {
                result.Success = false;
                result.Message = "Parametros não localizados";
                result.Data = queryResult;
                AddNotification(new Notification("Command", "Parametros nao localizados"));
            }


            ECategoryAuthor category;
            try
            {
                category = (ECategoryAuthor)command.Category;
                if (command.Category < 1 && command.Category > 5)
                {
                    result.Success = false;
                    result.Message = "Categoria do autor invalido";
                    result.Data = queryResult;
                    AddNotification(new Notification("Category", "Categoria do autor invalido"));
                }
            }
            catch
            {
                result.Success = false;
                result.Message = "Genero invalido";
                result.Data = queryResult;
                return result;
            }

            
            if (!IsValid)
            {
            
                result.Success = false;
                result.Data = queryResult;
                return result;
            }
                

            var author = new Author(command.Code,command.Name, category);
            _repository.Save(author);

            queryResult.Name = author.Name;
            queryResult.Id = author.Id;
            queryResult.Category = author.ToString();

            result.Success = true;
            result.Message = "Autor criado com sucesso";
            result.Data = queryResult;

            return result;
        }
    }
}
