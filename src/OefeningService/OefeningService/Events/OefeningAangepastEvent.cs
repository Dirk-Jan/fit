using Minor.Miffy;
using OefeningService.Constants;
using OefeningService.Models;

namespace OefeningService.Events
{
    public class OefeningAangepastEvent : DomainEvent
    {
        public Oefening Oefening { get; set; }

        public OefeningAangepastEvent() : base(TopicNames.OefeningAangepast)
        {
        }
    }
}