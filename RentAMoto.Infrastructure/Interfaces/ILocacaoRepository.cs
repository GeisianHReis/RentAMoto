using RentAMoto.Domain.Entities;

namespace RentAMoto.Infrastructure.Interfaces
{
    public interface ILocacaoRepository
    {
        Task<bool> AddLocacaoAsync(Locacao locacao);
        Task<Locacao> GetLocacaoByEntregadorIdAsync(int entregadorId);
    }
}