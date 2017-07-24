using Apps.engine.KinectRecognition;
using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.App_Data
{
    public class KinectController : Controller
    {
        public static PostureRecognition<Skeleton, string> postureRecognition;

        public static KinectSensor sensor;

        public static Skeleton skel;
        // GET: Kinect
        public ActionResult Index()
        {
            return View();
        }

        public static Skeleton CurrentSkeleton
        {
            get
            {
                return skel;
            }
            set { skel = value; }
        }
    }
}