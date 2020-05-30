using KlantService.Models;

namespace KlantService.Repositories.Abstractions
{
    public interface IKlantRepository
    {
        void Add(Klant klant);
    }
}