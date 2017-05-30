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
        public static INeuralNetworkPattern<InputDataType, OutputDataType> ResolvePattern(PatternType patternType, DataTrainingType dataTrainigType)
        {
            var dataTrainingT = DataTrainingResolver<InputDataType, OutputDataType>.ResolveDataTraining(dataTrainigType);
            NeuralNetworkPatternBase<InputDataType, OutputDataType> neuralNetworkPattern;
            switch (patternType)
            {
                case PatternType.AnglePatternAll:
                    neuralNetworkPattern = new AnglePatternAll<InputDataType, OutputDataType>();
                    break;
                case PatternType.AnglePatternElbowKnee:
                    neuralNetworkPattern=  new AnglePatternElbowKnee<InputDataType, OutputDataType>();
                    break;
                default:
                    throw new ArgumentException("Not Pattern Found");
            }
            neuralNetworkPattern.DataTrainingResolver = dataTrainingT;

            return neuralNetworkPattern;
        }
    }
}
