using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApplication1.App_Data;
//using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    [RoutePrefix("api/posture")]
    public class PostureController : ApiController
    {
        // GET api/posture/5
        [Route("validar/{ejercicio}")]
        public string Get(string ejercicio)
        {
            int numberFrames = 0;
            int correctFrame = 0;
            Stopwatch s = new Stopwatch();
            s.Start();
            while (s.Elapsed < TimeSpan.FromSeconds(10))
            {
                numberFrames++;
                var result = KinectController.postureRecognition.Predict(KinectController.CurrentSkeleton);
                
                if (ejercicio.Equals(result, StringComparison.OrdinalIgnoreCase))
                {
                    correctFrame++;
                }
            }
            s.Stop();

            //ResponseResult result = new ResponseResult();

            //result.Result = (correctFrame / (double)numberFrames) >= 0.5;

            //return ((correctFrame / (double)numberFrames) >= 0.5)?"True":"False";
            return (correctFrame>0) ? "True" : "False";

            //return result.ToJSON();
        }
    }
}