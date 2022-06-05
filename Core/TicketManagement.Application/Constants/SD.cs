namespace TicketManagement.Application.Constants
{
    public static class SD
    {
        //Add roles with the same name in enum, declared for authentication 
        public const string Role_Admin = "Admin"; 
        public const string Role_User = "User";
    }

    public enum IdentityRoles { Admin, User } //for Add Role request
}
