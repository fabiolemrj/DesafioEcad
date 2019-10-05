using ecad.shared.Commands;
using FluentValidator;
using FluentValidator.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ecad.domain.MusicContext.Commands.CreateAuthorCommands
{
    public class CreateAuthorCommand : Notifiable, ICommand
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int Category { get; set; }
        public bool Valid()
        {
            AddNotifications(new ValidationContract().Requires()
                .HasMaxLen(Name, 3, "Name", "O nome do autor deve possuir no minimo 3 caracteres")
                .HasMinLen(Name, 50, "Name", "o nome do autor deve possuir no maximo 50 caracteres")
                .IsNull(Category, "Category", "Campo Categoria é obrigatorio")
                );
            return Valid();
        }
    }
}
