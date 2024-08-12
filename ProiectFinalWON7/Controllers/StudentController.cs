using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectFinalWON7.DTOs;
using ProiectFinalWON7.Services;
using System.ComponentModel.DataAnnotations;

namespace ProiectFinalWON7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentService studentService;
        public StudentController(StudentService studentService)
        {
            this.studentService = studentService;
        }

        /// <summary>
        /// Gets all students if any
        /// </summary>
        /// <returns>A list of students if any found</returns>
        [HttpGet("get-all-students")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<StudentToGetDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public IActionResult GetAllStudents()
        {
            return Ok(studentService.GetAllStudents());
        }
        
        /// <summary>
        /// Returns a student if exists
        /// </summary>
        /// <param name="id">Id of student to get</param>
        /// <returns>Student if exists</returns>
        [HttpGet("get-student-by-id/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentToGetDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public IActionResult GetStudent([Range(1, int.MaxValue)] int id)
        {
            return Ok(studentService.GetStudentById(id));
        }

        /// <summary>
        /// Creates a student if valid
        /// </summary>
        /// <param name="studentToCreateDTO">Student details for creation</param>
        /// <returns>Created student if successful</returns>
        [HttpPost("create-student")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(StudentToGetDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public IActionResult CreateStudent([FromBody] StudentToCreateDTO studentToCreateDTO)
        {
            return Created(string.Empty,studentService.CreateStudent(studentToCreateDTO));
        }

        /// <summary>
        /// Updates student details to the ones provided
        /// </summary>
        /// <param name="id">Id of student to update</param>
        /// <param name="updatedStudent">Student updated details</param>
        /// <returns>Updated student if successful</returns>
        [HttpPut("update-student/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentToGetDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public IActionResult UpdateStudent([Range(1, int.MaxValue)] int id, [FromBody] StudentToCreateDTO updatedStudent)
        {
            return Ok(studentService.UpdateStudent(id, updatedStudent));
        }

        /// <summary>
        /// Gets the address of a student if it exists
        /// </summary>
        /// <param name="id">Id of student</param>
        /// <returns>Address of student if it exists</returns>
        [HttpGet("get-address-by-student-id/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AddressToGetDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public IActionResult GetAddressByStudentId([Range(1, int.MaxValue)] int id)
        {
            return Ok(studentService.GetAddressByStudentId(id));
        }

        /// <summary>
        /// Updates or creates if necessary address for student
        /// </summary>
        /// <param name="id">Id of student</param>
        /// <param name="updatedAddress">New address details</param>
        /// <returns>Updated address if valid</returns>
        [HttpPut("update-address-by-student-id/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AddressToGetDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public IActionResult UpdateAddressByStudentId([Range(1, int.MaxValue)] int id, [FromBody] AddressToCreateDTO updatedAddress)
        {
            return Ok(studentService.UpdateAddressByStudentId(id, updatedAddress));
        }

        /// <summary>
        /// Deletes address of student if it exists
        /// </summary>
        /// <param name="id">Id of student</param>
        /// <param name="deleteAddress">Should the address be deleted also</param>
        /// <returns></returns>
        [HttpDelete("delete-student-by-id/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public IActionResult DeleteStudentById([Range(1, int.MaxValue)] int id, [FromBody] bool deleteAddress = false)
        {
            studentService.DeleteStudent(id, deleteAddress);
            return Ok();
        }
    }
}
