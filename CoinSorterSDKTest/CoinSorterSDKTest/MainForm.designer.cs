namespace CoinSorterSDKTest
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btn_scan = new System.Windows.Forms.ToolStripButton();
            this.btn_error = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(50, 50);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_scan,
            this.btn_error});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(982, 50);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btn_scan
            // 
            this.btn_scan.AutoSize = false;
            this.btn_scan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_scan.Image = ((System.Drawing.Image)(resources.GetObject("btn_scan.Image")));
            this.btn_scan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_scan.Name = "btn_scan";
            this.btn_scan.Size = new System.Drawing.Size(50, 50);
            this.btn_scan.Text = "Scan Devices";
            this.btn_scan.ToolTipText = "Scan Devices";
            this.btn_scan.Click += new System.EventHandler(this.btn_scan_Click);
            // 
            // btn_error
            // 
            this.btn_error.AutoSize = false;
            this.btn_error.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_error.Image = global::CoinSorterSDKTest.Properties.Resources.error_clear;
            this.btn_error.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_error.Name = "btn_error";
            this.btn_error.Size = new System.Drawing.Size(50, 50);
            this.btn_error.Text = "toolStripButton1";
            this.btn_error.Click += new System.EventHandler(this.btn_error_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 629);
            this.Controls.Add(this.toolStrip1);
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.Text = "Coin Sorter SDK Test";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btn_scan;
        private System.Windows.Forms.ToolStripButton btn_error;
    }
}

