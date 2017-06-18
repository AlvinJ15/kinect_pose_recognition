using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Kinect;
namespace Apps.engine.neuron
{
    [Serializable()]
    public abstract class AnglePatternBase<InputDataType, OutputDataType> : NeuralNetworkPatternBase<InputDataType, OutputDataType>
       where InputDataType:Skeleton
    {
        public override double[] processInputDataRecord(InputDataType input)
        {
           var anglesBody = GetAngle((Skeleton)input);
           return  anglesBody.ToArray();
        }

        public abstract List<double> GetAngle(Skeleton skeleton);

        public void processData()
        {
            throw new NotImplementedException();
        }
    }
}
