using KlantService.Commands;
using KlantService.Constants;
using KlantService.Events;
using KlantService.Models;
using KlantService.Repositories.Abstractions;
using Minor.Miffy.MicroServices.Commands;
using Minor.Miffy.MicroServices.Events;

namespace KlantService.CommandListeners
{
    public class KlantCommandListener
    {
        private readonly IKlantRepository _klantRepository;
        private readonly IEventPublisher _eventPublisher;
        
        public KlantCommandListener(IKlantRepository klantRepository, IEventPublisher eventPublisher)
        {
            _klantRepository = klantRepository;
            _eventPublisher = eventPublisher;
        }

        [CommandListener(QueueNames.MaakKlantAan)]
        public MaakKlantAanCommand HandleMaakKlantAanCommand(MaakKlantAanCommand command)
        {
            _klantRepository.Add(command.Klant);

            _eventPublisher.PublishAsync(new KlantAangemaaktEvent
            {
                Klant = command.Klant
            });
            
            return command;
        }
    }
}