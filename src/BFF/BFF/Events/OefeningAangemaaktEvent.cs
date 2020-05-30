using BFF.Constants;
using BFF.Models;
using Minor.Miffy.MicroServices.Events;

namespace BFF.Events
{
    public class OefeningAangemaaktEvent : DomainEvent
    {
        public Oefening Oefening { get; set; }

        public OefeningAangemaaktEvent() : base(TopicNames.OefeningAangemaakt)
        {
        }
    }
}