namespace RentAMoto.Domain.Entities
{
    public class Pedido : EntityBase
    {
        public DateTime DataDeCriacao { get; set; }

        public decimal ValorCorrida { get; set; }

        public SituacaoEnum Situacao { get; set; }
    }

    public enum SituacaoEnum
    {
        Disponivel,
        Aceito,
        Entregue
    }
}