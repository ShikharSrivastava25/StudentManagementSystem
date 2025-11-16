using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Commands;
using StudentManagementSystem.DTO;
using StudentManagementSystem.Query;

namespace StudentManagementSystem.Controller {
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController(IMediator mediator) : ControllerBase {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> Get() {
            var result = await _mediator.Send(new GetAllStudentsQuery());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentDto dto) {
            var result = await _mediator.Send(new CreateStudentCommand(dto));
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateStudentDto dto) {
            var result = await _mediator.Send(new UpdateStudentCommand(id, dto));
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            var success = await _mediator.Send(new DeleteStudentCommand(id));
            return success ? Ok("Deleted successfully") : NotFound();
        }
    }
}
