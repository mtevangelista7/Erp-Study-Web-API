namespace ErpStudy.Domain.Entities
{
    public class Usuario
    {
        public Guid UsuarioId { get; set; }
        public string NomeUsuario { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}