namespace SchoolAPI.DTOs
{
    public class StudentReadDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string? Email { get; set; }
        public DateOnly? BirthDate { get; set; }
    }
}