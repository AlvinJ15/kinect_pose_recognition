using Apps.engine.neuron;
using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Apps.engine.KinectRecognition
{
    [Serializable()]
    public class PostureRecognition<InputDataType, OutputDataType>
        where InputDataType: Skeleton
    {
        private NeuronNetwork network;

        private INeuralNetworkPattern<InputDataType, OutputDataType> networkPattern;

        public PostureRecognition(PatternType patternType, DataTrainingType dataTrainingType, int iterations)
        {
            this.networkPattern = PatternResolver<InputDataType, OutputDataType>.ResolvePattern(patternType, dataTrainingType);
            var activationFunction = new ActivationFunction();
            activationFunction.InitializeSigmodeFunction(1.0);
            network = new NeuronNetwork(activationFunction, iterations);
        }

        public void enterPosture(InputDataType inputData, OutputDataType outputData)
        {
            networkPattern.enterTrainingRecord(inputData, outputData);
        }

        public int training()
        {
            //networkPattern.Initialize();
            network.Input = networkPattern.getInputDataProcessed();
            network.Output = networkPattern.getOutputDataProcessed();
            return network.trainingNeuron();
        }

        public OutputDataType Predict(InputDataType inputData)
        {
            var outputPredicted = network.predictInput(networkPattern.processInputDataRecord(inputData));
            return networkPattern.processOutputDataRecord(outputPredicted);
        }
    }




















































































































































































































}
