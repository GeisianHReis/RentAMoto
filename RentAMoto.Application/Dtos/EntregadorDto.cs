using RentAMoto.Application.Response;

namespace RentAMoto.Application.Dtos
{
    public class EntregadorDto : ResponseBase<EntregadorDto>
    {

        public string Nome { get; set; }

        public string CNPJ { get; set; }

        public DateTime DataNascimento { get; set; }

        public string NumeroCNH { get; set; }

        public TipoCNH TipoCNH { get; set; }
        public string? ImagemCNHUrl { get; set; }
    }
    public enum TipoCNH
    {
        A,
        B,
        AB
    }
}