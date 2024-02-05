using MediatR;
using RentAMoto.Application.Enum;

namespace RentAMoto.Application.Services.Entregador.PostLocacao
{
    public class PostLocacaoRequest : IRequest<PostLocacaoResponse>
    {
        public PlanoLocacao PlanoLocacao { get; set; }
        public int EntregadorId { get; set; }
    }
}