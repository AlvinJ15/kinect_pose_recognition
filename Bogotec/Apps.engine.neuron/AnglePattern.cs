using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.engine.neuron
{
    class AnglePattern<InputDataType, OutputDataType> : INeuralNetworkPattern<InputDataType, OutputDataType>
    {
        private long indexedMap;

        private List<InputDataType> inputRecords;

        private List<OutputDataType> outputRecords;

        private Dictionary<OutputDataType, long> outputDataMap;

        public void enterTrainingRecord(InputDataType inputData, OutputDataType outputData)
        {
            if (inputData == null || outputData == null)
            {
                throw new ArgumentNullException();
            }

            inputRecords.Add(inputData);
            outputRecords.Add(outputData);
        }

        public double[][] getInputDataProcessed()
        {
            double[][] inputResult = new double[inputRecords.Count][];
            for (int i = 0; i < inputRecords.Count; i++)
                inputResult[i] = new double[inputRecords.Count * 2];
            for(int i = 0; i < inputRecords.Count; i++)
            {

            }
            throw new NotImplementedException();
        }

        public double[][] getOutputDataProcessed()
        {
            foreach (OutputDataType outData in outputRecords)
            {
                if (!outputDataMap.ContainsKey(outData))
                {
                    outputDataMap.Add(outData, indexedMap);
                    indexedMap <<= 1;
                }
            }
            double[][] outputResult = new double[outputRecords.Count][];
            for (int i = 0; i < outputResult.Length; i++)
                outputResult[i] = new double[outputDataMap.Count];

            for (int i = 0; i < outputResult.Length; i++)
            {
                var val = outputDataMap[outputRecords[i]];
                for (int j = 0; j < outputResult[i].Length; j++)
                {
                    outputResult[i][j] = (double)(val | (1 << j));
                }
            }

            return outputResult;
        }

        public void processData()
        {
            throw new NotImplementedException();
        }
    }
}
