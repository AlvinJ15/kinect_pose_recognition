using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.engine.data
{
    class Vector
    {
        private double x;

        private double y;

        private double z;

        public Vector(Joint joint)
        {
            this.x = joint.Position.X;
            this.y = joint.Position.Y;
            this.z = joint.Position.Z;
        }

        public double X
        {
            get => x;
            set => x = value;
        }
        public double Y
        {
            get => y;
            set => y = value;
        }
        public double Z
        {
            get => z;
            set => z = value;
        }

    }
}
