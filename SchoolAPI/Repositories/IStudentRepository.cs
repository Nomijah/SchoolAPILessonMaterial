using SchoolAPI.Models;

namespace SchoolAPI.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllAsync(CancellationToken ct = default);
        Task<Student?> GetByIdAsync(int id, CancellationToken ct = default);
        Task AddAsync(Student student, CancellationToken ct = default);
        Task UpdateAsync(Student student, CancellationToken ct = default);
        Task DeleteAsync(Student student, CancellationToken ct = default);
        Task<bool> SaveChangesAsync(CancellationToken ct = default);
    }
}
