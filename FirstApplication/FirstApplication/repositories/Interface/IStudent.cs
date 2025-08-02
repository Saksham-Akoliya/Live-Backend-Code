using FirstApplication.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace FirstApplication.repositories.Interface
{
    public interface IStudent
    {
        Task<IEnumerable<StudentDetail>> GetAsync();
        Task<StudentDetail> DetailAsync(int id);
        Task<StudentDetail> CreateAsync(StudentDetail studentDetail);
        Task<StudentDetail> UpdateAsync(int id, StudentDetail studentDetail);
        Task<StudentDetail> DeleteAsync(int id);
    }
}
