using Microsoft.Extensions.Logging;
using Mosaik.Core;
using SourceParser.TestAlgoritms.Tests;
using System;

namespace SourceParser.TestAlgoritms
{
    class Program
    {
        static void Main(string[] args)
        {
            /*var dTTest = new DTTest();
            dTTest.Test();*/
            ApplicationLogging.SetLoggerFactory(LoggerFactory.Create(lb => lb.AddConsole()));
            var nnTest = new NNTest();
            nnTest.Test();
        }
    }
}
