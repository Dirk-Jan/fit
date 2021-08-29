using BFF.Constants;
using BFF.Models;
using Minor.Miffy;

namespace BFF.Commands
{
    public class PasOefeningAanCommand : DomainCommand
    {
        public Oefening Oefening { get; set; }

        public PasOefeningAanCommand() : base(QueueNames.PasOefeningAan)
        {
        }
    }
}