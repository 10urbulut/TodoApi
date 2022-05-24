using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todo.Core;
using Todo.DataAccess;
using Todo.Entities;

namespace Todo.Controllers
{
    [Route("api/MonthlyTodo")]
    [ApiController]
    public class MonthlyController : BaseController<MonthlyTodo>
    {
        public MonthlyController(DatabaseContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
