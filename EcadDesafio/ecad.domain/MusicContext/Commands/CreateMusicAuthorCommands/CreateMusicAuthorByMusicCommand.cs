using ecad.shared.Commands;
using FluentValidator;
using FluentValidator.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ecad.domain.MusicContext.Commands.CreateMusicAuthorCommands
{
    public class CreateMusicAuthorByMusicCommand : Notifiable, ICommand
    {
        public Guid MusicId { get; set; }
        public bool Valid()
        {
            AddNotifications(new ValidationContract().Requires()
        .IsNull(MusicId, "MusicId", "ID da musica não informado"));

            return Valid();
        }
    }
}
