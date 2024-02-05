using MediatR;
using RentAMoto.Application.Dtos;

namespace RentAMoto.Application.Services.Entregador.PostEntregador
{
    public class PostEntregadorRequest : IRequest<PostEntregadorResponse>
    {
        public string Nome { get; set; }

        public string CNPJ { get; set; }

        public DateTime DataNascimento { get; set; }

        public string NumeroCNH { get; set; }

        public TipoCNH TipoCNH { get; set; }
    }
}