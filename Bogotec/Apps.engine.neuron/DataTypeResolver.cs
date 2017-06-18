using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.engine.data
{
    [Serializable()]
    public class DataTypeResolver<T>
    {
        public static T CastObject(object readData) {
            if (readData is T) {
                return (T)readData;
            } else {
                try {
                    return (T)Convert.ChangeType(readData, typeof(T));
                } catch (InvalidCastException) {
                    return default(T);
                }
            }
        }
    }

}
