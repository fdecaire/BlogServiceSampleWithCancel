using System.ServiceProcess;
using BlogServiceSampleCore;

namespace BlogServiceSample
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            StartingClass.Instance.Start();
        }

        protected override void OnStop()
        {
            StartingClass.Instance.Stop();

			while (!StartingClass.Instance.Stopped)
			{
				// wait for service to stop
			}
        }
    }
}
