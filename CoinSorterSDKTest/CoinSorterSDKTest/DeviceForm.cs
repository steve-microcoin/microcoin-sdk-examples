using Astrosys.Sdk;
using Astrosys.Logging;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CoinSorterSDKTest
{
    public partial class DeviceForm : Form
    {
        //Define the required balance for the current operation
        private readonly double _requiredBalance = 10000;
        //Keep a referenc of the logger
        private ILogger logger;
        //Keep a reference of the device associated with this form
        public CoinValidator Device { get; set; }

        public DeviceForm(CoinValidator device,ILogger logger)
        {
            //Set the associated device
            this.Device = device;
            //Set the logger
            this.logger = logger;
            InitializeComponent();
        }

        private void DeviceForm_Load(object sender, EventArgs e)
        {
            //Set the form title to the device type and serial number
            SetFormTitle();
            //Watch for coin accepted event
            Device.CoinAccepted += Device_CoinAccepted;
            //Watch for device errors
            Device.ErrorOccurred += Device_ErrorOccurred;
            //If master inhibit is present, prompt user
            if (!Device.IsEnabled)
            {
                AlertMasterInhibit();
            }
           
            //This is a temporary workaround until the Device.GetValidCategoryIndexes method has been fixed
            //it gets a list of valid categories from the device
            List<int> validCats = new List<int>();
            for (int i = 1; i <= CoinValidator.MaxNumCoins; i++)
            {
                if (string.IsNullOrEmpty(Device.GetCoinName(i)))
                {
                    continue;
                }
                validCats.Add(i);
            }
            //Loop through available categories, create a SorterPathControl for each, set their properties and add them 
            //to the flow layout
            foreach (var item in validCats)
            {
                SorterPathControl pathControl = new SorterPathControl();
                pathControl.Category = item;
                pathControl.CurrencyName = Device.GetCoinName(item);
                pathControl.Value = Device.GetCoinValue(item);
                pathControl.Path = Device.GetSorterPath(item);
                //Watch for path change event and set the device accordingly
                pathControl.PathChanged += (s, args) =>
                {
                    Device.SetSorterPath(pathControl.Category, args.PathNumber);
                };
                //Add to the flow layout
                flw_sorterpaths.Controls.Add(pathControl);
            }
        }

        private void Device_CoinAccepted(object sender, CoinAcceptedEventArgs e)
        {
            
            this.Invoke(new Action(
               () =>
               {
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

        /// <summary>
        /// Check if the amount in cash box has exceeded the required amount
        /// </summary>
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
            //Check if the device is responsive
            MessageBox.Show(Device.IsAlive() ?
                "Alive and kicking!!" : "Nope",
                this.Text);
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
