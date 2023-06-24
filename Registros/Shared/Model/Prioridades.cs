using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Registros.Shared.Model
{
    public class Prioridades
    {
        [Key] 
        public int PrioridadId { get; set; }

        public string? Descripcion { get; set; }

        public DateTime DiasCompromiso { get; set; } = DateTime.Now;
    }
}
