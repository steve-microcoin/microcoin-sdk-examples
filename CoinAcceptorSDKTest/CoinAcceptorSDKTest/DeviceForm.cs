using Astrosys.Logging;
using Astrosys.Sdk;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoinAcceptorSDKTest
{
    public partial class DeviceForm : Form
    {
        //Define the required balance for the current operation
        private readonly double _requiredBalance=300;
        //Keep reference of logger
        private ILogger logger;
        //Keep reference of the device associated with this form
        public CoinValidator Device { get; set; }

        public DeviceForm(CoinValidator device,ILogger logger)
        {
            //Set the associated device
            this.Device = device;
            //Set the Logger
            this.logger = logger;
            InitializeComponent();
        }

        private void DeviceForm_Load(object sender, EventArgs e)
        {
            //Set the form title to the device type and serial number
            SetFormTitle();
            //Watch for note getting into escrow event
            Device.CoinAccepted += Device_CoinAccepted;
            //Watch for device errors
            Device.ErrorOccurred += Device_ErrorOccurred;

            //If master inhibit is present, prompt user
            if (!Device.IsEnabled)
            {
                AlertMasterInhibit();
            }
        }

        private void Device_CoinAccepted(object sender, CoinAcceptedEventArgs e)
        {
            this.Invoke(new Action(
               () =>
               {
                   //Update the last accepted text
                   txt_lastaccepted.Text = $"{e.CurrencyValue} {e.CoinName}";
                   double currentlyInCash = 0;
                   try
                   {
                        //If the amount stored in txt_incashbox Tag is not null, retrieve the amount
                        currentlyInCash = txt_incashbox.Tag == null ? 0 : (double)txt_incashbox.Tag;
                   }
                   catch (Exception) { }
                    //Calculate the total amount
                    double inCashAfterAddition = currentlyInCash + e.CurrencyValue;
                    //Change text to reflect the current amount
                    txt_incashbox.Text = $"{inCashAfterAddition} {e.CoinName}";
                    //And update the Tag value
                    txt_incashbox.Tag = inCashAfterAddition;
                    //And check if the required balance has been reached
                    CheckBalance();
               }
               ));
        }

        /// <summary>
        /// Sets the title of the form according to the state of the associated device
        /// if connected, it will be changed to the device type and serial number
        /// otherwise the string "DISCONNECTED" will be added
        /// </summary>
        private void SetFormTitle()
        {
            //Change the form title to the device type and serial number
            this.Text = $"{Device.DeviceType}, SN:{Device.SerialNumber}";
        }

        private void Device_MasterInhibitActivated(object sender, EventArgs e)
        {
            //If master inhibit is initialized, prompt user
            AlertMasterInhibit();
        }

        /// <summary>
        /// Alert the user a master inhibit id present
        /// </summary>
        private void AlertMasterInhibit()
        {
            //Alert the user
            MessageBox.Show("Master inhibit intiated, click OK to re-enable the device",
                this.Text, MessageBoxButtons.OK);
            //And enable device
            Device.IsEnabled = true;
        }

        private void CheckBalance()
        {
            double currentlyInCash = 0;
            try
            {
                //If the amount stored in txt_incashbox Tag is not null, retrieve the amount
                currentlyInCash = txt_incashbox.Tag == null ? 0 : (double)txt_incashbox.Tag;
            }
            catch (Exception) { }
            //Check if the amount is bigger than or equal to the required balance
            if (currentlyInCash >= _requiredBalance)
            {
                //Show message box to the user
                MessageBox.Show($"You deposited {_requiredBalance}¢, change is {currentlyInCash - _requiredBalance}¢!"
                    , this.Text);
                //Empty Tag and cleat text
                txt_incashbox.Tag = 0;
                txt_incashbox.Text = "";
                txt_lastaccepted.Text = "";
            }
           
        }
        
        private void btn_isalive_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Device.IsAlive() ? "Alive and kicking!!" : "Nope", this.Text);
        }

        private void DeviceForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Unregister event handlers, otherwise they will keep firing after this form has been closed
            Device.CoinAccepted -= Device_CoinAccepted;
            Device.ErrorOccurred -= Device_ErrorOccurred;
            //And remove the form from the list
            MainForm.DeviceForms.Remove(this);
        }

        private void Device_ErrorOccurred(object sender, ErrorOccurredEventArgs e)
        {
            //Insert error messages to the top of the list
            this.Invoke(new Action(() =>
            {
                lst_log.Items.Insert(0, $"{DateTime.Now}==>{e.ErrorCode}: {e.Message}");
                logger.Log($"{DateTime.Now}==>{e.ErrorCode}: {e.Message}");
            }));
        }

        private void btn_isenabled_Click(object sender, EventArgs e)
        {
            //Check if device is in master inhibit mode
            if (Device.IsEnabled)
            {
                MessageBox.Show("Yup!", this.Text);
            }
            else
            {
                //Alert user if it is
                AlertMasterInhibit();
            }
        }
    }
}
