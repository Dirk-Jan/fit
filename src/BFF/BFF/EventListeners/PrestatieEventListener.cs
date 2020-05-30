using BFF.Constants;
using BFF.Events;
using BFF.Repositories.Abstractions;
using Minor.Miffy.MicroServices.Events;

namespace BFF.EventListeners
{
    public class PrestatieEventListener
    {
        private readonly IPrestatieRepository _prestatieRepository;

        public PrestatieEventListener(IPrestatieRepository prestatieRepository)
        {
            _prestatieRepository = prestatieRepository;
        }

        [EventListener]
        [Topic(TopicNames.PrestatieGeregistreerd)]
        public void HandlePrestatieGeregistreerdEvent(PrestatieGeregistreerdEvent e)
        {
            _prestatieRepository.Add(e.Prestatie);
        }
    }
}