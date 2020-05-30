using BFF.Constants;
using BFF.Events;
using BFF.Repositories.Abstractions;
using Minor.Miffy.MicroServices.Events;

namespace BFF.EventListeners
{
    public class KlantEventListener
    {
        private readonly IKlantRepository _klantRepository;

        public KlantEventListener(IKlantRepository klantRepository)
        {
            _klantRepository = klantRepository;
        }

        [EventListener]
        [Topic(TopicNames.KlantAangemaakt)]
        public void HandleNKlantAangemaaktEvent(KlantAangemaaktEvent e)
        {
            _klantRepository.AddKlant(e.Klant);
        }
    }
}