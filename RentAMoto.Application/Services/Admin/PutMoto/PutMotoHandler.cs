using MediatR;
using RentAMoto.Application.Services.Admin.PutMoto.Handlers;
using RentAMoto.Infrastructure.Interfaces;

namespace RentAMoto.Application.Services.Admin.PutMoto
{
    public class PutMotoHandler : IRequestHandler<PutMotoRequest, PutMotoResponse>
    {
        private readonly IMotoRepository _motoRepository;

        public PutMotoHandler(IMotoRepository motoRepository)
        {
            _motoRepository = motoRepository;
        }
        public async Task<PutMotoResponse> Handle(PutMotoRequest request, CancellationToken cancellationToken)
        {
            var response = new PutMotoResponse();

            var h0 = new PutPlacaMotoHandler(_motoRepository);

            await h0.Process(request, response);

            return response;
        }
    }
}