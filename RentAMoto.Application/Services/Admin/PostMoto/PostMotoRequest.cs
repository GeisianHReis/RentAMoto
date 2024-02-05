using MediatR;

namespace RentAMoto.Application.Services.Admin.PostMoto
{
    public class PostMotoRequest : IRequest<PostMotoResponse>
    {
        public string Ano { get; set; }
        public string Placa { get; set; }
        public string Modelo { get; set; }
    }
}