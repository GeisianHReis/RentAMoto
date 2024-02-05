using RentAMoto.Application.Enum;

namespace RentAMoto.Application.Interfaces
{
    public interface ILocacaoService
    {
        Task<bool> Locacao(int entregadorId, DateTime dataInicio, DateTime dataTermino, PlanoLocacao plano);
    }
}