namespace RentAMoto.Application.Dtos
{
    public class LocacaoDto
    {
        public int EntregadorId { get; set; }
        public int MotoId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataPrevisaoTermino { get; set; }
    }
}