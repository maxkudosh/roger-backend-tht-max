using Microsoft.AspNetCore.Mvc;

namespace Backend.API.Controllers
{
    /// <summary>
    /// TODO: implement logic for both reading/writing expenses
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Test()
        {
            return "I am alive!";
        }
    }
}
