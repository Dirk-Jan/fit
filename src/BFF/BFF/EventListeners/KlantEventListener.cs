using BFF.Constants;
using BFF.Events;
using BFF.Repositories.Abstractions;
using Minor.Miffy.MicroServices;

namespace BFF.EventListeners
{        
    [EventListener]
    public class KlantEventListener
    {
        private readonly IKlantRepository _klantRepository;

        public KlantEventListener(IKlantRepository klantRepository)
        {
            _klantRepository = klantRepository;
        }

        [Topic(TopicNames.KlantAangemaakt)]
        public void HandleKlantAangemaaktEvent(KlantAangemaaktEvent e)
        {
            _klantRepository.AddKlant(e.Klant);
        }
    }
}