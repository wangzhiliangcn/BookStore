using Microsoft.AspNetCore.Mvc;

namespace BookStore.Web.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseApiController : Controller
    {
    }
}
