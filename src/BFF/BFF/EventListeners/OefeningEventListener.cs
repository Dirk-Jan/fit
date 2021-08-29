using BFF.Constants;
using BFF.Events;
using BFF.Repositories.Abstractions;
using Minor.Miffy.MicroServices;

namespace BFF.EventListeners
{
    [EventListener]
    public class OefeningEventListener
    {
        private readonly IOefeningRepository _oefeningRepository;

        public OefeningEventListener(IOefeningRepository oefeningRepository)
        {
            _oefeningRepository = oefeningRepository;
        }
        
        [Topic(TopicNames.OefeningAangemaakt)]
        public void HandleOefeningAangemaaktEvent(OefeningAangemaaktEvent e)
        {
            _oefeningRepository.Add(e.Oefening);
        }
        
        [Topic(TopicNames.OefeningAangepast)]
        public void HandleOefeningAangepastEvent(OefeningAangepastEvent e)
        {
            _oefeningRepository.Edit(e.Oefening);
        }
    }
}