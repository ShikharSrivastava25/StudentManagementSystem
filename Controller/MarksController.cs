using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Commands;
using StudentManagementSystem.DTO;
using StudentManagementSystem.Query;

namespace StudentManagementSystem.Controller {
    [Route("api/[controller]")]
    [ApiController]
    public class MarksController(IMediator mediator) : ControllerBase {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetMarks(int studentId) {
            var result = await _mediator.Send(new GetMarksByStudentIdQuery(studentId));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddMark(int studentId, CreateMarkDto dto) {
            var result = await _mediator.Send(new CreateMarkCommand(studentId, dto));
            return Ok(result);
        }

        [HttpPut("{markId}")]
        public async Task<IActionResult> UpdateMark(int markId, UpdateMarkDto dto) {
            var result = await _mediator.Send(new UpdateMarkCommand(markId, dto));
            return Ok(result);
        }

        [HttpDelete("{markId}")]
        public async Task<IActionResult> DeleteMark(int markId) {
            var success = await _mediator.Send(new DeleteMarkCommand(markId));
            return success ? Ok("Deleted successfully") : NotFound();
        }
    }
}
