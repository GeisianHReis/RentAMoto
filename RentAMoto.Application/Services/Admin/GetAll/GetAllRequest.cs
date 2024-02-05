using MediatR;

namespace RentAMoto.Application.Services.Admin.GetAll
{
    public class GetAllRequest : IRequest<GetAllResponse>
    {
        public string? Placa { get; set; }
    }
}