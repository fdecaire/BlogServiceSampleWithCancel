using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogServiceSampleCore;

namespace BlogServiceSampleConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            StartingClass.Instance.Start();

            Console.WriteLine("Press any key to gracefully stop the processing...");
            Console.ReadKey();
            StartingClass.Instance.Stop();

			while (StartingClass.Instance.Stopped == false) { };

            Console.WriteLine("Processing stopped. Press any key to exit...");
            Console.ReadKey();
        }
    }
}
