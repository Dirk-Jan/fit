using Minor.Miffy;
using OefeningService.Constants;
using OefeningService.Models;

namespace OefeningService.Events
{
    public class OefeningAangemaaktEvent : DomainEvent
    {
        public Oefening Oefening { get; set; }

        public OefeningAangemaaktEvent() : base(TopicNames.OefeningAangemaakt)
        {
        }
    }
}