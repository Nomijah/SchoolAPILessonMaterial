using Microsoft.EntityFrameworkCore;
using SchoolAPI.Data;
using SchoolAPI.Models;

namespace SchoolAPI.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolContext _ctx;

        public StudentRepository(SchoolContext ctx) => _ctx = ctx;

        public async Task AddAsync(Student student, CancellationToken ct = default)
        {
            await _ctx.Students.AddAsync(student);
        }

        public Task DeleteAsync(Student student, CancellationToken ct = default)
        {
            _ctx.Students.Remove(student);
            return Task.CompletedTask;
        }

        public async Task<List<Student>> GetAllAsync(CancellationToken ct = default)
        {
            return await _ctx.Students
                .AsNoTracking()
                .OrderBy(s => s.LastName)
                .ThenBy(s => s.FirstName)
                .ToListAsync(ct);
        }

        public async Task<Student?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return await _ctx.Students.FirstOrDefaultAsync(s => s.Id == id, ct);
        }

        public Task<bool> SaveChangesAsync(CancellationToken ct = default)
        {
            return _ctx.SaveChangesAsync(ct).ContinueWith(t => t.Result > 0, ct);
        }

        public Task UpdateAsync(Student student, CancellationToken ct = default)
        {
            _ctx.Students.Update(student);
            return Task.CompletedTask;
        }
    }
}
