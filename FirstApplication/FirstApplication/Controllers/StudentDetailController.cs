using FirstApplication.Models;
using FirstApplication.repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;

namespace FirstApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentDetailController : ControllerBase
    {
        private readonly IStudent _student;
        public StudentDetailController(IStudent student)
        {
            _student = student;
        }

        [HttpGet]
        public async Task<IEnumerable<StudentDetail>> Get()
        {
            var data = await _student.GetAsync();
            return data;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDetail>> Details(int id)
        {
            var data = await _student.DetailAsync(id);
            return data;
        }
        [HttpPost]
        public async Task<ActionResult<StudentDetail>> Create(StudentDetail studentDetail)
        {
            if(studentDetail == null)
            {
                return BadRequest("Student detail cannot be null.");
            }
            var data = await _student.CreateAsync(studentDetail);
            return CreatedAtAction(nameof(Details), new { id = data.Id }, data);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<StudentDetail>> Delete(int id)
        {
            var data = await _student.DeleteAsync(id);
                        if (data == null)
            {
                return NotFound($"Student detail with ID {id} not found.");
            }
            return Ok(data);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<StudentDetail>> Update(int id, StudentDetail studentDetail)
        {
            if(studentDetail == null || id != studentDetail.Id)
            {
                return BadRequest("Invalid student detail or ID mismatch.");
            }
            else
            {
                var data = await _student.UpdateAsync(id, studentDetail);
                if(data == null)
                {
                    return NotFound($"Student detail with ID {id} not found.");
                }
                else
                {
                    return Ok(data);
                }
            }
        }
    }
}
