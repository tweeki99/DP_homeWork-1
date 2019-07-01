using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DpHw_1.Car
{
    public interface IFactoryCar
    {
        IAbstractEngine CreateEngine();

        IAbstractBody CreateBody();
    }

    class Sumsung : IFactoryCar
    {
        public IAbstractEngine CreateEngine()
        {
            return new EngineByFord();
        }

        public IAbstractBody CreateBody()
        {
            return new BodyByFord();
        }
    }

    class Toyota : IFactoryCar
    {
        public IAbstractEngine CreateEngine()
        {
            return new EngineByToyota();
        }

        public IAbstractBody CreateBody()
        {
            return new BodyByToyota();
        }
    }

    public interface IAbstractEngine
    {
        string EngineInfo();
    }

    class EngineByFord : IAbstractEngine
    {
        public string EngineInfo()
        {
            return "The result of the product EngineByFord.";
        }
    }

    class EngineByToyota : IAbstractEngine
    {
        public string EngineInfo()
        {
            return "The result of the product EngineByToyota.";
        }
    }

    public interface IAbstractBody
    {
        string BodyInfo();

        string AnotherUsefulFunctionB(IAbstractEngine collaborator);
    }

    class BodyByFord : IAbstractBody
    {
        public string BodyInfo()
        {
            return "The result of the product BodyByFord.";
        }

        public string AnotherUsefulFunctionB(IAbstractEngine collaborator)
        {
            var result = collaborator.EngineInfo();

            return $"The result of the BodyByFord collaborating with the ({result})";
        }
    }

    class BodyByToyota : IAbstractBody
    {
        public string BodyInfo()
        {
            return "The result of the product BodyByToyota.";
        }

        public string AnotherUsefulFunctionB(IAbstractEngine collaborator)
        {
            var result = collaborator.EngineInfo();

            return $"The result of the BodyByToyota collaborating with the ({result})";
        }
    }

    class Client
    {
        public void Main()
        {
            Console.WriteLine("Client: Testing client code with the Ford factory type...");
            ClientMethod(new Sumsung());
            Console.WriteLine();

            Console.WriteLine("Client: Testing the same client code with the Toyota factory type...");
            ClientMethod(new Toyota());
        }

        public void ClientMethod(IFactoryCar factory)
        {
            IAbstractEngine engine = factory.CreateEngine();
            IAbstractBody body = factory.CreateBody();

            Console.WriteLine(body.BodyInfo());
            Console.WriteLine(body.AnotherUsefulFunctionB(engine));
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
