using BFF.Constants;
using BFF.Events;
using BFF.Repositories.Abstractions;
using Minor.Miffy.MicroServices.Events;

namespace BFF.EventListeners
{
    public class OefeningEventListener
    {
        private readonly IOefeningRepository _oefeningRepository;

        public OefeningEventListener(IOefeningRepository oefeningRepository)
        {
            _oefeningRepository = oefeningRepository;
        }

        [EventListener]
        [Topic(TopicNames.OefeningAangemaakt)]
        public void HandleOefeningAangemaaktEvent(OefeningAangemaaktEvent e)
        {
            _oefeningRepository.Add(e.Oefening);
        }
    }
}