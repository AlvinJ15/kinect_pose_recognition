﻿using Apps.engine.KinectRecognition;
using Apps.engine.neuron.Utilities;
using ConnectToSQLServer;
using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
            //ThreadStart kinectThread = NameOfMethodToCall;
            //Thread thread = new Thread(kinectThread);
            //thread.Start();
            NameOfMethodToCall();

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
        public static KinectSensor sensor;
        private static void NameOfMethodToCall()
        {
            foreach (var potentialSensor in KinectSensor.KinectSensors)
            {
                if (potentialSensor.Status == KinectStatus.Connected)
                {
                    sensor = potentialSensor;
                    break;
                }
            }

            if (null != sensor)
            {
                TransformSmoothParameters smoothingParam = new TransformSmoothParameters();

                smoothingParam.Smoothing = 0.7f;
                smoothingParam.Correction = 0.3f;
                smoothingParam.Prediction = 1.0f;
                smoothingParam.JitterRadius = 1.0f;
                smoothingParam.MaxDeviationRadius = 1.0f;
                // Turn on the skeleton stream to receive skeleton frames
                sensor.SkeletonStream.Enable(smoothingParam);

                // Add an event handler to be called whenever there is new color frame data
                sensor.SkeletonFrameReady += SensorSkeletonFrameReady;

                KinectController.postureRecognition = new PostureRecognition<Skeleton, string>(PatternType.AnglePatternElbowKnee, DataTrainingType.DataTrainingFile, 100000);
                KinectController.postureRecognition.training();
                //File.WriteAllBytes("save.dat", ToByteArray(KinectController.postureRecognition));
                //KinectController.postureRecognition = ReadWriteObjectFile.FromByteArray<PostureRecognition<Skeleton, string>>(Convert.FromBase64String(DbServices.GetTrainingRed("first", "static")));

                // Start the sensor!
                try
                {
                    sensor.Start();
                }
                catch (IOException)
                {
                    sensor = null;
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
        public static byte[] ToByteArray<T>(T obj)
        {
            if (obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }
    }

}
