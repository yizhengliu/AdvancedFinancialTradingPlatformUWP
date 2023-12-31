using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarketDataAnalysisWebAPI_SAAS.Controllers
{
    //may have thounds of request, each request requires a thread from thread pool
    [Route("api/[controller]")]
    [ApiController]
    public class StockMarketDataAnalysisController : ControllerBase
    {
    }
}
