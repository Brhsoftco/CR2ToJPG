using System.ComponentModel;
using System.Threading;

namespace CR2ToJPG
{
    public class AbortableBackgroundWorker : BackgroundWorker
    {
        private Thread _workerThread;

        protected override void OnDoWork(DoWorkEventArgs e)
        {
            _workerThread = Thread.CurrentThread;

            try
            {
                base.OnDoWork(e);
            }
            catch (ThreadAbortException unusedThreadAbortException1)
            {
                e.Cancel = true;
                Thread.ResetAbort();
            }
        }

        public void Abort()
        {
            if (_workerThread != null)
            {
                _workerThread.Abort();
                _workerThread = null;
            }
        }
    }
}