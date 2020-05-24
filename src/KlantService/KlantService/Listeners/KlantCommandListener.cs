using KlantService.Commands;
using KlantService.Constants;
using KlantService.Events;
using KlantService.Models;
using KlantService.Repositories.Abstractions;
using Minor.Miffy.MicroServices.Commands;
using Minor.Miffy.MicroServices.Events;

namespace KlantService.Listeners
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
        public Klant HandleMaakKlantAanCommand(MaakKlantAanCommand command)    // TODO: Niet zeker of ik hier zomaar klant mag teruggeven
        {
            _klantRepository.AddKlant(command.Klant);

            _eventPublisher.PublishAsync(new KlantAangemaaktEvent
            {
                Klant = command.Klant
            });
            
            return command.Klant;
        }
    }
}