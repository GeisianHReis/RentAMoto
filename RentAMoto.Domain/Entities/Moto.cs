using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentAMoto.Domain.Entities
{
    public class Moto : EntityBase
    {

        public string Ano { get; set; }

        public string Modelo { get; set; }

        public string Placa { get; set; }

        public bool Disponivel { get; set; }
    }
}