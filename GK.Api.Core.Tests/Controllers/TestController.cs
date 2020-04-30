using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using GK.Api.Core;

namespace GK.Api.Core.Tests.Controllers
{
    [ApiController]
    [Route("test")]
    public class TestController : ControllerBase
    {
        [AuthorizeXApi]
        [HttpGet]
        [Route("string")]
        public string GetString()
        {
            return "here";
        }
    }
}
