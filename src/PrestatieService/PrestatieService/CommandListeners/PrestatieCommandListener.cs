using Minor.Miffy.MicroServices.Commands;
using Minor.Miffy.MicroServices.Events;
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
        
        [CommandListener(QueueNames.RegistreerPrestatie)]
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