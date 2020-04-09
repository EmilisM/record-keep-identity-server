using System;

namespace record_keep_identity_server.DBO.User
{
    public partial class UserData
    {
        public int Id { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public DateTime CreationDate { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
    }
}