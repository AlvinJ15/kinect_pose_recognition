﻿using AForge.Neuro;
using AForge.Neuro.Learning;
using Apps.engine.KinectRecognition;
using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Bogotec
{
    public class Program
    {
        public static void Main(string[] args)
        {


            PostureRecognition<Skeleton, string> postureRecognition = new PostureRecognition<Skeleton, string>(PatternType.AnglePatternElbowKnee, 100000);


            /*************************************************************************************************************/
            /*TODO: NEED CREATE INTERFACES FOR HANDLE THIS*/
            //FileStream fs = new FileStream("Test.txt", FileMode.Create);
            //// First, save the standard output.
            //TextWriter tmp = Console.Out;
            //StreamWriter sw = new StreamWriter(fs);
            //Console.SetOut(sw);
            //var lista = FromByteArray<List<Skeleton>>(File.ReadAllBytes("TRAINING_DATA/parado"));
            //Enter(postureRecognition, lista, "PARADO");

            //lista = FromByteArray<List<Skeleton>>(File.ReadAllBytes("TRAINING_DATA/jeysonmanosabiertas"));
            //Enter(postureRecognition, lista, "MANOS ABIERTAS");
            //lista = FromByteArray<List<Skeleton>>(File.ReadAllBytes("TRAINING_DATA/johanmanosabiertas"));
            //Enter(postureRecognition, lista, "MANOS ABIERTAS");

            //lista = FromByteArray<List<Skeleton>>(File.ReadAllBytes("TRAINING_DATA/jeysonsentadilla"));
            //lista = FromByteArray<List<Skeleton>>(File.ReadAllBytes("TRAINING_DATA/johansentadillas"));
            //Enter(postureRecognition, lista, "SENTADILLA");

            //Console.WriteLine("ITERACION : "+postureRecognition.training()+"-------------------------------------------------------\n");
            //Console.WriteLine("VIDEO1 " + "-------------------------------------------------------");

            //lista = FromByteArray<List<Skeleton>>(File.ReadAllBytes("TRAINING_DATA/video"));
            //foreach(Skeleton skel in lista)
            //{
            //    var x = postureRecognition.Predict(skel);
            //    if(x!= null && x.Length > 0)
            //        Console.WriteLine(x);
            //}
            //Console.WriteLine("VIDEO2 " + "-------------------------------------------------------");

            //lista = FromByteArray<List<Skeleton>>(File.ReadAllBytes("TRAINING_DATA/video2"));
            //foreach (Skeleton skel in lista)
            //{
            //    var x = postureRecognition.Predict(skel);
            //    if (x != null && x.Length > 0)
            //        Console.WriteLine(x);
            //    else
            //    {
            //        Console.WriteLine("NO RECONOCIDO");
            //    }
            //}
            //Console.SetOut(tmp);
            //sw.Close();
        }
        public static void Enter(PostureRecognition<Skeleton, string> postureRecognition,List<Skeleton> lista, string output)
        {
            foreach(Skeleton skel in lista)
            {
                postureRecognition.enterPosture(skel, output);
            }
        }

        public static T FromByteArray<T>(byte[] data)
        {
            if (data == null)
                return default(T);
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream(data))
            {
                object obj = bf.Deserialize(ms);
                return (T)obj;
            }
        }


    }
}
