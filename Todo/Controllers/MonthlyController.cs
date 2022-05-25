

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Todo.Business.Abstract;
using Todo.Core.Utilities.Results.DataResult;
using Todo.Entities;
using IResult = Todo.Core.Utilities.Results.IResult;

namespace Todo.Controllers
{
    [Route("api/MonthlyTodo")]
    [ApiController]
    [Authorize]
    public class MonthlyTodosController : ControllerBase
    {
        IMonthlyTodoService _monthlyTodoService;

        public MonthlyTodosController(IMonthlyTodoService monthlyTodoService)
        {
            _monthlyTodoService = monthlyTodoService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            IDataResult<List<MonthlyTodo>> result = _monthlyTodoService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            IDataResult<MonthlyTodo> result = _monthlyTodoService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpPost("Add")]
        public IActionResult Add(MonthlyTodo monthlyTodo)
        {
            IResult result = _monthlyTodoService.Add(monthlyTodo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("Update")]
        public IActionResult Update(MonthlyTodo monthlyTodo)
        {
            IResult result = _monthlyTodoService.Update(monthlyTodo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("Delete")]
        public IActionResult Delete(MonthlyTodo monthlyTodo)
        {
            IResult result = _monthlyTodoService.Delete(monthlyTodo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
