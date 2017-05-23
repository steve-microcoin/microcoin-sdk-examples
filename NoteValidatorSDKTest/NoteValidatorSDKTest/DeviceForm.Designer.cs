namespace NoteValidatorSDKTest
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
            this.components = new System.ComponentModel.Container();
            this.btn_sendtocash = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_inescrow = new System.Windows.Forms.TextBox();
            this.txt_incashbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_return = new System.Windows.Forms.Button();
            this.btn_isalive = new System.Windows.Forms.Button();
            this.lst_log = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_isenabled = new System.Windows.Forms.Button();
            this.chk_markforpolling = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lbl_timer = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_sendtocash
            // 
            this.btn_sendtocash.Enabled = false;
            this.btn_sendtocash.Location = new System.Drawing.Point(250, 17);
            this.btn_sendtocash.Name = "btn_sendtocash";
            this.btn_sendtocash.Size = new System.Drawing.Size(100, 23);
            this.btn_sendtocash.TabIndex = 0;
            this.btn_sendtocash.Text = "Send to cashbox";
            this.btn_sendtocash.UseVisualStyleBackColor = true;
            this.btn_sendtocash.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "In Escrow";
            // 
            // txt_inescrow
            // 
            this.txt_inescrow.Location = new System.Drawing.Point(82, 19);
            this.txt_inescrow.Name = "txt_inescrow";
            this.txt_inescrow.ReadOnly = true;
            this.txt_inescrow.Size = new System.Drawing.Size(151, 20);
            this.txt_inescrow.TabIndex = 2;
            // 
            // txt_incashbox
            // 
            this.txt_incashbox.Location = new System.Drawing.Point(82, 50);
            this.txt_incashbox.Name = "txt_incashbox";
            this.txt_incashbox.ReadOnly = true;
            this.txt_incashbox.Size = new System.Drawing.Size(151, 20);
            this.txt_incashbox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "In Cash box";
            // 
            // btn_return
            // 
            this.btn_return.Enabled = false;
            this.btn_return.Location = new System.Drawing.Point(380, 17);
            this.btn_return.Name = "btn_return";
            this.btn_return.Size = new System.Drawing.Size(100, 23);
            this.btn_return.TabIndex = 6;
            this.btn_return.Text = "Return";
            this.btn_return.UseVisualStyleBackColor = true;
            this.btn_return.Click += new System.EventHandler(this.btn_return_Click);
            // 
            // btn_isalive
            // 
            this.btn_isalive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_isalive.Location = new System.Drawing.Point(12, 405);
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
            this.lst_log.Location = new System.Drawing.Point(44, 112);
            this.lst_log.Name = "lst_log";
            this.lst_log.Size = new System.Drawing.Size(436, 277);
            this.lst_log.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Device Log";
            // 
            // btn_isenabled
            // 
            this.btn_isenabled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_isenabled.Location = new System.Drawing.Point(93, 405);
            this.btn_isenabled.Name = "btn_isenabled";
            this.btn_isenabled.Size = new System.Drawing.Size(83, 23);
            this.btn_isenabled.TabIndex = 12;
            this.btn_isenabled.Text = "Is it Enabled?";
            this.btn_isenabled.UseVisualStyleBackColor = true;
            this.btn_isenabled.Click += new System.EventHandler(this.btn_isenabled_Click);
            // 
            // chk_markforpolling
            // 
            this.chk_markforpolling.AutoSize = true;
            this.chk_markforpolling.Location = new System.Drawing.Point(182, 409);
            this.chk_markforpolling.Name = "chk_markforpolling";
            this.chk_markforpolling.Size = new System.Drawing.Size(98, 17);
            this.chk_markforpolling.TabIndex = 13;
            this.chk_markforpolling.Text = "Mark for polling";
            this.chk_markforpolling.UseVisualStyleBackColor = true;
            this.chk_markforpolling.CheckedChanged += new System.EventHandler(this.chk_markforpolling_CheckedChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbl_timer});
            this.statusStrip1.Location = new System.Drawing.Point(0, 429);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(534, 22);
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lbl_timer
            // 
            this.lbl_timer.Name = "lbl_timer";
            this.lbl_timer.Size = new System.Drawing.Size(0, 17);
            // 
            // DeviceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 451);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.chk_markforpolling);
            this.Controls.Add(this.btn_isenabled);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lst_log);
            this.Controls.Add(this.btn_isalive);
            this.Controls.Add(this.btn_return);
            this.Controls.Add(this.txt_incashbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_inescrow);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_sendtocash);
            this.MinimumSize = new System.Drawing.Size(550, 490);
            this.Name = "DeviceForm";
            this.Text = "DeviceForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DeviceForm_FormClosed);
            this.Load += new System.EventHandler(this.DeviceForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_sendtocash;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_inescrow;
        private System.Windows.Forms.TextBox txt_incashbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_return;
        private System.Windows.Forms.Button btn_isalive;
        private System.Windows.Forms.ListBox lst_log;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_isenabled;
        private System.Windows.Forms.CheckBox chk_markforpolling;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lbl_timer;
    }
}