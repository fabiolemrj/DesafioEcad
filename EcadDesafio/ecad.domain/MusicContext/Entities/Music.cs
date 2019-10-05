using ecad.domain.MusicContext.Enums;
using ecad.shared.Entities;
using FluentValidator.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ecad.domain.MusicContext.Entities
{
    public class Music:Entity
    {
        public string Code { get; private set; }
        public string Name { get; private set; }
        public ETypeGenreMusic Genre { get; private set; }

        public ICollection<MusicAuthor> MusicAuthors { get; private set; }

        public Music(string code, string name, ETypeGenreMusic geren)
        {

            Validate(code, name, geren);
            MusicAuthors = new List<MusicAuthor>();
        }

        private void Validate(string code, string name, ETypeGenreMusic geren)
        {
            AddNotifications(new ValidationContract().Requires()
                .HasMinLen(name, 3, "Name", "O nome do musica deve possuir no minimo 3 caracteres")
                .HasMaxLen(name, 50, "Name", "o nome do musica deve possuir no maximo 50 caracteres")
                .AreEquals(6, code.Length, "Code", "O codigo deve possuir 6 caracteres")
                .IsNotNull(geren, "Genre", "Campo Genero é obrigatorio")
                );

            Code = code;
            Name = name;
            Genre = geren;
        }

        public void Update(string code, string name, ETypeGenreMusic geren)
        {
            Validate(code, name, geren);
        }

        public Music()
        {

        }
    }
}
