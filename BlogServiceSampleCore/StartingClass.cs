using System.Threading;

namespace BlogServiceSampleCore
{
    public class StartingClass
    {
        private static StartingClass _instance;
		public CancellationTokenSource cts = new CancellationTokenSource();

        public static StartingClass Instance
        {
            get { return _instance ?? (_instance = new StartingClass()); }
        }

        public bool Stopped { get; private set; }

        public void Start()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(action =>
            {
				CancellationToken token = (CancellationToken)action;
				while (!token.IsCancellationRequested)
                {
					var dataProcessingObject = new DataProcessingObject(action);
					dataProcessingObject.PerformProcess();

					if (!token.IsCancellationRequested)
                    {
                        Thread.Sleep(5 * 1000); // wait 5 seconds
                    }
                }

                Stopped = true;

			}), cts.Token);
        }


        public void Stop()
        {
			cts.Cancel();
        }
    }
}

