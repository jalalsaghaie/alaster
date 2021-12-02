using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Activities;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {


        [HttpGet("GetActivities")]
        public async Task<ActionResult<List<Activity>>> GetActivities(CancellationToken cancellationToken)
        {
            return await Mediator.Send(new List.Query(),cancellationToken);
        }

        [HttpGet("GetActivity/{id}")]
        public async Task<ActionResult<Activity>> GetActivity(int id)
        {
            return await Mediator.Send(new Details.Query{Id = id});
        }

        [HttpPost("AddActivity")]
        public async Task<IActionResult> AddActivity([FromBody] Activity activity)
        {
            return Ok(await Mediator.Send(new Create.Command{Activity = activity}));
        }

        [HttpPut("EditActivity/{id}")]
        public async Task<IActionResult> EditActivity(int id ,  Activity activity)
        {
            activity.Id = id;
            return Ok(await Mediator.Send(new Edit.Command{Activity = activity}));
        }

        [HttpDelete("DeleteActivity/{id}")]
        public async Task<IActionResult> DeleteActivity(int id)
        {
            return Ok(await Mediator.Send(new Delete.Command{Id = id}));
        }

    }
}