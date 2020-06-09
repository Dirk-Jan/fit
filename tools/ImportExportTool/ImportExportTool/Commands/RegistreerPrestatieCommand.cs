using ImportExportTool.Constants;
using ImportExportTool.Models;
using Minor.Miffy.MicroServices.Commands;

namespace ImportExportTool.Commands
{
    public class RegistreerPrestatieCommand : DomainCommand
    {
        public Prestatie Prestatie { get; set; }

        public RegistreerPrestatieCommand() : base(QueueNames.RegistreerPrestatie)
        {
        }
    }
}