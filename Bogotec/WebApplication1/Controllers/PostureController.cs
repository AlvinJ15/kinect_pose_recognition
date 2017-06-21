using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
//using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    [RoutePrefix("api/posture")]
    public class PostureController : ApiController
    {
        // GET api/posture/5
        [Route("validate/{id}")]
        public string Get(string id)
        {
            return "posture";
        }
    }
}