﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace WCFTutorials
{
    [ServiceContract]
    public interface IHelloWorldService
    {
        [OperationContract]
        string SayHello(string name);
    }

    public class HelloWorldService : IHelloWorldService
    {
        public string SayHello(string name)
        {
            return string.Format("Hello, {0}", name);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:8080/hello");
            //Create an instance of the "ServiceHost" class
            using (ServiceHost host = new ServiceHost(typeof(HelloWorldService), baseAddress))
            {
                //Enable metadata publishing.
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                host.Description.Behaviors.Add(smb);

                //Open the ServiceHost to start listening for message. Sine
                //no endpoints arc explicitly configured, the runtime will create
                //one endpoint per base address for each service contract implemented
                //by the service
                host.Open();

                Console.WriteLine("The Service is ready at {0}", baseAddress);
                Console.WriteLine("Press <Enter> to stop the service.");
                Console.WriteLine();

                //Close the ServiceHost.
                host.Close();
            }
        }
    }
}
