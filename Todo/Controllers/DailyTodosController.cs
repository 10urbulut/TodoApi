

using Microsoft.AspNetCore.Mvc;
using Todo.Business.Abstract;
using Todo.Core.Utilities.Results.DataResult;
using Todo.Entities;
using IResult = Todo.Core.Utilities.Results.IResult;

namespace Todo.Controllers
{
    [Route("api/DailyTodo")]
    [ApiController]
    public class DailyTodosController : ControllerBase
    {
        IDailyTodoService _dailyTodoService;

        public DailyTodosController(IDailyTodoService dailyTodoService)
        {
            _dailyTodoService = dailyTodoService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            IDataResult<List<DailyTodo>> result = _dailyTodoService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            IDataResult<DailyTodo> result = _dailyTodoService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpPost("Add")]
        public IActionResult Add(DailyTodo dailyTodo)
        {
            IResult result = _dailyTodoService.Add(dailyTodo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("Update")]
        public IActionResult Update(DailyTodo dailyTodo)
        {
            IResult result = _dailyTodoService.Update(dailyTodo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("Delete")]
        public IActionResult Delete(DailyTodo dailyTodo)
        {
            IResult result = _dailyTodoService.Delete(dailyTodo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
