using RentAMoto.Application.Dtos;
using RentAMoto.Application.Response;

namespace RentAMoto.Application.Services.Admin.GetAll
{
    public class GetAllResponse : ResponseBase<MotoResponseGetAllDto>
    {
        public GetAllResponse()
        {
            Data = new MotoResponseGetAllDto();
        }
    }
}