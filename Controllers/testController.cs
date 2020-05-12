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
          services.MenuService service = new services.MenuService();

            var updated = await service.Update();
            
          return Ok(updated);
            }

    }
}
