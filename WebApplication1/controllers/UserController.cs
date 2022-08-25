using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using userApp.models;

namespace UserAPP.APi.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET USER
        [HttpGet]
        public UserModel GetUser(int userId)
        {
            return new UserModel() { userId = 1, UserName = "Facundo Monzon", DNI = "43126971", Email = "fmivan02@gmail.com"};
        }
        // GET USERS

        // POST USER

        // PUT USER

        // DELETE USER


    }
}
