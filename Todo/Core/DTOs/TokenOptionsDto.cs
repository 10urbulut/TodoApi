namespace Todo.Core.DTOs
{
    public class TokenOptionsDto
    {
        public string? Audience { get; set; }
        public string? Issuer { get; set; }
        public string? SecurityKey { get; set; }
    }
}
