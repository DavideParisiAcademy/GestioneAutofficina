using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestioneAutofficina.Models
{
    [Table("Cliente")]
    public partial class Cliente
    {
        
        public int ClienteID { get; set; }
        public string CodCliente { get; set; } = null!;
        public string Nome { get; set; } = null!;
        public string Cognome { get; set; } = null!;
        public string Indirizzo { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string? Email { get; set; }

        public virtual ICollection<Veicolo>? VeicoliList { get; set; } = new List<Veicolo>();

    }
}
