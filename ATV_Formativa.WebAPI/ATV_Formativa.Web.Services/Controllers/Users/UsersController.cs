using ATV_Formativa.Web.API.Interfaces.NovaPasta;
using ATV_Formativa.Web.API.Models;
using ATV_Formativa.Web.API.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ATV_Formativa.Web.API.Controllers.Users
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        public UsersController(IUsersService users) { _usersService = users; }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(IFilter filter)
        {
            Response response = await _usersService.GetAll(filter);
            return StatusCode(response.Code,response);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Models.Users.Users record)
        {
            Response response = await _usersService.Create(record);
            return StatusCode(response.Code,response);
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            IDelete delete = new Models.Users.Users.Delete()
            {
                Id = id
            };
            Response response = await _usersService.Delete(delete);
            return StatusCode(response.Code,response);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(Models.Users.Users record)
        {
            Response response = await _usersService.Update(record);
            return StatusCode(response.Code,response);
        }
    }
}
