using KlantService.Constants;
using KlantService.Models;
using Minor.Miffy;

namespace KlantService.Commands
{
    public class MaakKlantAanCommand : DomainCommand
    {
        public Klant Klant { get; set; }

        public MaakKlantAanCommand() : base(QueueNames.MaakKlantAan)
        {
        }
    }
}