using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todo.Core;
using Todo.DataAccess;
using Todo.Entities;

namespace Todo.Controllers
{
    [Route("api/DailyTodo")]
    [ApiController]
    public class DailyTodosController : BaseController<DailyTodo>
    {
        public DailyTodosController(DatabaseContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
