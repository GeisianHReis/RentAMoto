using RentAMoto.Application.Response;

namespace RentAMoto.Application.Dtos
{
    public class MotoResponseGetAllDto
    {
        public MotoResponseGetAllDto()
        {
            Motos = new();
        }
        public List<MotoResponseDto> Motos { get; set; }
    }

}