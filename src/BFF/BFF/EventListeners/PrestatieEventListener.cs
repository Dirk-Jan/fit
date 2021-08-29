using BFF.Constants;
using BFF.Events;
using BFF.Repositories.Abstractions;
using Minor.Miffy.MicroServices;

namespace BFF.EventListeners
{
    [EventListener]
    public class PrestatieEventListener
    {
        private readonly IPrestatieRepository _prestatieRepository;

        public PrestatieEventListener(IPrestatieRepository prestatieRepository)
        {
            _prestatieRepository = prestatieRepository;
        }

        [Topic(TopicNames.PrestatieGeregistreerd)]
        public void HandlePrestatieGeregistreerdEvent(PrestatieGeregistreerdEvent e)
        {
            _prestatieRepository.Add(e.Prestatie);
        }
    }
}