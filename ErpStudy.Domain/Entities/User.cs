namespace ErpStudy.Domain.Entities
{
    public class User : EntityBase
    {
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}