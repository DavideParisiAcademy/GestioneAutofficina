using System.ComponentModel.DataAnnotations.Schema;

namespace GestioneAutofficina.Models
{
    public class VeicoloPostDTO
    {
        
        public string Targa { get; set; } = null!;
        public string Marca { get; set; } = null!;
        public DateOnly AnnoImm { get; set; }
        public decimal PIntervento { get; set; }
        public string Stato { get; set; } = null!;
        public DateOnly DataIni { get; set; }
        public int ClienteRif { get; set; }
    }
}
