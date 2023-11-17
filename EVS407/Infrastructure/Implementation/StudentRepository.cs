using DomainModels;
using Infrastructure.Interface;
using Infrastructure.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Implementation
{
    public class StudentRepository : IStudentRepository
    {
        private IGenericRepository _genericRepository;
        private Evs407Context _context;
        private ISetupRepository _setupRepository;

        public StudentRepository(IGenericRepository genericRepository, Evs407Context context, ISetupRepository setupRepository)
        {
            _genericRepository = genericRepository;
            _context = context;
            _setupRepository = setupRepository;
        }
        public async Task<StudentUpdateVM> StudentGetById(int Id)
        {
            var student = await _context.Students.Where(p => p.Id == Id).FirstOrDefaultAsync();
            if (student != null)
            {
                return new StudentUpdateVM()
                {
                    Id = student.Id,
                    Department = student.Department,
                    GenderId = student.GenderId,
                    PhoneNumber = student.PhoneNumber,
                    RoleNumber = student.RoleNumber,
                    StudentName = student.StudentName,
                    Genders = await _setupRepository.GenderGetAll()
                };
            }
            return null;
        }
        public async Task<bool> StudentUpdate(StudentUpdateVM model)
        {
            var student = await _context.Students.Where(p => p.Id == model.Id).FirstOrDefaultAsync();
            if(student != null)
            {
                student.PhoneNumber = model.PhoneNumber;
                student.RoleNumber = model.RoleNumber;
                student.StudentName = model.StudentName;
                student.Department = model.Department;
                student.GenderId = model.GenderId;
                return await _genericRepository.Update(student);
            }
            return false;
        }
        public async Task<bool> StudentCreate(StudentCreateVM model)
        {
            return await _genericRepository.Create(new Student()
            {
                Department = model.Department,
                GenderId = model.GenderId,
                PhoneNumber = model.PhoneNumber,
                RoleNumber = model.RoleNumber,
                StudentName = model.StudentName,
            });
        }
        public async Task<IEnumerable<StudentVM>> StudentGetAll()
        {
            var resultVM = new List<StudentVM>();
            var Students = await _context.Students.Include(p => p.Gender).OrderByDescending(p => p.Id).ToListAsync();
            if (Students != null && Students.Count > 0)
            {
                foreach (var item in Students)
                {
                    resultVM.Add(new StudentVM()
                    {
                        Department = item.Department,
                        Gender = item.Gender.GenderName,
                        PhoneNumber = item.PhoneNumber,
                        RoleNumber = item.RoleNumber,
                        StudentName = item.StudentName,
                        Id = item.Id
                    });
                }
                return resultVM;
            }
            return resultVM;
        }
        public async Task<bool> StudentDelete(int Id)
        {
            var student = await _context.Students.Where(p => p.Id == Id).FirstOrDefaultAsync();
            if (student != null)
            {
                return await _genericRepository.Delete(student);
            }
            return false;
        }
    }
}
