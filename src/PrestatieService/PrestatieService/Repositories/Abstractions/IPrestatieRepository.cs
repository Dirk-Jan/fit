using PrestatieService.Models;

namespace PrestatieService.Repositories.Abstractions
{
    public interface IPrestatieRepository
    {
        void Add(Prestatie prestatie);
    }
}