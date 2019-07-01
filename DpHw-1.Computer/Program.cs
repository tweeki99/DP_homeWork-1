using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DpHw_1.Computer
{
    public interface IFactoryComputer
    {
        IAbstractProcessor CreateProcessor();

        IAbstractMainboard CreateMainboard();
    }

    class Sumsung : IFactoryComputer
    {
        public IAbstractProcessor CreateProcessor()
        {
            return new ProcessorBySony();
        }

        public IAbstractMainboard CreateMainboard()
        {
            return new MainboardBySony();
        }
    }

    class Dell : IFactoryComputer
    {
        public IAbstractProcessor CreateProcessor()
        {
            return new ProcessorByDell();
        }

        public IAbstractMainboard CreateMainboard()
        {
            return new MainboardByDell();
        }
    }

    public interface IAbstractProcessor
    {
        string ProcessorInfo();
    }

    class ProcessorBySony : IAbstractProcessor
    {
        public string ProcessorInfo()
        {
            return "The result of the product ProcessorBySony.";
        }
    }

    class ProcessorByDell : IAbstractProcessor
    {
        public string ProcessorInfo()
        {
            return "The result of the product ProcessorByDell.";
        }
    }

    public interface IAbstractMainboard
    {
        string MainboardInfo();

        string AnotherUsefulFunctionB(IAbstractProcessor collaborator);
    }

    class MainboardBySony : IAbstractMainboard
    {
        public string MainboardInfo()
        {
            return "The result of the product MainboardBySony.";
        }

        public string AnotherUsefulFunctionB(IAbstractProcessor collaborator)
        {
            var result = collaborator.ProcessorInfo();

            return $"The result of the MainboardBySony collaborating with the ({result})";
        }
    }

    class MainboardByDell : IAbstractMainboard
    {
        public string MainboardInfo()
        {
            return "The result of the product MainboardByDell.";
        }

        public string AnotherUsefulFunctionB(IAbstractProcessor collaborator)
        {
            var result = collaborator.ProcessorInfo();

            return $"The result of the MainboardByDell collaborating with the ({result})";
        }
    }

    class Client
    {
        public void Main()
        {
            Console.WriteLine("Client: Testing client code with the Sony factory type...");
            ClientMethod(new Sumsung());
            Console.WriteLine();

            Console.WriteLine("Client: Testing the same client code with the Dell factory type...");
            ClientMethod(new Dell());
        }

        public void ClientMethod(IFactoryComputer factory)
        {
            IAbstractProcessor processor = factory.CreateProcessor();
            IAbstractMainboard mainboard = factory.CreateMainboard();

            Console.WriteLine(mainboard.MainboardInfo());
            Console.WriteLine(mainboard.AnotherUsefulFunctionB(processor));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Client().Main();
            Console.ReadLine();
        }
    }
}
