using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApplication1.App_Data;

namespace WebApplication1.Controllers
{
    [RoutePrefix("api/posture")]
    public class RutinesController : ApiController
    {
        [Route("rutinas/{id}")]
        public string Get(int id)
        {
            var postures =  new string[] { "cuelloIzquierdo", "cuelloDerecho" ,"brazoIzquierdo","brazoDerecho","rana","sentadilla"};
            ResponseResult result = new ResponseResult();
            result.Result = String.Join(";", postures);

            return result.ToJSON();
        }
    }
}