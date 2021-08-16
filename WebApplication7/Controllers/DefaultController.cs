using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using WebApplication7.Models;

namespace WebApplication7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        private readonly IConfiguration _Icon;
        public DefaultController(IConfiguration configuration)
        {
            _Icon = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            MongoClient client = new MongoClient(_Icon.GetConnectionString("Defualt"));
            var dblist = client.GetDatabase("testdb").GetCollection<Sample>("saple").AsQueryable();
            return new JsonResult(dblist);
        }  
            
    }
}