using ecad.domain.MusicContext.Enums;
using ecad.shared.Entities;
using FluentValidator.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ecad.domain.MusicContext.Entities
{
    public class Author: Entity
    {
        public string Code { get; private set; }
        public string Name { get; private set; }
        public ECategoryAuthor Category { get; private set; }
        public ICollection<MusicAuthor> MusicAuthors { get; private set; }

        public Author(string code, string name, ECategoryAuthor category)
        {
            AddNotifications(new ValidationContract().Requires()
                .HasMinLen(name,3,"Name","O nome do autor deve possuir no minimo 3 caracteres")
                .HasMaxLen(name, 50, "Name","o nome do autor deve possuir no maximo 50 caracteres")
                .IsNotNull(category,"Category","Campo Categoria é obrigatorio")
                .IsNotNull(code, "Code", "Campo Codigo é obrigatorio")
                );

            Name = name;
            Code = code;
            Category = category;
            MusicAuthors = new List<MusicAuthor>();
        }

        public Author()
        {

        }
    }
}
