using System.ComponentModel.DataAnnotations.Schema;

namespace GestioneAutofficina.Models
{
    [Table("Veicolo")]
    public partial class Veicolo
    {

        public int VeicoloID { get; set; }
        public string CodVeicolo { get; set; } = null!;
        public string Targa { get; set; } = null!;
        public string Marca { get; set; } = null!;
        public DateOnly? AnnoImm { get; set; }
        public decimal? PIntervento { get; set; }
        public string Stato { get; set; } = null!;
        public DateOnly? DataIni { get; set; }

        [ForeignKey("Cliente")]
        public int? ClienteRif { get; set; }

        public Cliente? Cliente { get; set; }


    }
}
