namespace DotnetBackend.Models
{
    public class User
    {
        public required int Id { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public string? DisplayName { get; set; }
        public string? Email { get; set; }
    }
}
