using Minor.Miffy.MicroServices.Events;
using PrestatieService.Constants;
using PrestatieService.Models;

namespace PrestatieService.Events
{
    public class PrestatieGeregistreerdEvent : DomainEvent
    {
        public Prestatie Prestatie { get; set; }

        public PrestatieGeregistreerdEvent() : base(TopicNames.PrestatieGeregistreerd)
        {
        }
    }
}