using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.engine.neuron
{
    public interface INeuralNetworkPattern<InputDataType, OutputDataType>
    {
        //void Initialize();

        void enterTrainingRecord(InputDataType inputRecord, OutputDataType outputRecord);

        void processData();

        void LoadTrainingData();

        double[][] getInputDataProcessed();

        double[][] getOutputDataProcessed();

        double[] processInputDataRecord(InputDataType inputRecord);

        OutputDataType processOutputDataRecord(double[] outputRecord);
    }
}
