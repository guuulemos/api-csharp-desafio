﻿using Desafio.Infra.Interfaces.Commands;
using Flunt.Notifications;
using System;
using System.Text.Json.Serialization;

namespace Desafio.Domain.Commands.Inputs.FilmeInputs
{
    public class ExcluirFilmeCommand : Notifiable, ICommandPadrao
    {
        [JsonIgnore]
        public long Id { get; set; }

        public bool ValidarCommand()
        {
            try
            {
                if (Id <= 0)
                    AddNotification("Id", "Id deve ser maior que zero");

                return Valid;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
