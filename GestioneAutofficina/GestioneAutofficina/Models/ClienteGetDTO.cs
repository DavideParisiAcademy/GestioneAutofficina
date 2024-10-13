namespace GestioneAutofficina.Models
{
    public class ClienteGetDTO
    {
        public string CodCliente { get; set; } = null!;
        public string Nome { get; set; } = null!;
        public string Cognome { get; set; } = null!;
        public string Indirizzo { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string? Email { get; set; }
    }
}
