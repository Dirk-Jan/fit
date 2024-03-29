﻿using BFF.Constants;
using BFF.Models;
using Minor.Miffy;

namespace BFF.Events
{
    public class KlantAangemaaktEvent : DomainEvent
    {
        public Klant Klant { get; set; }

        public KlantAangemaaktEvent() : base(TopicNames.KlantAangemaakt)
        {
        }
    }
}