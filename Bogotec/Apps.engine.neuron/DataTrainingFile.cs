using Apps.engine.neuron.Utilities;
using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Apps.engine.data
{
    [Serializable()]
    public class DataTrainingFile<InputDataType, OutputDataType> : IDataTraining<InputDataType, OutputDataType>
        
    {
        public void LoadData(ref List<InputDataType> inputData, ref List<OutputDataType> outputData)
        {
            String folderPath = "TRAINING_DATA2";
            foreach (string file in Directory.EnumerateFiles(folderPath, "*.TD"))
            {
                var readFile = File.ReadAllBytes(file);
                var skeletonList = ReadWriteObjectFile.FromByteArray<List<Skeleton>>(readFile);
                foreach(Skeleton skel in skeletonList)
                {
                    var output = Regex.Replace(file.ToUpper(), @"[\d-]\.TD", string.Empty).ToUpper().Split(new string[] { "\\" },StringSplitOptions.None)[1];
                    outputData.Add(DataTypeResolver<OutputDataType>.CastObject(output));
                    inputData.Add(DataTypeResolver<InputDataType>.CastObject(skel));
                }

            }
        }
    }
}
