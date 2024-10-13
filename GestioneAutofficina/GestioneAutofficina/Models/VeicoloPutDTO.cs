namespace GestioneAutofficina.Models
{
    public class VeicoloPutDTO
    {
        public string? Targa { get; set; } 
        public string? Marca { get; set; }
        public DateOnly? AnnoImm { get; set; }
        public decimal? PIntervento { get; set; }
        public string? Stato { get; set; }
        public DateOnly? DataIni { get; set; }
        public int? ClienteRif { get; set; }
    }
}
