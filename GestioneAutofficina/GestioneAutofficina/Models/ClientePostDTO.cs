namespace GestioneAutofficina.Models
{
    public class ClientePostDTO
    {
        public string Nome { get; set; } = null!;
        public string Cognome { get; set; } = null!;
        public string Indirizzo { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string? Email { get; set; }
    }
}
