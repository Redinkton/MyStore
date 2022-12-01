using Microsoft.AspNetCore.Mvc;

namespace MyStore.WebApi.Controllers
{
    [ApiController]
    [Route("api[contoller]/[action]")]
    public abstract class BaseController : ControllerBase
    {
    }
}
