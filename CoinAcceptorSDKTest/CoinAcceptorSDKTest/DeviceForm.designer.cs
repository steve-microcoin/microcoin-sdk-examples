namespace CoinAcceptorSDKTest
{
    partial class DeviceForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_lastaccepted = new System.Windows.Forms.TextBox();
            this.txt_incashbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_isalive = new System.Windows.Forms.Button();
            this.lst_log = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_isenabled = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Last accepted coin";
            // 
            // txt_lastaccepted
            // 
            this.txt_lastaccepted.Location = new System.Drawing.Point(129, 19);
            this.txt_lastaccepted.Name = "txt_lastaccepted";
            this.txt_lastaccepted.ReadOnly = true;
            this.txt_lastaccepted.Size = new System.Drawing.Size(151, 20);
            this.txt_lastaccepted.TabIndex = 2;
            // 
            // txt_incashbox
            // 
            this.txt_incashbox.Location = new System.Drawing.Point(129, 57);
            this.txt_incashbox.Name = "txt_incashbox";
            this.txt_incashbox.ReadOnly = true;
            this.txt_incashbox.Size = new System.Drawing.Size(151, 20);
            this.txt_incashbox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "In Cash box";
            // 
            // btn_isalive
            // 
            this.btn_isalive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_isalive.Location = new System.Drawing.Point(12, 416);
            this.btn_isalive.Name = "btn_isalive";
            this.btn_isalive.Size = new System.Drawing.Size(75, 23);
            this.btn_isalive.TabIndex = 7;
            this.btn_isalive.Text = "Is it Alive?";
            this.btn_isalive.UseVisualStyleBackColor = true;
            this.btn_isalive.Click += new System.EventHandler(this.btn_isalive_Click);
            // 
            // lst_log
            // 
            this.lst_log.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lst_log.FormattingEnabled = true;
            this.lst_log.HorizontalScrollbar = true;
            this.lst_log.Location = new System.Drawing.Point(44, 123);
            this.lst_log.Name = "lst_log";
            this.lst_log.Size = new System.Drawing.Size(436, 277);
            this.lst_log.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Device Log";
            // 
            // btn_isenabled
            // 
            this.btn_isenabled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_isenabled.Location = new System.Drawing.Point(93, 416);
            this.btn_isenabled.Name = "btn_isenabled";
            this.btn_isenabled.Size = new System.Drawing.Size(83, 23);
            this.btn_isenabled.TabIndex = 12;
            this.btn_isenabled.Text = "Is it Enabled?";
            this.btn_isenabled.UseVisualStyleBackColor = true;
            this.btn_isenabled.Click += new System.EventHandler(this.btn_isenabled_Click);
            // 
            // DeviceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 451);
            this.Controls.Add(this.btn_isenabled);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lst_log);
            this.Controls.Add(this.btn_isalive);
            this.Controls.Add(this.txt_incashbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_lastaccepted);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(550, 490);
            this.Name = "DeviceForm";
            this.Text = "DeviceForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DeviceForm_FormClosed);
            this.Load += new System.EventHandler(this.DeviceForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_lastaccepted;
        private System.Windows.Forms.TextBox txt_incashbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_isalive;
        private System.Windows.Forms.ListBox lst_log;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_isenabled;
    }
}