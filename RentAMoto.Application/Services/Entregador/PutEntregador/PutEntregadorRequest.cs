using MediatR;
using Microsoft.AspNetCore.Http;

namespace RentAMoto.Application.Services.Entregador.PutEntregador
{
    public class PutEntregadorRequest : IRequest<PutEntregadorResponse>
    {
        public string NumeroCNH { get; set; }
        public IFormFile FotoCNH { get; set; }
    }
}