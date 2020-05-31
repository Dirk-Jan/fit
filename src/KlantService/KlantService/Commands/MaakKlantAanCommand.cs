﻿using System;
using KlantService.Constants;
using KlantService.Models;
using Minor.Miffy.MicroServices.Commands;

namespace KlantService.Commands
{
    public class MaakKlantAanCommand : DomainCommand
    {
        public Klant Klant { get; set; }

        protected MaakKlantAanCommand() : base(QueueNames.MaakKlantAan)
        {
        }
    }
}