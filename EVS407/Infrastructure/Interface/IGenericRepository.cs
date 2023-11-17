using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interface
{
    public interface IGenericRepository
    {
        Task<bool> Create(object entity);
        Task<bool> Update(object entity);
        Task<bool> Delete(object entity);
    }
}
