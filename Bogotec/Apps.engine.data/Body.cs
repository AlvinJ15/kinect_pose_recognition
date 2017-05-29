using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Kinect;

namespace Apps.engine.data
{
    class Body
    {
        public Skeleton skeleton;

        public Body(Skeleton skeleton)
        {
            this.skeleton = skeleton;
        }

        public Vector Head
        { 
            get => new Vector(skeleton.Joints[JointType.Head]);
        }
       /* public Vector

        HipCenter = 0,

        Spine = 1,

        ShoulderCenter = 2,


        ShoulderLeft = 4,

        ElbowLeft = 5,

        WristLeft = 6,

        HandLeft = 7,

        ShoulderRight = 8,

        ElbowRight = 9,

        WristRight = 10,

        HandRight = 11,

        HipLeft = 12,

        KneeLeft = 13,

        AnkleLeft = 14,

        FootLeft = 15,

        HipRight = 16,

        KneeRight = 17,

        AnkleRight = 18,

        FootRight = 19*/
    }
}
