namespace GestioneAutofficina.Models
{
    public class VeiCliGetDTO
    {
        public string CodVeicolo { get; set; } = null!;
        public string Targa { get; set; } = null!;
        public string Marca { get; set; } = null!;
        public DateOnly AnnoImm { get; set; }
        public decimal PIntervento { get; set; }
        public string Stato { get; set; } = null!;
        public DateOnly DataIni { get; set; }
        public Cliente? Cliente { get; set; }
    }
}
