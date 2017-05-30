using Apps.engine.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.engine.KinectRecognition
{
    public class DataTrainingResolver<InputDataType, OutputDataType>
    {
        public static IDataTraining<InputDataType, OutputDataType> ResolveDataTraining(DataTrainingType patternType)
        {
            switch (patternType)
            {
                case DataTrainingType.DataTrainingFile:
                    return new DataTrainingFile<InputDataType, OutputDataType>();
                default:
                    throw new ArgumentException("Not DataTrainingType Found");
            }
        }
    }
}
