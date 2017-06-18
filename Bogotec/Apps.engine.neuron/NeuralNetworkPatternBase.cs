using Apps.engine.data;
using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.engine.neuron
{
    [Serializable()]
    public abstract class NeuralNetworkPatternBase<InputDataType, OutputDataType> : INeuralNetworkPattern<InputDataType, OutputDataType>
    {
        protected long _indexedMap;

        protected List<InputDataType> _inputRecords;

        protected List<OutputDataType> _outputRecords;

        protected Dictionary<OutputDataType, long> _outputDataMap;

        protected Dictionary<OutputKeymap, OutputDataType> _outputPredictMap;

        protected IDataTraining<InputDataType, OutputDataType> _dataTrainingResolver;

        protected List<JointType> _joinTypes;

        public NeuralNetworkPatternBase()
        {
            _indexedMap = 1;
            _inputRecords = new List<InputDataType>();
            _outputRecords = new List<OutputDataType>();
            _outputDataMap = new Dictionary<OutputDataType, long>();
            _outputPredictMap = new Dictionary<OutputKeymap, OutputDataType>();
            _joinTypes = new List<JointType>();
            foreach (JointType foo in Enum.GetValues(typeof(JointType)))
            {
                _joinTypes.Add(foo);
            }
        }
        public void enterTrainingRecord(InputDataType inputRecord, OutputDataType outputRecord)
        {
            _inputRecords.Add(inputRecord);
            _outputRecords.Add(outputRecord);
        }

        public double[][] getInputDataProcessed()
        {
            double[][] inputResult = new double[_inputRecords.Count][];
            for (int i = 0; i < _inputRecords.Count; i++)
                inputResult[i] = new double[_inputRecords.Count];
            for (int i = 0; i < _inputRecords.Count; i++)
            {
                inputResult[i] = processInputDataRecord(_inputRecords[i]);
            }

            return inputResult;
        }

        public double[][] getOutputDataProcessed()
        {
            foreach (OutputDataType outData in _outputRecords)
            {
                if (!_outputDataMap.ContainsKey(outData))
                {
                    _outputDataMap.Add(outData, _indexedMap);
                    _indexedMap <<= 1;
                }
            }
            double[][] outputResult = new double[_outputRecords.Count][];
            for (int i = 0; i < outputResult.Length; i++)
                outputResult[i] = new double[_outputDataMap.Count];

            for (int i = 0; i < outputResult.Length; i++)
            {
                var val = _outputDataMap[_outputRecords[i]];
                for (int j = 0; j < outputResult[i].Length; j++)
                {
                    outputResult[i][j] = (double)((val & (1 << j)) == 0 ? 0 : 1);
                }
            }
            foreach(var a in _outputDataMap)
            {
                var val = a.Value;
                var outputArr = new double[_outputDataMap.Count];
                for (int j = 0; j < _outputDataMap.Count; j++)
                {
                    outputArr[j] = (double)((val & (1 << j))==0?0:1);
                }
                _outputPredictMap.Add(new OutputKeymap(outputArr), a.Key);
            }
            return outputResult;
        }

        public abstract double[] processInputDataRecord(InputDataType inputRecord);

        public void processData()
        {
            throw new NotImplementedException();
        }

        public OutputDataType processOutputDataRecord(double[] outputRecord)
        {
            var key = new OutputKeymap(outputRecord);
            if (_outputPredictMap.ContainsKey(key))
            {
                return _outputPredictMap[key];
            }
            else
                return default(OutputDataType);
        }

        public void LoadTrainingData()
        {
            if(_dataTrainingResolver != null){
                List<InputDataType> inputData = new List<InputDataType>();
                List<OutputDataType> outputData = new List<OutputDataType>();
                _dataTrainingResolver.LoadData(ref inputData, ref outputData);

                for(int i = 0; i < inputData.Count; i++)
                {
                    enterTrainingRecord(inputData[i], outputData[i]);
                }
            }
        }
        [Serializable()]
        public class OutputKeymap : IEquatable<OutputKeymap>
        {
            public double[] output { get; set; }
            public OutputKeymap(double[] outputRecord)
            {
                output = outputRecord;
            }
            public override int GetHashCode()
            {
                return 0;
            }
            public override bool Equals(object obj)
            {
                var x =(obj as OutputKeymap);
                for(int i =0;i< this.output.Length; i++)
                {
                    if (this.output[i] != x.output[i])
                        return false;
                }
                return true;
            }
            public bool Equals(OutputKeymap obj)
            {
                for (int i = 0; i < this.output.Length; i++)
                {
                    if (this.output[i] != obj.output[i])
                        return false;
                }
                return true;
            }
        }

        public IDataTraining<InputDataType, OutputDataType> DataTrainingResolver
        {
            get
            {
                return _dataTrainingResolver;
            }
            set
            {
                _dataTrainingResolver = value;
                LoadTrainingData();
            }
        }
    }
}
