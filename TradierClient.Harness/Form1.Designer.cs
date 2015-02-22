namespace TradierClient.Harness
{
    partial class Form1
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
            this.label3 = new System.Windows.Forms.Label();
            this.cmbMessageFormat = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbApiCall = new System.Windows.Forms.ComboBox();
            this.pnlControlContainer = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Message Format:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbMessageFormat
            // 
            this.cmbMessageFormat.FormattingEnabled = true;
            this.cmbMessageFormat.Items.AddRange(new object[] {
            "JSON",
            "XML"});
            this.cmbMessageFormat.Location = new System.Drawing.Point(106, 6);
            this.cmbMessageFormat.Name = "cmbMessageFormat";
            this.cmbMessageFormat.Size = new System.Drawing.Size(121, 21);
            this.cmbMessageFormat.TabIndex = 4;
            this.cmbMessageFormat.SelectedIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(249, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "API Call:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbApiCall
            // 
            this.cmbApiCall.FormattingEnabled = true;
            this.cmbApiCall.Items.AddRange(new object[] {
            "Market/Get Historical Pricing",
            "Market/Get Intraday Status",
            "Market/Get Option Chain",
            "Market/Get Option Expirations",
            "Market/Get Option Strikes",
            "Market/Get Quotes",
            "Market/Get Time And Sales"});
            this.cmbApiCall.Location = new System.Drawing.Point(305, 6);
            this.cmbApiCall.Name = "cmbApiCall";
            this.cmbApiCall.Size = new System.Drawing.Size(380, 21);
            this.cmbApiCall.TabIndex = 6;
            this.cmbApiCall.SelectedIndexChanged +=cmbApiCall_SelectedIndexChanged;
            // 
            // pnlControlContainer
            // 
            this.pnlControlContainer.Location = new System.Drawing.Point(15, 45);
            this.pnlControlContainer.Name = "pnlControlContainer";
            this.pnlControlContainer.Size = new System.Drawing.Size(670, 433);
            this.pnlControlContainer.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 490);
            this.Controls.Add(this.pnlControlContainer);
            this.Controls.Add(this.cmbApiCall);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbMessageFormat);
            this.Controls.Add(this.label3);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbMessageFormat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbApiCall;
        private System.Windows.Forms.Panel pnlControlContainer;
    }
}

