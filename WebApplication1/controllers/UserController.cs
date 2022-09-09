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

        // GET USER
        [HttpGet("{userId}")]
        public ActionResult<UserModel> GetUser([FromRoute] int userId)
        {
            return new UserModel() { userId = 1, UserName = "Facundo Monzon", DNI = "43126971", Email = "fmivan02@gmail.com"};
        }
        // GET USERS

        [HttpGet]
        public ActionResult<List<UserModel>> GetUsers()
        {
            var result = new List<UserModel>();

            result.Add(new UserModel { userId = 1, UserName = "Facundo Monzon", DNI = "43126971", Email = "fmivan02@gmail.com" });
            result.Add(new UserModel { userId = 2, UserName = "ivan Monzon", DNI = "43126971", Email = "fmivan02@gmail.com" });

            return result;

        }

        // POST USER

        [HttpPost]
        public ActionResult CreateUser([FromBody] UserModel user)
        {
            //llamar a servicios
            var su = new UserServiceImp();

            su.CreateUser(user);
            return Ok();
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
        public ActionResult Activate([FromRoute] int id)
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
