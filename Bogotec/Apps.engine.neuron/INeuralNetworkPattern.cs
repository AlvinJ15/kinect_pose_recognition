using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.engine.neuron
{
    public interface INeuralNetworkPattern<InputDataType, OutputDataType>
    {

        void enterTrainingRecord(InputDataType InputData, OutputDataType outputData);

        void processData();

        double[][] getInputDataProcessed();

        double[][] getOutputDataProcessed();


    }
}
