using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneWayCalculatorClient
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace = "OneWayCalculatorClient", ConfigurationName = "IOneWayCalculator")]  
    public interface IOneWayCalculator
    {
        [System.ServiceModel.OperationContractAttribute(IsOneWay = true, Action = "http://OneWayCalculatorClient/IOneWayCalculator/Add")]
        void Add(double n1, double n2);

        [System.ServiceModel.OperationContractAttribute(IsOneWay = true, Action = "http://OneWayCalculatorClient/IOneWayCalculator/Subtract")]
        void Subtract(double n1, double n2);

        [System.ServiceModel.OperationContractAttribute(IsOneWay = true, Action = "http://OneWayCalculatorClient/IOneWayCalculator/Multiply")]
        void Multiply(double n1, double n2);

        [System.ServiceModel.OperationContractAttribute(IsOneWay = true, Action = "http://OneWayCalculatorClient/IOneWayCalculator/Divide")]
        void Divide(double n1, double n2);

        [System.ServiceModel.OperationContractAttribute(Action = "http://OneWayCalculatorClient/IOneWayCalculator/SayHello", ReplyAction = "http://Microsoft.ServiceModel.Samples/IOneWayCalculator/SayHelloResponse")]
        string SayHello(string name);  
    }
}
