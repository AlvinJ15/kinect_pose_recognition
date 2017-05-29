using Apps.engine.neuron;
using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.engine.KinectRecognition
{
    public class PatternResolver<InputDataType, OutputDataType>
        where   InputDataType: Skeleton
    {
        public static INeuralNetworkPattern<InputDataType, OutputDataType> ResolvePattern(PatternType patternType)
        {
            switch (patternType)
            {
                case PatternType.AnglePatternAll:
                    return new AnglePatternAll<InputDataType, OutputDataType>();
                case PatternType.AnglePatternElbowKnee:
                    return new AnglePatternElbowKnee<InputDataType, OutputDataType>();
                default:
                    throw new ArgumentException("Not Pattern Found");
            }
        }
    }
}
