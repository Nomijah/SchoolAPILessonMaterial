namespace SchoolAPI.DTOs
{
    public class StudentCreateDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Email { get; set; }
        public DateOnly? BirthDate { get; set; }
    }
}