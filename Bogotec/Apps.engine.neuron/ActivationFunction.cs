using AForge.Neuro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.engine.neuron
{
    [Serializable()]
    public class ActivationFunction
    {
        private IActivationFunction _activationFunction;
        public void InitializeSigmodeFunction(double sigmoidAlphaValue)
        {
            _activationFunction = new BipolarSigmoidFunction(sigmoidAlphaValue);
        }

        public IActivationFunction Function
        {
            get
            {
                return _activationFunction;
            }
        }
    }
}
