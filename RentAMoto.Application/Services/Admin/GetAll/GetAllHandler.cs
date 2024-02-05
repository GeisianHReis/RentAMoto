using MediatR;
using RentAMoto.Application.Services.Admin.GetAll.Handlers;
using RentAMoto.Infrastructure.Interfaces;

namespace RentAMoto.Application.Services.Admin.GetAll
{
    public class GetAllHandler : IRequestHandler<GetAllRequest, GetAllResponse>
    {
        private readonly IMotoRepository _motoRepository;

        public GetAllHandler(IMotoRepository motoRepository)
        {
            _motoRepository = motoRepository;
        }
        public async Task<GetAllResponse> Handle(GetAllRequest request, CancellationToken cancellationToken)
        {
            var response = new GetAllResponse();

            var h0 = new GetAllMotoHandler(_motoRepository);

            await h0.Process(request, response);

            return response;
        }
    }
}