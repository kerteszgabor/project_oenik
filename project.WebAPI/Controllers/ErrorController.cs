using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;


namespace project.WebAPI.Controllers
{
    [EnableCors("cors")]
    [Route("[controller]")]
    [ApiController]
    public class ErrorController : Controller
    {
        [Route("/error")]
        public IActionResult HandleError()
        {
            return Problem();
        }
        
    }
}
