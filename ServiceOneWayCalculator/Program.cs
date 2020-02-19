using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace ServiceOneWayCalculator
{
    [ServiceContract(Namespace = "ServiceOneWayCalculator")]
    public interface IOneWayCalculator
    {
        [OperationContract]
        double Add(double n1, double n2);
        [OperationContract(IsOneWay = true)]
        void Subtract(double n1, double n2);
        [OperationContract(IsOneWay = true)]
        void Multiply(double n1, double n2);
        [OperationContract(IsOneWay = true)]
        void Divide(double n1, double n2);
        [OperationContract]
        string SayHello(string name);
    }

    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.PerCall)]
    public class CalculatorService : IOneWayCalculator
    {
        public double Add(double n1, double n2)
        {
            double result = n1 + n2;
            Console.WriteLine("Add({0},{1}) = {2} ", n1, n2, result);

            return result;
        }

        public void Subtract(double n1, double n2)
        {
            double result = n1 - n2;
            Console.WriteLine("Subtract({0},{1}) = {2}", n1, n2, result);
        }

        public void Multiply(double n1, double n2)
        {
            double result = n1 * n2;
            Console.WriteLine("Multiply({0},{1}) = {2}", n1, n2, result);
        }

        public void Divide(double n1, double n2)
        {
            double result = n1 / n2;
            Console.WriteLine("Divide({0},{1}) = {2}", n1, n2, result);
        }

        public string SayHello(string name)
        {
            Console.WriteLine("SayHello({0})", name);
            return "Hello " + name;
        }
    }  

    class Program
    {
        // Host the service within this EXE console application.
        static void Main(string[] args)
        {
            // Define the base address for the service.  
            Uri baseAddress = new Uri("http://localhost:8000/servicemodelsamples/service");

            // Create a ServiceHost for the CalculatorService type and provide the base address.  
            using (ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress))
            {
                // Add an endpoint using the IOneWayCalculator contract and the WSHttpBinding
                serviceHost.AddServiceEndpoint(typeof(IOneWayCalculator), new WSHttpBinding(), "");

                // Turn on the metadata behavior, this allows svcutil to get metadata for the service.
                ServiceMetadataBehavior smb = (ServiceMetadataBehavior)serviceHost.Description.Behaviors.Find<ServiceMetadataBehavior>();
                if (smb == null)
                {
                    smb = new ServiceMetadataBehavior();
                    smb.HttpGetEnabled = true;
                    serviceHost.Description.Behaviors.Add(smb);
                }

                // Open the ServiceHostBase to create listeners and start listening for messages.
                serviceHost.Open();

                // The service can now be accessed.  
                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();
                Console.ReadLine();
            }  
        }
    }
}
