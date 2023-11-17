using Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interface
{
    public interface IStudentRepository
    {
        Task<StudentUpdateVM> StudentGetById(int Id);
        Task<bool> StudentUpdate(StudentUpdateVM model);
        Task<bool> StudentCreate(StudentCreateVM model);
        Task<IEnumerable<StudentVM>> StudentGetAll();
        Task<bool> StudentDelete(int Id);
    }
}
