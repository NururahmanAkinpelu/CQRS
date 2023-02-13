
using Application.Services.User.Command.Register;
using Application.Services.User.Queries.Delete;
using Application.Services.User.Queries.GetAll;
using Application.Services.User.Queries.GetUser;
using Application.Services.User.Queries.Update;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator =  mediator;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(RegisterUserRequest request)
        {
            var result =  await _mediator.Send(new RegisterUserRequest
            {
                FirsName = request.FirsName,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password
            });
            return result.Status ? Ok(result) : BadRequest(result);
        }

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetUser([FromRoute]int id)
        {
            var result = await _mediator.Send(new GetUserRequest { Id = id });
            return result.Status ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllUsersRequest());
            return result.Status ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _mediator.Send(new DeleteUserRequest { Id = id });
            return result.Success ? Ok(result) : BadRequest(result);
        }


/*        [HttpPut("Id")]
        public async Task<IActionResult> UpdateUser([FromRoute]int id, UpdateUserRequest request)
        {
            var result = await _mediator.Send(new UpdateUserRequest { })
        }*/
    }
}
