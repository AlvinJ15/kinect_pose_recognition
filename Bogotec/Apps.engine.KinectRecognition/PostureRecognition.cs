using Apps.engine.neuron;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Apps.engine.KinectRecognition
{
    public class PostureRecognition<InputDataType, OutputDataType>
    {
        private static NeuronNetwork network;

        private INeuralNetworkPattern<InputDataType, OutputDataType> networkPattern;

        private Dictionary<double[], OutputDataType> outputDataMap;

        public PostureRecognition(INeuralNetworkPattern<InputDataType, OutputDataType> networkPattern)
        {
            this.networkPattern = networkPattern;
        }

        public void enterPosition(InputDataType inputData, OutputDataType outputData)
        {
            networkPattern.enterTrainingRecord(inputData, outputData);
        }

        public void training()
        {

        }



    }




















































































































































































































}
