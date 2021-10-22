using System;

namespace CabInvoiceGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to CabInvoice Generator");
            InVoiceGenerator InvoiceGenerator = new InVoiceGenerator(RideType.NORMAL);
            double fare = InvoiceGenerator.Calculatefare(2.0, 5);

            Console.WriteLine(fare);
        }
    }
}
