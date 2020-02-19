using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneWayCalculatorClient
{
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class OneWayCalculatorClient : System.ServiceModel.ClientBase<IOneWayCalculator>, IOneWayCalculator
    {
        public OneWayCalculatorClient()
        {
        }

        public OneWayCalculatorClient(string endpointConfigurationName) :
            base(endpointConfigurationName)
        {
        }

        public OneWayCalculatorClient(string endpointConfigurationName, string remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }

        public OneWayCalculatorClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }

        public OneWayCalculatorClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
            base(binding, remoteAddress)
        {
        }

        public void Add(double n1, double n2)
        {
            base.Channel.Add(n1, n2);
        }

        public void Subtract(double n1, double n2)
        {
            base.Channel.Subtract(n1, n2);
        }

        public void Multiply(double n1, double n2)
        {
            base.Channel.Multiply(n1, n2);
        }

        public void Divide(double n1, double n2)
        {
            base.Channel.Divide(n1, n2);
        }

        public string SayHello(string name)
        {
            return base.Channel.SayHello(name);
        }
    }
}
