using static TransportManagementSystem.Model.Types.Enums;

namespace TransportManagementSystem.Model
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public UserTypes UserType { get; set; }
    }


}