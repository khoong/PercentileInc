using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PercentileController : ControllerBase
    {
        // GET: api/Percentile
        [HttpGet]
        public IEnumerable<double> GetPercentileData()
        {
            return Percentile.GetData();
        }
    }
}