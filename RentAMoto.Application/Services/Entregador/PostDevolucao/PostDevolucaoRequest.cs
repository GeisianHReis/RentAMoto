using MediatR;

namespace RentAMoto.Application.Services.Entregador.PostDevolucao
{
    public class PostDevolucaoRequest : IRequest<PostDevolucaoResponse>
    {
        public int EntregadorId { get; set; }
        public DateTime DataDevolucao { get; set; }
    }
}