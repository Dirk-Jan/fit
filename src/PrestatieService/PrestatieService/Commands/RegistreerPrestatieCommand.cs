using Minor.Miffy.MicroServices.Commands;
using PrestatieService.Constants;
using PrestatieService.Models;

namespace PrestatieService.Commands
{
    public class RegistreerPrestatieCommand : DomainCommand
    {
        public Prestatie Prestatie { get; set; }

        protected RegistreerPrestatieCommand() : base(QueueNames.RegistreerPrestatie)
        {
        }
    }
}