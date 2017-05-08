using AForge.Neuro;
using AForge.Neuro.Learning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.engine.neuron
{
    public class NeuronNetwork
    {

        ActivationNetwork network;

        BackPropagationLearning teacher;

        private double[][] inputData;

        private double[][] outputData;

        private int iterations;

        private List<double[]> inputList;
        private List<double[]> outputList;
        private IActivationFunction activateFunction;

        public NeuronNetwork(IActivationFunction activateFunction, int iterations)
        {
            this.activateFunction = activateFunction;
            this.iterations = iterations;
        }
        public void addInputRecord(double[] inputRecord, double[] outputRecord)
        {
            if (inputList.Count > 0)
            {
                if (inputList.Count != inputList.ElementAt(inputList.Count - 1).Length)
                {
                    throw new Exception("Invalid Input Vector Size");
                }
                if (outputList.Count != inputList.ElementAt(outputList.Count - 1).Length)
                {
                    throw new Exception("Invalid Output Vector Size");
                }
            }

            inputList.Add(inputRecord);
            outputList.Add(outputRecord);
        }
        public void trainingNeuron()
        {
            inputData = inputList.ToArray();
            outputData = outputList.ToArray();

            double sigmoidAlphaValue = 1.0;
            network = new ActivationNetwork(
                new BipolarSigmoidFunction(sigmoidAlphaValue),
                inputData[0].Length, inputData[0].Length * 2, outputData[0].Length);

            teacher = new BackPropagationLearning(network);

            int iterationsCount = 0;
            bool flag = true;
            while (iterations != 0 && iterationsCount < iterations && flag)
            {
                flag = false;
                teacher.RunEpoch(inputData, outputData);

                for (int i = 0; i < inputData.Length; i++)
                {
                    if (!Array.Equals(outputData[i], ValidateOutput(network.Compute(inputData[i]))))
                    {
                        flag = true;
                    }
                }
                iterationsCount++;
                if (!flag)
                    break;
            }
        }

        public double[] predictInput(double[] input)
        {
            return ValidateOutput(network.Compute(input));
        }

        public static double[] ValidateOutput(double[] output)
        {
            double[] temp = new double[output.Length];
            for (int i = 0; i < output.Length; i++)
            {
                if (output[i] > 0.75)
                {
                    temp[i] = 1.0;
                }
                else if (output[i] < 0.25)
                {
                    temp[i] = 0.0;
                }
                else
                    temp[i] = -1;
            }
            return temp;
        }
        public double[][] Input
        {
            get
            {
                return inputData;
            }
            set => inputData = value;
        }

        public double[][] Output
        {
            get
            {
                return outputData;
            }
            set => outputData = value;
        }

        public int Iterations
        {
            get
            {
                return iterations;
            }
            set => iterations = value;
        }


    }
}
