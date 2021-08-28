using Minor.Miffy.MicroServices;
using Minor.Miffy.MicroServices.Abstractions;
using PrestatieService.Commands;
using PrestatieService.Constants;
using PrestatieService.Events;
using PrestatieService.Repositories.Abstractions;

namespace PrestatieService.CommandListeners
{
    public class PrestatieCommandListener
    {
        private readonly IPrestatieRepository _prestatieRepository;
        private readonly IEventPublisher _eventPublisher;

        public PrestatieCommandListener(IPrestatieRepository prestatieRepository, IEventPublisher eventPublisher)
        {
            _prestatieRepository = prestatieRepository;
            _eventPublisher = eventPublisher;
        }
        
        [CommandListener]
        public RegistreerPrestatieCommand HandleMaakKlantAanCommand(RegistreerPrestatieCommand command)
        {
            _prestatieRepository.Add(command.Prestatie);

            _eventPublisher.PublishAsync(new PrestatieGeregistreerdEvent
            {
                Prestatie = command.Prestatie
            });
            
            return command;
        }
    }
}