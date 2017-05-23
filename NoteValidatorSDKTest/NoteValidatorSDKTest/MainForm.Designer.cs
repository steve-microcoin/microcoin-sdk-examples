namespace NoteValidatorSDKTest
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
            this.components = new System.ComponentModel.Container();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btn_scan = new System.Windows.Forms.ToolStripButton();
            this.btn_error = new System.Windows.Forms.ToolStripButton();
            this.btn_startpolling = new System.Windows.Forms.ToolStripButton();
            this.btn_pollselected = new System.Windows.Forms.ToolStripButton();
            this.btn_stoppolling = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lbl_timer = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(50, 50);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_scan,
            this.btn_error,
            this.btn_startpolling,
            this.btn_pollselected,
            this.btn_stoppolling});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(982, 50);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btn_scan
            // 
            this.btn_scan.AutoSize = false;
            this.btn_scan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_scan.Image = global::NoteValidatorSDKTest.Properties.Resources.rescan;
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
            this.btn_error.Image = global::NoteValidatorSDKTest.Properties.Resources.error_clear;
            this.btn_error.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_error.Name = "btn_error";
            this.btn_error.Size = new System.Drawing.Size(50, 50);
            this.btn_error.Text = "Log";
            this.btn_error.Click += new System.EventHandler(this.btn_error_Click);
            // 
            // btn_startpolling
            // 
            this.btn_startpolling.AutoSize = false;
            this.btn_startpolling.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_startpolling.Image = global::NoteValidatorSDKTest.Properties.Resources.Start;
            this.btn_startpolling.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_startpolling.Name = "btn_startpolling";
            this.btn_startpolling.Size = new System.Drawing.Size(50, 50);
            this.btn_startpolling.Text = "Start polling all";
            this.btn_startpolling.Click += new System.EventHandler(this.btn_startpolling_Click);
            // 
            // btn_pollselected
            // 
            this.btn_pollselected.AutoSize = false;
            this.btn_pollselected.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_pollselected.Image = global::NoteValidatorSDKTest.Properties.Resources.startselected;
            this.btn_pollselected.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_pollselected.Name = "btn_pollselected";
            this.btn_pollselected.Size = new System.Drawing.Size(50, 50);
            this.btn_pollselected.Text = "Start polling selected devices";
            this.btn_pollselected.Click += new System.EventHandler(this.btn_suspendpolling_Click);
            // 
            // btn_stoppolling
            // 
            this.btn_stoppolling.AutoSize = false;
            this.btn_stoppolling.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_stoppolling.Image = global::NoteValidatorSDKTest.Properties.Resources.stop;
            this.btn_stoppolling.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_stoppolling.Name = "btn_stoppolling";
            this.btn_stoppolling.Size = new System.Drawing.Size(50, 50);
            this.btn_stoppolling.Text = "Stop polling";
            this.btn_stoppolling.Click += new System.EventHandler(this.btn_stoppolling_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbl_timer});
            this.statusStrip1.Location = new System.Drawing.Point(0, 607);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(982, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lbl_timer
            // 
            this.lbl_timer.Name = "lbl_timer";
            this.lbl_timer.Size = new System.Drawing.Size(0, 17);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 629);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.Text = "Note Validator SDK Test";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btn_scan;
        private System.Windows.Forms.ToolStripButton btn_error;
        private System.Windows.Forms.ToolStripButton btn_startpolling;
        private System.Windows.Forms.ToolStripButton btn_pollselected;
        private System.Windows.Forms.ToolStripButton btn_stoppolling;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lbl_timer;
        private System.Windows.Forms.Timer timer1;
    }
}

