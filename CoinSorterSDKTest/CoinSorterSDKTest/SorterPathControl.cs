using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoinSorterSDKTest
{
    public partial class SorterPathControl : UserControl
    {
        public int Category
        {
            get
            {
                return category;
            }
            set
            {
                this.lbl_cat.Text = value.ToString();
                category = value;
            }
        }

        public double Value
        {
            get { return value; }
            set
            {
                this.lbl_value.Text = value.ToString();
                this.value = value;
            }
        }

        public string CurrencyName
        {
            get
            {
                return name;
            }
            set
            {
                this.lbl_name.Text = value;
                this.name = value;
            }
        }
        public int Path {
            get
            {
                return (int)num_path.Value;
            }
            set
            {
                num_path.Value = value;
            }
        }
        public delegate void PathChangedHandler(object sender, PathEventArgs e);
        public event PathChangedHandler PathChanged; 
        private int category;
        private double value;
        private string name;
        public SorterPathControl()
        {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (PathChanged != null)
            {
                PathChanged(this, new PathEventArgs() { PathNumber = (int)num_path.Value });
            }
        }
    }

    public class PathEventArgs
    {
        public int PathNumber { get; set; }
    }
}
