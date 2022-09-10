using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using userApp.models;
using userApp.services;


namespace UserAPP.APi.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly GroupServices _groupServices;

        public GroupController(GroupServices groupServices)
        {
            _groupServices = groupServices;
        }

        [HttpGet]
        public ActionResult<GroupModel> Groups()
        {
            return new GroupModel() { groupId = 1, groupName = "Cantantes"};
        }

        [HttpGet("{groupId}")]
        public ActionResult<GroupModel> Group([FromRoute] int groupId)
        {
            return _groupServices.GetGroup(groupId);
        }

         // POST USER

        [HttpPost]
        public ActionResult CreateGroup([FromBody] GroupModel groupModel)
        {
            
            _groupServices.CreateGroup(groupModel);
            return Ok();
        }

        // PUT USER

        [HttpPut("id")]
        public ActionResult UpdateGroup([FromRoute]int id,[FromBody] GroupModel groupModel)
        {
            if (id == -1)
                return NoContent();
            return Ok();
        }
 
        [HttpDelete("id")]
        public ActionResult deleteGroup([FromRoute] int id)
        {
            return Ok();
        }

        [HttpPatch("{idGroup}/[Action]")]
        public ActionResult Active([FromRoute] int idGroup)
        {
            return Ok();
        }


        [HttpPatch("{idGroup}/[Action]")]
        public ActionResult Inactive([FromRoute] int idGroup)
        {
            return Ok();
        }
    }
}
