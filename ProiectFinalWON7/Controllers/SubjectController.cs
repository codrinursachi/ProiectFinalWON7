using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectFinalWON7.DTOs;
using ProiectFinalWON7.DTOs.Extensions;
using ProiectFinalWON7.Exceptions;
using ProiectFinalWON7.Services;
using System.ComponentModel.DataAnnotations;

namespace ProiectFinalWON7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly SubjectService subjectService;
        public SubjectController(SubjectService subjectService)
        {
            this.subjectService = subjectService;
        }

        /// <summary>
        /// Creates a subject
        /// </summary>
        /// <param name="subjectToCreateDTO">Subject details</param>
        /// <returns>Created subject</returns>
        [HttpPost("add-subject")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(SubjectToGetDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public IActionResult CreateSubject([FromBody] SubjectToCreateDTO subjectToCreateDTO)
        {
            return Created(string.Empty,subjectService.CreateSubject(subjectToCreateDTO));
        }

        /// <summary>
        /// Deletes subject by id if found
        /// </summary>
        /// <param name="id">Id of subject</param>
        /// <returns></returns>
        [HttpDelete("delete-subject-by-id/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SubjectToGetDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public IActionResult DeleteSubject([Range(1,int.MaxValue)]int id)
        {
            subjectService.DeleteSubject(id);
            return Ok();
        }

        /// <summary>
        /// Updates subject by id if found
        /// </summary>
        /// <param name="id">Id of subject</param>
        /// <param name="updatedSubject">Subject updated details</param>
        /// <returns>Subject if successful</returns>
        [HttpPut("update-subject-by-id/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SubjectToGetDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public IActionResult UpdateSubject([Range(1,int.MaxValue)]int id, [FromBody] SubjectToCreateDTO updatedSubject)
        {
            return Ok(subjectService.UpdateSubject(id, updatedSubject));
        }
    }
}
