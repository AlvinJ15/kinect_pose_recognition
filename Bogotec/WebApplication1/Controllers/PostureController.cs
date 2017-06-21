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
        [Route("validate/{ejercicio}")]
        public string Get(string ejercicio)
        {
            int numberFrames = 0;
            int correctFrame = 0;
            Stopwatch s = new Stopwatch();
            s.Start();
            while (s.Elapsed < TimeSpan.FromSeconds(1000))
            {
                numberFrames++;
                if (KinectController.postureRecognition.Predict(KinectController.CurrentSkeleton).Equals(ejercicio))
                {
                    correctFrame++;
                }
            }
            s.Stop();

            ResponseResult result = new ResponseResult();

            result.Result = (correctFrame / (double)numberFrames) >= 0.5;



            return result.ToJSON();
        }
    }
}