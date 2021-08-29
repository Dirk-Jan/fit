using Minor.Miffy;
using Spekkie.Constants;
using Spekkie.Models;

namespace Spekkie.Commands
{
    public class MaakKlantAanCommand : DomainCommand
    {
        public Klant Klant { get; set; }

        public MaakKlantAanCommand() : base(QueueNames.MaakKlantAan)
        {
        }
    }
}