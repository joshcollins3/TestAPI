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

        [HttpPost("update")]
        public async Task<ActionResult> UpdateMenu()
        {
            var updated = await services.MenuService.Update();
            
          return Ok(updated);
            }

    }
}
