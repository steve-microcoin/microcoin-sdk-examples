using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Astrosys.Sdk;
using Astrosys.Logging;

namespace CoinAcceptorSDKTest
{
    public partial class MainForm : Form
    {
        //Initialize a list of child forms, each representing a connected device
        public static List<DeviceForm> DeviceForms = new List<DeviceForm>();
        private ILogger logger;
        public MainForm(ILogger logger)
        {
            this.logger = logger;
            InitializeComponent();

        }
        /// <summary>
        /// Adds a CoinValidator device to the list of connected devices, initailizes and displays its form
        /// </summary>
        /// <param name="device">The CoinValidator device to add</param>
        public void AddDevice(CoinValidator device)
        {
            //Find the device in the list of already connected devices
            var deviceForm = DeviceForms.Where(c => c.Device.SerialNumber == device.SerialNumber).FirstOrDefault();
            //If it doesn't exists
            if (deviceForm == null)
            {
                //Invoke from UI thread
                this.Invoke(new Action(() =>
                {
                    //Initialize and display device form
                    deviceForm = new DeviceForm((CoinValidator)device, logger);
                    deviceForm.MdiParent = this;
                    DeviceForms.Add(deviceForm);
                    deviceForm.Show();
                }));
            }
        }

        /// <summary>
        /// Removes a CoinValidator device from the list of connected devices and closes its form
        /// </summary>
        /// <param name="device"></param>
        public void RemoveDevice(CoinValidator device)
        {
            //Find the device in the list of already connected devices
            var deviceForm = DeviceForms.Where(c => c.Device.SerialNumber == device.SerialNumber).FirstOrDefault();
            //If it exists
            if (deviceForm != null)
            {
                //Invoke from UI thread
                this.Invoke(new Action(() => {
                    //Close the form
                    deviceForm.Close();
                }));
                //And remove it from connected devices list
                DeviceForms.Remove(deviceForm);
            }
        }
        private void Instance_ErrorOccurred(object sender, ErrorOccurredEventArgs e)
        {
            //Log error
            logger.Log($"{DateTime.Now}==>{e.ErrorCode}:{e.Message}");
            this.Invoke(new Action(() =>
            {
                //Change log icon to alert user
                btn_error.Image = Properties.Resources.error;
            }));
        }

        private void Instance_DeviceDisconnected(object sender, DeviceDisconnectedEventArgs e)
        {

            if (e != null)
            {
                if (e.Device is CoinValidator)
                {
                    logger.Log($"{DateTime.Now}==>Device disconnected:{e.Device.DeviceType}-{e.Device.SerialNumber}");
                    RemoveDevice((CoinValidator)e.Device);
                }
            }
        }
        private void Instance_DeviceConnected(object sender, DeviceConnectedEventArgs e)
        {
            if (e != null)
            {
                if (e.Device is CoinValidator)
                {
                    logger.Log($"{DateTime.Now}==>Device connected:{e.Device.DeviceType}-{e.Device.SerialNumber}");
                    AddDevice((CoinValidator)e.Device);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Set the SDK to log all events
            AstrosysSdk.Instance.Loglevel = LogLevel.All;
            //Watch for communications and error events 
            AstrosysSdk.Instance.DeviceConnected += Instance_DeviceConnected;
            AstrosysSdk.Instance.DeviceDisconnected += Instance_DeviceDisconnected;
            AstrosysSdk.Instance.ErrorOccurred += Instance_ErrorOccurred;
            //Start the SDK
            AstrosysSdk.Instance.Start(true, true, false);
        }


        private void btn_scan_Click(object sender, EventArgs e)
        {
            //Get a list of all available devices
            var devices = AstrosysSdk.Instance.GetDevices(true);
            foreach (var device in devices)
            {
                if (device is CoinValidator)
                {
                    AddDevice((CoinValidator)device);
                }

            }
        }

        private void btn_error_Click(object sender, EventArgs e)
        {
            //Show the looging form
            (logger as LoggingForm).Show();
            //And change log button image
            btn_error.Image = Properties.Resources.error_clear;
        }
    }
}
