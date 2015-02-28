using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BlogServiceSampleCore
{
	public class CreateTempFile : IDisposable
	{
		public string TempFile = "";

		public CreateTempFile()
		{
			TempFile = Path.GetTempFileName();
		}

		public void Dispose()
		{
			Dispose(true);
		}

		~CreateTempFile()
		{
			Dispose(false);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (TempFile != "")
				{
					File.Delete(TempFile);
				}
			}
		}
	}
}
