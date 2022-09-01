﻿using Microsoft.AspNetCore.Http;
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
            return new GroupModel() { groupId = 1, groupName = "Cantantes"};
        }

        [HttpGet("{groupId}")]
        public ActionResult<GroupModel> group([FromRoute] int groupId)
        {
            return new GroupModel() {groupId = 3, groupName = "streamers"};
        }

         // POST USER

        [HttpPost]
        public ActionResult CreateUser([FromBody] GroupModel group)
        {
            return Ok();
        }

        // PUT USER

        [HttpPut("id")]
        public ActionResult UpdateUser([FromRoute]int id,[FromBody] GroupModel group)
        {
            if (id == -1)
                return NoContent();
            return Ok();
        }
        // DELETE USER
        [HttpDelete("id")]
        public ActionResult deleteUser([FromRoute] int id)
        {
            return Ok();
        }

      /*  [HttpPatch("{id}/[Action]", Name = "Activate")]
        public ActionResult Activate([FromRoute] int id)
        {
            return Ok();
        }


        [HttpPatch("{id}/[Action]", Name = "Inactivate")]
        public ActionResult Inactivate([FromRoute] int id)
        {
            return Ok();
        }*/
    }
}
