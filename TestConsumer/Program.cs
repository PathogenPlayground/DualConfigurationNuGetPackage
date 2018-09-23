using System;

namespace TestConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            string configuration = DualConfigurationNuGetPackage.TestClass.GetConfiguration();
            Console.WriteLine($"Using NuGet package that was built in the '{configuration}' configuration.");
            Console.ReadLine();
        }
    }
}
