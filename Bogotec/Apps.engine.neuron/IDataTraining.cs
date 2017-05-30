using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.engine.data
{
    public interface IDataTraining<InputDataType,OutputDatatype>
    {
        void LoadData(ref List<InputDataType> inputData, ref List<OutputDatatype> outputData);
    }
}
