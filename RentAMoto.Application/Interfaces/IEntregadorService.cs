using Microsoft.AspNetCore.Http;
using RentAMoto.Application.Dtos;

namespace RentAMoto.Application.Interfaces
{
    public interface IEntregadorService
    {
        Task<bool> CadastrarEntregadorAsync(EntregadorDto entregadorDto);
        Task<bool> AtualizarFotoCNHAsync(int entregadorId, IFormFile fotoCnh);
        Task<bool> AlugarMotoAsync(int entregadorId, int motoId, DateTime dataInicio, DateTime dataTermino);
    }

}