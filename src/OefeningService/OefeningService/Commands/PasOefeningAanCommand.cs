using Minor.Miffy;
using OefeningService.Constants;
using OefeningService.Models;

namespace OefeningService.Commands
{
    public class PasOefeningAanCommand : DomainCommand
    {
        public Oefening Oefening { get; set; }

        public PasOefeningAanCommand() : base(QueueNames.PasOefeningAan)
        {
        }
    }
}