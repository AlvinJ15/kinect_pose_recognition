using Apps.engine.neuron.Utilities;
using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.engine.neuron
{
    public class AnglePatternAll<InputDataType, OutputDataType> : AnglePatternBase<InputDataType, OutputDataType>
        where InputDataType : Skeleton
    {
        public override List<double> GetAngle(Skeleton skeleton)
        {
            List<double> lista = new List<double>();

            for (int i = 0; i < 20; i++)
            {
                for (int j = i + 1; j < 20; j++)
                {
                    for (int h = j + 1; h < 20; h++)
                    {
                        var A = new Point(skeleton.Joints[a[i]].Position.X, skeleton.Joints[a[i]].Position.Y, skeleton.Joints[a[i]].Position.Z);
                        var B = new Point(skeleton.Joints[a[j]].Position.X, skeleton.Joints[a[j]].Position.Y, skeleton.Joints[a[j]].Position.Z);
                        var C = new Point(skeleton.Joints[a[h]].Position.X, skeleton.Joints[a[h]].Position.Y, skeleton.Joints[a[h]].Position.Z);
                        lista.Add(Point.GetAngle(A, B, C)/(Math.PI));
                    }
                }
            }

            return lista;
        }
    }
}
