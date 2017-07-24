using Apps.engine.KinectRecognition;
using Apps.engine.neuron.Utilities;
using ConnectToSQLServer;
using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebApplication1.App_Data;

namespace WebApplication1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            NameOfMethodToCall();

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }

        private static void NameOfMethodToCall()
        {
            foreach (var potentialSensor in KinectSensor.KinectSensors)
            {
                if (potentialSensor.Status == KinectStatus.Connected)
                {
                    KinectController.sensor = potentialSensor;
                    break;
                }
            }

            if (null != KinectController.sensor)
            {
                TransformSmoothParameters smoothingParam = new TransformSmoothParameters();

                //smoothingParam.Smoothing = 0.7f;
                //smoothingParam.Correction = 0.3f;
                //smoothingParam.Prediction = 1.0f;
                //smoothingParam.JitterRadius = 1.0f;
                //smoothingParam.MaxDeviationRadius = 1.0f;
                //// Turn on the skeleton stream to receive skeleton frames
                KinectController.sensor.SkeletonStream.Enable(smoothingParam);

                // Add an event handler to be called whenever there is new color frame data
                KinectController.sensor.SkeletonFrameReady += SensorSkeletonFrameReady;

                //KinectController.postureRecognition = new PostureRecognition<Skeleton, string>(PatternType.AnglePatternElbowKnee, DataTrainingType.DataTrainingFile, 100000);
                //KinectController.postureRecognition.training();

                KinectController.postureRecognition = ReadWriteObjectFile.FromByteArray<PostureRecognition<Skeleton, string>>(Convert.FromBase64String(DbServices.GetTrainingRed("seven", "posture")));

                // Start the sensor!
                try
                {
                    KinectController.sensor.Start();
                }
                catch (IOException)
                {
                    KinectController.sensor = null;
                }
            }
            //while (true) ;
            // This will be executed on another thread
        }
        private static void SensorSkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {
            Skeleton[] skeletons = new Skeleton[0];

            using (SkeletonFrame skeletonFrame = e.OpenSkeletonFrame())
            {
                if (skeletonFrame != null)
                {
                    skeletons = new Skeleton[skeletonFrame.SkeletonArrayLength];
                    skeletonFrame.CopySkeletonDataTo(skeletons);
                }
            }


            if (skeletons.Length != 0)
            {
                foreach (Skeleton skel in skeletons)
                {
                    KinectController.CurrentSkeleton = skel;
                }
            }

            // prevent drawing outside of our render area
        }
    }

}
