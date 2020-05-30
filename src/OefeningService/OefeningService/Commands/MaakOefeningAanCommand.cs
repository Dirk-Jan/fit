using Minor.Miffy.MicroServices.Commands;
using OefeningService.Constants;
using OefeningService.Models;

namespace OefeningService.Commands
{
    public class MaakOefeningAanCommand : DomainCommand
    {
        public Oefening Oefening { get; set; }

        protected MaakOefeningAanCommand() : base(QueueNames.MaakOefeningAan)
        {
        }
    }
}