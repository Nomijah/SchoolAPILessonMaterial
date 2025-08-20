using Microsoft.AspNetCore.JsonPatch;
using SchoolAPI.DTOs;
using SchoolAPI.Models;

namespace SchoolAPI.Services
{
    public interface IStudentService
    {
        Task<List<StudentReadDto>> GetAllAsync(CancellationToken ct = default);
        Task<StudentReadDto?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<int> CreateAsync(StudentCreateDto dto, CancellationToken ct = default);
        Task<bool> UpdateAsync(int id, StudentUpdateDto dto, CancellationToken ct = default);
        Task<bool> PatchAsync(int id, JsonPatchDocument<Student> patchDoc, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
    }
}
