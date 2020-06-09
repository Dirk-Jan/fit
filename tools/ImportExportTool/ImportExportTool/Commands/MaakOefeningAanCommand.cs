using ImportExportTool.Constants;
using ImportExportTool.Models;
using Minor.Miffy.MicroServices.Commands;

namespace ImportExportTool.Commands
{
    public class MaakOefeningAanCommand : DomainCommand
    {
        public Oefening Oefening { get; set; }

        public MaakOefeningAanCommand() : base(QueueNames.MaakOefeningAan)
        {
        }
    }
}