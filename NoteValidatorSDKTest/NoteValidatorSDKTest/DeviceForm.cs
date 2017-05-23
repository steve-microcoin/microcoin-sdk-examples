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

namespace NoteValidatorSDKTest
{
    public partial class DeviceForm : Form
    {
        //Define the required balance for the current operation
        private readonly double _requiredBalance=20;
        //Keep reference of the device associated with this form
        public NoteReader Device { get; set; }
        //Keep reference of logger
        private ILogger logger;
        //Record the current time
        private DateTime startTime = DateTime.Now;
        public DeviceForm(NoteReader device,ILogger logger)
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
            //Watch for note getting into escrow event
            Device.NoteInEscrow += Device_NoteInEscrow;
            //Watch for note sent to cashbox event
            Device.NoteSentToCashbox += Device_NoteSentToCashbox;
            //Watch for note returned event, this fires after the customer has actually pulled the note out of the device
            //, not when the note has been ejected
            Device.NoteReturned += Device_NoteReturned;
            //Watch for master inhibit activation event
            Device.MasterInhibitActivated += Device_MasterInhibitActivated;
            //Watch for device errors
            Device.ErrorOccurred += Device_ErrorOccurred;
            
            //If master inhibit is present, prompu user
            if (!Device.IsEnabled)
            {
                AlertMasterInhibit();
            }

            chk_markforpolling.Checked = Device.IsMarkedForPolling;
            timer1.Start();
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

        private void Device_NoteReturned(object sender, EventArgs e)
        {
            //Invoke the code from the UI thread
            this.Invoke(new Action(
               () =>
               {
                   //If note has been withdrawn, empty excrow
                   EmptyEscrow();
                   //And inform user
                   MessageBox.Show("Note Returned",this.Text);
               }));
        }

        private void Device_MasterInhibitActivated(object sender, EventArgs e)
        {
            //If master inhibit is initialized, prompt user
            AlertMasterInhibit();
        }

       
        private void Device_NoteSentToCashbox(object sender, NoteSentToCashboxEventArgs e)
        {
            this.Invoke(new Action(
                () =>
                {
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
                    txt_incashbox.Text = $"{inCashAfterAddition} {e.NoteName}";
                    //And update the Tag value
                    txt_incashbox.Tag = inCashAfterAddition;
                    //Empty escrow
                    EmptyEscrow();
                    //And check if the required balance has been reached
                    CheckBalance();
                }
                ));
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
                MessageBox.Show($"You deposited {_requiredBalance}$, change is {currentlyInCash - _requiredBalance}!"
                    , this.Text);
                //Empty Tag and cleat text
                txt_incashbox.Tag = 0;
                txt_incashbox.Text = "";
            }
           
        }

        private void EmptyEscrow()
        {
            txt_inescrow.Text = "";
            btn_sendtocash.Enabled = false;
            btn_return.Enabled = false;

        }

        private void Device_NoteInEscrow(object sender, NoteInEscrowEventArgs e)
        {
            this.Invoke(new Action(
                () =>
                {
                    //set the txt_inescrow text to the currency value and name
                    txt_inescrow.Text = $"{e.CurrencyValue} {e.NoteName}";
                    //Enable note action buttons
                    btn_sendtocash.Enabled = true;
                    btn_return.Enabled = true;
                }
                ));
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Device.SendNoteToCashbox();
        }

        private void btn_return_Click(object sender, EventArgs e)
        {
            Device.ReturnNote();
        }

        private void btn_isalive_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Device.IsAlive() ? "Alive and kicking!!" : "Nope", this.Text);
        }

        private void DeviceForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Unregister event handlers, otherwise they will keep firing after this form has been closed
            Device.NoteInEscrow -= Device_NoteInEscrow;
            Device.NoteSentToCashbox -= Device_NoteSentToCashbox;
            Device.NoteReturned -= Device_NoteReturned;
            Device.MasterInhibitActivated -= Device_MasterInhibitActivated;
            Device.ErrorOccurred -= Device_ErrorOccurred;
            //And remove the form from the list
            MainForm.DeviceForms.Remove(this);
        }

        private void Device_ErrorOccurred(object sender, ErrorOccurredEventArgs e)
        {
            //Insert error messages to the top of the list
            this.Invoke(new Action(() =>
            {
                lst_log.Items.Insert(0, $"{DateTime.Now}-->{e.ErrorCode}: {e.Message}");
                logger.Log($"{DateTime.Now}-->{e.ErrorCode}: {e.Message}");
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

        private void chk_markforpolling_CheckedChanged(object sender, EventArgs e)
        {
            Device.IsMarkedForPolling = chk_markforpolling.Checked;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan aliveSince = DateTime.Now - startTime;
            lbl_timer.Text = $"{aliveSince.Hours}:{aliveSince.Minutes}:{aliveSince.Seconds}";
        }
    }
}
