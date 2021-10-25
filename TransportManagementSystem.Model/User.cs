namespace TransportManagementSystem.Model
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public UserTypes UserType { get; set; }
    }

    public enum UserTypes { 
        Passenger = 1,
        Driver = 2,
        TransportManager =3,
        Inspector = 4
    }
}