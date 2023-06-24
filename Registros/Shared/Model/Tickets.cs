using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Registros.Shared.Model
{
    public class Tickets
    {
        [Key]
        public int TicketId { get; set; }

        public DateTime FechaT { get; set; } = DateTime.Now;

        public int ClienteId { get; set; }

        public int SistemaId { get; set; }

        public int PrioridadId { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el por quien fue solicitado")]
        public string? SolicitadoPor { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir Un Asunto")]
        public string? Asunto { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir una Descripcion")]
        public string? Descripcion { get; set; }

       
    }    
}
