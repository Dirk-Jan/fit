using BFF.Constants;
using BFF.Models;
using Minor.Miffy.MicroServices.Events;

namespace BFF.Events
{
    public class OefeningAangepastEvent : DomainEvent
    {
        public Oefening Oefening { get; set; }

        public OefeningAangepastEvent() : base(TopicNames.OefeningAangepast)
        {
        }
    }
}