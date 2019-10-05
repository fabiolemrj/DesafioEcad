using ecad.shared.Commands;
using FluentValidator;
using FluentValidator.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ecad.domain.MusicContext.Commands.CreateMusicAuthorCommands
{
    public class CreateMusicAuthorCommand : Notifiable, ICommand
    {
        public Guid MusicId { get; set; }
        public Guid AuthorId { get; set; }
        public bool Valid()
        {
           

            return Valid();
        }
    }
}
