using MediatR;
using RentAMoto.Domain.Entities;

namespace RentAMoto.Application.Services.Admin.PostPedido
{
    public class PostPedidoRequest : IRequest<PostPedidoResponse>
    {
        public DateTime DataDeCriacao { get; set; }
        public decimal ValorCorrida { get; set; }
        public SituacaoEnum Situacao { get; set; }
    }
}