using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.engine.neuron.Utilities
{
    public class Point
    {
        private double _x;
        private double _y;
        private double _z;

        public Point(double x,double y,double z)
        {
            _x = x;
            _y = y;
            _z = z;
        }
        public double X
        {
            get
            {
                return _x;
            }
            set => _x = value;
        }

        public double Y
        {
            get
            {
                return _y;
            }
            set => _y = value;
        }

        public double Z
        {
            get
            {
                return _z;
            }
            set => _z = value;
        }

        public static Vector CreateVector(Point A, Point B)
        {
            return new Vector(A.X - B.X, A.Y - B.Y, A.Z - B.Z);
        }

        public static double GetAngle(Point A, Point B, Point C)
        {
            return Vector.GetAngle(CreateVector(A, B), CreateVector(B, C));
        }
    }


}
