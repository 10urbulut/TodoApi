

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Todo.Business.Abstract;
using Todo.Core.Utilities.Results.DataResult;
using Todo.Entities;
using IResult = Todo.Core.Utilities.Results.IResult;

namespace Todo.Controllers
{
    [Route("api/WeeklyTodo")]
    [ApiController]
    [Authorize]
    public class WeeklyTodosController : ControllerBase
    {
        IWeeklyTodoService _weeklyTodoService;

        public WeeklyTodosController(IWeeklyTodoService weeklyTodoService)
        {
            _weeklyTodoService = weeklyTodoService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            IDataResult<List<WeeklyTodo>> result = _weeklyTodoService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            IDataResult<WeeklyTodo> result = _weeklyTodoService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpPost("Add")]
        public IActionResult Add(WeeklyTodo weeklyTodo)
        {
            IResult result = _weeklyTodoService.Add(weeklyTodo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("Update")]
        public IActionResult Update(WeeklyTodo weeklyTodo)
        {
            IResult result = _weeklyTodoService.Update(weeklyTodo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("Delete")]
        public IActionResult Delete(WeeklyTodo weeklyTodo)
        {
            IResult result = _weeklyTodoService.Delete(weeklyTodo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
