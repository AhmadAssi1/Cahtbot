namespace login.models
{
    public class user
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty; // Initialize to non-null value
        public string LastName { get; set; } = string.Empty;  // Initialize to non-null value
        public string Email { get; set; } = string.Empty;     // Initialize to non-null value
        public string Password { get; set; } = string.Empty;
        public DateTime BarthDate { get; set; }



    }
}
