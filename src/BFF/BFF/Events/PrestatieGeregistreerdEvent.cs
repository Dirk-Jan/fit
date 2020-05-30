using BFF.Constants;
using BFF.Models;
using Minor.Miffy.MicroServices.Events;

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