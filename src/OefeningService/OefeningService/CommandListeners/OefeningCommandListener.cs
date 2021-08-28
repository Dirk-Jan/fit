using Minor.Miffy.MicroServices;
using Minor.Miffy.MicroServices.Abstractions;
using OefeningService.Commands;
using OefeningService.Constants;
using OefeningService.Events;
using OefeningService.Repositories.Abstractions;

namespace OefeningService.CommandListeners
{
    public class OefeningCommandListener
    {
        private readonly IOefeningRepository _oefeningRepository;
        private readonly IEventPublisher _eventPublisher;

        public OefeningCommandListener(IOefeningRepository oefeningRepository, IEventPublisher eventPublisher)
        {
            _oefeningRepository = oefeningRepository;
            _eventPublisher = eventPublisher;
        }
        
        [CommandListener]
        public MaakOefeningAanCommand HandleMaakKlantAanCommand(MaakOefeningAanCommand command)
        {
            _oefeningRepository.Add(command.Oefening);

            _eventPublisher.PublishAsync(new OefeningAangemaaktEvent
            {
                Oefening = command.Oefening
            });
            
            return command;
        }
        
        [CommandListener]
        public PasOefeningAanCommand HandlePasOefeningAanCommand(PasOefeningAanCommand command)
        {
            _oefeningRepository.Edit(command.Oefening);

            _eventPublisher.PublishAsync(new OefeningAangepastEvent
            {
                Oefening = command.Oefening
            });
            
            return command;
        }
    }
}