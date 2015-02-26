using System;
using System.IO;
using System.Threading;

namespace BlogServiceSampleCore
{
	public class DataProcessingObject
	{
		private CancellationToken token;

		public DataProcessingObject(object action)
		{
			token = (CancellationToken)action;
		}

		public void PerformProcess()
		{
			// do something here
			using (StreamWriter writer = new StreamWriter("c:\\TestService.txt", true))
			{
				writer.WriteLine("Service is running " + DateTime.Now.ToString("H:mm:ss"));
			}

			for (int i = 0; i < 5000; i++)
			{
				// check for cancel signal
				if (token.IsCancellationRequested)
				{
					return;
				}

				Thread.Sleep(1000);
			}
		}
	}
}
