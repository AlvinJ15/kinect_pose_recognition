using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        [Route("validar/{id}")]
        public string Get(string id)
        {
            int numberFrames = 0;
            int correctFrame = 0;
            Stopwatch s = new Stopwatch();
            s.Start();
            while (s.Elapsed < TimeSpan.FromSeconds(1))
            {
                numberFrames++;
                if (id.Equals(KinectController.postureRecognition.Predict(KinectController.CurrentSkeleton), StringComparison.CurrentCultureIgnoreCase))
                {
                    correctFrame++;
                }
            }
            s.Stop();

            ResponseResult result = new ResponseResult();

            result.Result = (correctFrame / (double)numberFrames) >= 0.5;



            return result.Result.ToString();
        }
    }
}