using ErpStudy.Domain.ValueObjects;

namespace ErpStudy.Domain.Entities
{
    public class User : EntityBase
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}