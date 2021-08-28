using KlantService.Constants;
using KlantService.Models;
using Minor.Miffy;

namespace KlantService.Events
{
    public class KlantAangemaaktEvent : DomainEvent
    {
        public Klant Klant { get; set; }

        public KlantAangemaaktEvent() : base(TopicNames.KlantAangemaakt)
        {
        }
    }
}