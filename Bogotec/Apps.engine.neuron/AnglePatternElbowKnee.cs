
using Apps.engine.neuron.Utilities;
using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.engine.neuron
{
    [Serializable()]
    public class AnglePatternElbowKnee<InputDataType, OutputDataType> : AnglePatternBase<InputDataType, OutputDataType>
            where InputDataType : Skeleton
    {
        public override List<double> GetAngle(Skeleton skeleton)
        {
            List<double> lista = new List<double>();
            //Console.WriteLine("*******************");
            lista.Add(calculateAngle(skeleton, JointType.ShoulderRight, JointType.ElbowRight, JointType.WristRight));
            lista.Add(calculateAngle(skeleton, JointType.ShoulderLeft, JointType.ElbowLeft, JointType.WristLeft));
            lista.Add(calculateAngle(skeleton, JointType.HipRight, JointType.KneeRight, JointType.AnkleRight));
            lista.Add(calculateAngle(skeleton, JointType.HipLeft, JointType.KneeLeft, JointType.AnkleLeft));
            lista.Add(calculateAngle(skeleton, JointType.ShoulderCenter, JointType.ShoulderRight, JointType.ElbowRight));
            lista.Add(calculateAngle(skeleton, JointType.ShoulderCenter, JointType.ShoulderLeft, JointType.ElbowLeft));

            lista.Add(calculateAngle(skeleton, JointType.ShoulderCenter, JointType.ShoulderRight, JointType.WristRight));
            lista.Add(calculateAngle(skeleton, JointType.ShoulderCenter, JointType.ShoulderLeft, JointType.WristLeft));

            lista.Add(calculateAngle(skeleton, JointType.ShoulderCenter, JointType.HipCenter, JointType.AnkleLeft));
            lista.Add(calculateAngle(skeleton, JointType.ShoulderCenter, JointType.HipCenter, JointType.AnkleRight));


            return lista;
        }

        public double calculateAngle(Skeleton skeleton, JointType i, JointType j, JointType h)
        {
            var A = new Point(skeleton.Joints[i].Position.X, skeleton.Joints[i].Position.Y, skeleton.Joints[i].Position.Z);
            var B = new Point(skeleton.Joints[j].Position.X, skeleton.Joints[j].Position.Y, skeleton.Joints[j].Position.Z);
            var C = new Point(skeleton.Joints[h].Position.X, skeleton.Joints[h].Position.Y, skeleton.Joints[h].Position.Z);
            //Console.WriteLine("ANGLE:    " +  RadianToDegree(Point.GetAngle(A, B, C)));
            //Console.WriteLine("ANGLE:    " + RadianToDegree(Point.GetAngle(A, C, B)));
            //Console.WriteLine("ANGLE:    " + RadianToDegree(Point.GetAngle(B,C, A)));
            //Console.WriteLine("ANGLE:    " + RadianToDegree(Point.GetAngle(B, A, C)));
            //Console.WriteLine("ANGLE:    " + RadianToDegree(Point.GetAngle(C, A, B)));
            //Console.WriteLine("ANGLE:    " + RadianToDegree(Point.GetAngle(C, B, A)));
            //Console.WriteLine("__________________________________________________________________________________");
            return Point.GetAngle(C, A, B) / (Math.PI);
        }

        private double RadianToDegree(double angle)
        {
            return angle * (180.0 / Math.PI);
        }
    }
}
