using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Todo.Core;
using Todo.DataAccess;
using Todo.Entities;

namespace Todo.Controllers
{
    [Route("api/WeeklyTodo")]
    [ApiController]
    public class WeeklyTodosController : BaseController<WeeklyTodo>
    {
        public WeeklyTodosController(DatabaseContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
