using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarketDataAnalysisWebAPI_SAAS.Controllers
{
    //may have thounds of request, each request requires a thread from thread pool.
    //and it requires unnessary threads to run the request which slow down the performance.
    //affect performance of the server and potentially decerase UX
    //avoid running background threads on the server side rather run oprations synchrononously on the server side
    [Route("api/[controller]")]
    [ApiController]
    public class StockMarketDataAnalysisController : ControllerBase
    {
    }
}
