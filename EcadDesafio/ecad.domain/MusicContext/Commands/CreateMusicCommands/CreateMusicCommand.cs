using ecad.shared.Commands;
using FluentValidator;
using FluentValidator.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ecad.domain.MusicContext.Commands.CreateMusicCommands
{
    public class CreateMusicCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Genre { get; set; }
        public bool Valid()
        {
            AddNotifications(new ValidationContract().Requires()
               .HasMaxLen(Name, 3, "Name", "O nome do musica deve possuir no minimo 3 caracteres")
               .HasMinLen(Name, 50, "Name", "o nome do musica deve possuir no maximo 50 caracteres")
               .AreNotEquals(6, Code.Length, "Code", "O codigo deve possuir 6 caracteres")
               .IsNull(Genre, "Genre", "Campo Genero é obrigatorio")
               );
            return Valid();
        }
    }
}
