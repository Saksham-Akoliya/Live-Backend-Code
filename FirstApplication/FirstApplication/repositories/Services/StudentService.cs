using FirstApplication.Data;
using FirstApplication.Models;
using FirstApplication.repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace FirstApplication.repositories.Services
{
    public class StudentService : IStudent
    {
        private readonly AppDbContext _context;
        public StudentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StudentDetail>> GetAsync()
        {
            try
            {
                var data = await _context.StudentDetailTable.ToListAsync();
                if (data == null || !data.Any())
                {
                    throw new Exception("No student details found.");
                }
                else
                {
                    return data;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving student details.", ex);
            }
        }

        public async Task<StudentDetail> DetailAsync(int id)
        {
            try
            {
                var data = await _context.StudentDetailTable.FindAsync(id);
                if (data == null)
                {
                    throw new Exception($"Student detail with ID {id} not found.");
                }
                else
                {
                    return data;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving student detail for ID {id}.", ex);
            }
        }

        public async Task<StudentDetail> CreateAsync(StudentDetail student)
        {
            try
            {
                await _context.StudentDetailTable.AddAsync(student);
                await _context.SaveChangesAsync();
                return student;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating student detail.", ex);
            }
        }

        public async Task<StudentDetail> DeleteAsync(int id)
        {
            try
            {
                var data = await _context.StudentDetailTable.FindAsync(id);
                if(data == null)
                {
                    throw new Exception($"Student detail with ID {id} not found.");
                }
                else
                {
                    _context.StudentDetailTable.Remove(data);
                    await _context.SaveChangesAsync();
                    return data;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while deleting student detail for ID {id}.", ex);
            }
        }

        public async Task<StudentDetail> UpdateAsync(int id , StudentDetail studentDetail)
        {
            try
            {
              if(id != studentDetail.Id)
              {
                  throw new ArgumentException("ID mismatch.");
              }
              if(studentDetail == null)
              {
                  throw new ArgumentNullException(nameof(studentDetail), "Student detail cannot be null.");
              }
                var data = await _context.StudentDetailTable.FindAsync(id);
                if (data == null)
                {
                    throw new Exception($"Student detail with ID {id} not found.");
                }
                else
                {
                    data.Age = studentDetail.Age;
                    data.FirstName = studentDetail.FirstName;
                    data.LastName = studentDetail.LastName;
                    data.UserName = studentDetail.UserName;
                    data.Password = studentDetail.Password;
                    _context.StudentDetailTable.Update(data);
                    await _context.SaveChangesAsync();
                    return data;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while updating student detail for ID {id}.", ex);
            }

        }
    }
}
