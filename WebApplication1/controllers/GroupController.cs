using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using userApp.models;

namespace UserAPP.APi.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {

        [HttpGet]
        public ActionResult<GroupModel> Groups()
        {
            return new GroupModel() { groupId = 1, groupName = "Cantanrte"};
        }
    }
}
