using Astrosys.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Astrosys.Logging
{
    /// <summary>
    /// This class implements ILogger interface and acts as a logging mechanism
    /// </summary>
    public partial class LoggingForm : Form, ILogger
    {
        public LoggingForm()
        {
            InitializeComponent();
            //Force handle creation once contructor is called
            //this allows the application to log events before this form has been shown
            var handle = this.Handle;
        }

        public void Log(string message)
        {
            //Invoke from UI thread
            if (IsHandleCreated)
                this.Invoke(new Action(() => { listBox1.Items.Insert(0, message); }));
        }

        private void LoggingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Hide the form, don't dispose it
            this.Hide();
            e.Cancel = true;
        }
    }
}
