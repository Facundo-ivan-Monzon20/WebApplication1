using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using userApp.models;
using userApp.services;

namespace UserAPP.APi.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly UserServices _userServices;

        // GET USER
        public UserController(UserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet("{userId}")]
        public ActionResult<UserModel> GetUser([FromRoute] int userId)
        {
            return new UserModel() { userId = 1, UserName = "Facundo Monzon", DNI = "43126971", Email = "fmivan02@gmail.com"};
        }
        // GET USERS

        [HttpGet]
        public ActionResult<List<UserModel>> GetUsers()
        {
            var _response = _userServices.GetUsers(); 
            
            return _response;

        }

        // POST USER

        [HttpPost]
        public ActionResult CreateUser([FromBody] UserModel user)
        {
            //llamar a servicios
            var _response = _userServices.CreateUser(user);

            if (_response.Succes) return Ok();
            
            return BadRequest(_response.Errors);
        }

        // PUT USER

        [HttpPut("{id}")]
        public ActionResult UpdateUser([FromRoute]int id,[FromBody] UserModel user)
        {
            if (id == -1)
                return NoContent();
            return Ok();
        }
        // DELETE USER
        [HttpDelete("{id}")]
        public ActionResult deleteUser([FromRoute] int id)
        {
            return Ok();
        }

        [HttpPatch("{id}/[Action]")]
        public ActionResult Active([FromRoute] int id)
        {
            return Ok();
        }


        [HttpPatch("{id}/[Action]")]
        public ActionResult Inactive([FromRoute] int id)
        {
            return Ok();
        }
    }
}
