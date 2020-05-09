using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace testAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {

        [HttpPost("UpdateMenu")]
        public ActionResult UpdateMenu()
        {
            string return = services.MenuService.UpdateMenu;
            }

    }
}
