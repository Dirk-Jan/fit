using Minor.Miffy;
using PrestatieService.Constants;
using PrestatieService.Models;

namespace PrestatieService.Commands
{
    public class RegistreerPrestatieCommand : DomainCommand
    {
        public Prestatie Prestatie { get; set; }

        public RegistreerPrestatieCommand() : base(QueueNames.RegistreerPrestatie)
        {
        }
    }
}