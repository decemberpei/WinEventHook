
using System;

namespace WinEventHook
{
    partial class WinEventHook
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_action = new System.Windows.Forms.Button();
            this.txt_process_name = new System.Windows.Forms.TextBox();
            this.txt_log = new System.Windows.Forms.TextBox();
            this.txt_tip = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_action
            // 
            this.btn_action.Location = new System.Drawing.Point(30, 31);
            this.btn_action.Name = "btn_action";
            this.btn_action.Size = new System.Drawing.Size(175, 52);
            this.btn_action.TabIndex = 0;
            this.btn_action.Text = "Start";
            this.btn_action.UseVisualStyleBackColor = true;
            this.btn_action.Click += new System.EventHandler(this.btc_action_Click);
            // 
            // txt_process_name
            // 
            this.txt_process_name.Location = new System.Drawing.Point(458, 37);
            this.txt_process_name.Name = "txt_process_name";
            this.txt_process_name.Size = new System.Drawing.Size(338, 42);
            this.txt_process_name.TabIndex = 1;
            this.txt_process_name.TextChanged += new System.EventHandler(this.txt_process_name_TextChanged);
            // 
            // txt_log
            // 
            this.txt_log.Location = new System.Drawing.Point(30, 114);
            this.txt_log.Multiline = true;
            this.txt_log.Name = "txt_log";
            this.txt_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_log.Size = new System.Drawing.Size(766, 486);
            this.txt_log.TabIndex = 2;
            this.txt_log.TextChanged += new System.EventHandler(this.txt_log_TextChanged);
            // 
            // txt_tip
            // 
            this.txt_tip.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_tip.Enabled = false;
            this.txt_tip.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txt_tip.Location = new System.Drawing.Point(256, 40);
            this.txt_tip.Name = "txt_tip";
            this.txt_tip.ReadOnly = true;
            this.txt_tip.Size = new System.Drawing.Size(196, 35);
            this.txt_tip.TabIndex = 3;
            this.txt_tip.Text = "Process Name:";
            this.txt_tip.UseWaitCursor = true;
            // 
            // WinEventHook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 35F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 631);
            this.Controls.Add(this.txt_tip);
            this.Controls.Add(this.txt_log);
            this.Controls.Add(this.txt_process_name);
            this.Controls.Add(this.btn_action);
            this.Name = "WinEventHook";
            this.Text = "WinEventHook";
            this.Load += new System.EventHandler(this.Win_Main_Load);
            this.Disposed += new System.EventHandler(this.Win_Main_Dispose);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_action;
        private System.Windows.Forms.TextBox txt_process_name;
        private System.Windows.Forms.TextBox txt_log;
        private System.Windows.Forms.TextBox txt_tip;
    }
}

