using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.engine.neuron.Utilities
{
    public class Vector
    {
        private double _x;

        private double _y;

        private double _z;

        public Vector(double x, double y,double z)
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

        public static double GetAngle(Vector v1, Vector v2)
        {
            var v1mag = Math.Sqrt(v1.X * v1.X + v1.Y * v1.Y + v1.Z * v1.Z);
            var  v1norm = new Vector( v1.X / v1mag, v1.Y / v1mag, v1.Z / v1mag);

            var v2mag = Math.Sqrt(v2.X * v2.X + v2.Y * v2.Y + v2.Z * v2.Z);
            var v2norm = new Vector(v2.X / v2mag, v2.Y / v2mag, v2.Z / v2mag);

            var res = v1norm.X * v2norm.X + v1norm.Y * v2norm.Y + v1norm.Z * v2norm.Z;

            return Math.Acos(res);
        }
    }


}
