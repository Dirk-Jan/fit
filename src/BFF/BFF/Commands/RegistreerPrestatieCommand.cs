using BFF.Constants;
using BFF.Models;
using Minor.Miffy.MicroServices.Commands;

namespace BFF.Commands
{
    public class RegistreerPrestatieCommand : DomainCommand
    {
        public Prestatie Prestatie { get; set; }

        public RegistreerPrestatieCommand() : base(QueueNames.RegistreerPrestatie)
        {
        }
    }
}