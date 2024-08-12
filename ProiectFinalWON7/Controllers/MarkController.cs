using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectFinalWON7.DTOs;
using ProiectFinalWON7.Services;
using System.ComponentModel.DataAnnotations;

namespace ProiectFinalWON7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarkController : ControllerBase
    {
        private readonly MarkService markService;
        public MarkController(MarkService markService)
        {
            this.markService = markService;
        }

        /// <summary>
        /// Adds a mark
        /// </summary>
        /// <param name="markToCreate">Details of mark to create</param>
        /// <returns>Created mark if successful</returns>
        [HttpPost("add-mark")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(MarkToGetDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public IActionResult AddMark([FromBody] MarkToCreateDTO markToCreate)
        {
            return Created(string.Empty,markService.AddMark(markToCreate));
        }

        /// <summary>
        /// Gets all marks of student by id
        /// </summary>
        /// <param name="id">Id of student</param>
        /// <returns>All marks of given student if it exists</returns>
        [HttpGet("get-all-marks-by-student-id/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<MarkToGetDTO>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public IActionResult GetAllMarksByStudentId([Range(1, int.MaxValue)] int id)
        {
            return Ok(markService.GetAllMarksByStudentId(id));
        }

        /// <summary>
        /// Gets marks for specified student and subject
        /// </summary>
        /// <param name="studentId">Id of student</param>
        /// <param name="subjectID">Id of subject</param>
        /// <returns>All marks for specified student and subject if they exist</returns>
        [HttpGet("get-all-marks-by-student-id-and-subject-id/{studentId}/{subjectID}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<MarkToGetDTO>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public IActionResult GetAllMarksByStudentIdAndSubjectId([Range(1, int.MaxValue)] int studentId, [Range(1, int.MaxValue)] int subjectID)
        {
            return Ok(markService.GetAllMarksByStudentIdAndSubjectId(studentId, subjectID));
        }

        /// <summary>
        /// Gets average of student per subject
        /// </summary>
        /// <param name="studentId">Id of student</param>
        /// <returns>All averages per subject of student if they exist</returns>
        [HttpGet("get-student-subject-averages/{studentId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<SubjectAverageDTO>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public IActionResult GetStudentSubjectAverages([Range(1, int.MaxValue)] int studentId)
        {
            return Ok(markService.GetStudentSubjectAverages(studentId));
        }

        /// <summary>
        /// Gets student in specified order of marks averages
        /// </summary>
        /// <param name="sortDescending">Type of order</param>
        /// <returns>All students in specified order if they exist</returns>
        [HttpGet("get-students-ordered-by-average-mark")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GlobalAverageDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public IActionResult GetStudentsOrderedByAverageMark([FromQuery] bool sortDescending=true)
        {
            return Ok(markService.GetStudentsOrderedByAverageMark(sortDescending));
        }
    }
}
