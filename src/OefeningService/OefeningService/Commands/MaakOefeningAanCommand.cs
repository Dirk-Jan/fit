using Minor.Miffy;
using OefeningService.Constants;
using OefeningService.Models;

namespace OefeningService.Commands
{
    public class MaakOefeningAanCommand : DomainCommand
    {
        public Oefening Oefening { get; set; }

        public MaakOefeningAanCommand() : base(QueueNames.MaakOefeningAan)
        {
        }
    }
}