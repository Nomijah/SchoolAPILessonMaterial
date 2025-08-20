using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using SchoolAPI.DTOs;
using SchoolAPI.Models;
using SchoolAPI.Repositories;

namespace SchoolAPI.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repo;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<StudentReadDto>> GetAllAsync(CancellationToken ct = default)
        {
            var students = await _repo.GetAllAsync(ct);
            return _mapper.Map<List<StudentReadDto>>(students);
        }

        public async Task<StudentReadDto?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var student = await _repo.GetByIdAsync(id, ct);
            return student is null ? null : _mapper.Map<StudentReadDto>(student);
        }
        public async Task<int> CreateAsync(StudentCreateDto dto, CancellationToken ct = default)
        {
            var studentToCreate = _mapper.Map<Student>(dto);

            await _repo.AddAsync(studentToCreate, ct);
            await _repo.SaveChangesAsync(ct);
            return studentToCreate.Id;
        }

        public async Task<bool> UpdateAsync(int id, StudentUpdateDto dto, CancellationToken ct = default)
        {
            var studentToUpdate = await _repo.GetByIdAsync(id, ct);
            if (studentToUpdate is null)
            {
                return false;
            }

            _mapper.Map(dto, studentToUpdate);

            await _repo.UpdateAsync(studentToUpdate, ct);
            return await _repo.SaveChangesAsync(ct);
        }

        public async Task<bool> PatchAsync(int id, JsonPatchDocument<Student> patchDoc, CancellationToken ct = default)
        {
            var studentToPatch = await _repo.GetByIdAsync(id, ct);
            if (studentToPatch is null)
            {
                return false;
            }

            patchDoc.ApplyTo(studentToPatch);

            await _repo.UpdateAsync(studentToPatch, ct);
            return await _repo.SaveChangesAsync(ct);
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
        {
            var studentToDelete = await _repo.GetByIdAsync(id, ct);
            if (studentToDelete is null)
            {
                return false;
            }

            await _repo.DeleteAsync(studentToDelete, ct);
            return await _repo.SaveChangesAsync(ct);
        }


        //private static StudentReadDto ToReadDto(Student s) => new()
        //{
        //    Id = s.Id,
        //    FullName = $"{s.FirstName} {s.LastName}",
        //    Email = s.Email,
        //    BirthDate = s.BirthDate
        //};
    }
}
