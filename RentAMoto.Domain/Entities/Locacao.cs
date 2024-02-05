using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentAMoto.Domain.Entities
{
    public class Locacao : EntityBase
    {

        public int EntregadorId { get; set; } 


        public int MotoId { get; set; } 


        public DateTime DataInicio { get; set; } 


        public DateTime? DataTermino { get; set; } 

        public DateTime? DataPrevisaoTermino { get; set; }

        public decimal Valor { get; set; }

        [ForeignKey("EntregadorId")]
        public Entregador? Entregador { get; set; }

        [ForeignKey("MotoId")]
        public Moto? Moto { get; set; }
    }
}