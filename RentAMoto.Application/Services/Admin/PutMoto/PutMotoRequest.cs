using MediatR;

namespace RentAMoto.Application.Services.Admin.PutMoto
{
    public class PutMotoRequest : IRequest<PutMotoResponse>
    {
        public string PlacaAtual { get; set; }
        public string PlacaNova { get; set; }
    }
}