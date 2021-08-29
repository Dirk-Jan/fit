using BFF.Constants;
using BFF.Models;
using Minor.Miffy;

namespace BFF.Events
{
    public class PrestatieGeregistreerdEvent : DomainEvent
    {
        public Prestatie Prestatie { get; set; }

        public PrestatieGeregistreerdEvent() : base(TopicNames.PrestatieGeregistreerd)
        {
        }
    }
}