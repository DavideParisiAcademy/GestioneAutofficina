using System.ComponentModel.DataAnnotations.Schema;

namespace GestioneAutofficina.Models
{
    public class CliVeiGetDTO
    {
        public string CodCliente { get; set; } = null!;
        public string Nome { get; set; } = null!;
        public string Cognome { get; set; } = null!;
        public string Indirizzo { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string? Email { get; set; }
        public List<VeicoloGetDTO>? VeicoliList { get; set; } = new List<VeicoloGetDTO>();

    }
}
