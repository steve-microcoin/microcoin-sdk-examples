using System.Windows.Forms;

namespace Astrosys.Logging
{
    /// <summary>
    /// An overly simplified messagebox logging mechanism used for testing
    /// </summary>
    public class MessageBoxLogger : ILogger
    {
        public void Log(string message)
        {
            MessageBox.Show(message);
        }
    }
}
