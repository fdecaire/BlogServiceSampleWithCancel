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
			using (var dataObject = new CreateTempFile())
			{
				using (StreamWriter writer = new StreamWriter(dataObject.TempFile, true))
				{
					for (int i = 0; i < 5000; i++)
					{
						writer.WriteLine("Some test data");

						// check for cancel signal
						if (token.IsCancellationRequested)
						{
							return;
						}

						// this is not necessary (only for this demonstration 
						// to force this process to take a long time).
						Thread.Sleep(1000);
					}
				}
			}
		}
	}
}
