﻿using BFF.Constants;
using BFF.Models;
using Minor.Miffy;

namespace BFF.Commands
{
    public class MaakOefeningAanCommand : DomainCommand
    {
        public Oefening Oefening { get; set; }

        public MaakOefeningAanCommand() : base(QueueNames.MaakOefeningAan)
        {
        }
    }
}