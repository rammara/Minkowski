namespace Minkowski
{
    partial class frmAddEvent
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
            this.lblLabelTitle = new System.Windows.Forms.Label();
            this.txtLabel = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblPositionTitle = new System.Windows.Forms.Label();
            this.lblTimeTitle = new System.Windows.Forms.Label();
            this.txtPosition = new System.Windows.Forms.TextBox();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.lblColorTitle = new System.Windows.Forms.Label();
            this.picColor = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picColor)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLabelTitle
            // 
            this.lblLabelTitle.AutoSize = true;
            this.lblLabelTitle.Location = new System.Drawing.Point(13, 13);
            this.lblLabelTitle.Name = "lblLabelTitle";
            this.lblLabelTitle.Size = new System.Drawing.Size(36, 13);
            this.lblLabelTitle.TabIndex = 0;
            this.lblLabelTitle.Text = "Label:";
            // 
            // txtLabel
            // 
            this.txtLabel.Location = new System.Drawing.Point(16, 29);
            this.txtLabel.MaxLength = 12;
            this.txtLabel.Name = "txtLabel";
            this.txtLabel.Size = new System.Drawing.Size(140, 20);
            this.txtLabel.TabIndex = 1;
            this.txtLabel.Text = "<Label>";
            this.txtLabel.Validating += new System.ComponentModel.CancelEventHandler(this.txtLabel_Validating);
            this.txtLabel.Validated += new System.EventHandler(this.txtLabel_Validated);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(228, 13);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(228, 42);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblPositionTitle
            // 
            this.lblPositionTitle.AutoSize = true;
            this.lblPositionTitle.Location = new System.Drawing.Point(13, 71);
            this.lblPositionTitle.Name = "lblPositionTitle";
            this.lblPositionTitle.Size = new System.Drawing.Size(47, 13);
            this.lblPositionTitle.TabIndex = 4;
            this.lblPositionTitle.Text = "Position:";
            // 
            // lblTimeTitle
            // 
            this.lblTimeTitle.AutoSize = true;
            this.lblTimeTitle.Location = new System.Drawing.Point(13, 104);
            this.lblTimeTitle.Name = "lblTimeTitle";
            this.lblTimeTitle.Size = new System.Drawing.Size(33, 13);
            this.lblTimeTitle.TabIndex = 5;
            this.lblTimeTitle.Text = "Time:";
            // 
            // txtPosition
            // 
            this.txtPosition.Location = new System.Drawing.Point(66, 68);
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.Size = new System.Drawing.Size(90, 20);
            this.txtPosition.TabIndex = 6;
            this.txtPosition.Text = "0.0000";
            this.txtPosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPosition.Validating += new System.ComponentModel.CancelEventHandler(this.txtPosition_Validating);
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(66, 101);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(90, 20);
            this.txtTime.TabIndex = 7;
            this.txtTime.Text = "0.0000";
            this.txtTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTime.Validating += new System.ComponentModel.CancelEventHandler(this.txtTime_Validating);
            // 
            // lblColorTitle
            // 
            this.lblColorTitle.AutoSize = true;
            this.lblColorTitle.Location = new System.Drawing.Point(14, 135);
            this.lblColorTitle.Name = "lblColorTitle";
            this.lblColorTitle.Size = new System.Drawing.Size(34, 13);
            this.lblColorTitle.TabIndex = 8;
            this.lblColorTitle.Text = "Color:";
            // 
            // picColor
            // 
            this.picColor.BackColor = System.Drawing.Color.Red;
            this.picColor.Location = new System.Drawing.Point(66, 135);
            this.picColor.Name = "picColor";
            this.picColor.Size = new System.Drawing.Size(24, 24);
            this.picColor.TabIndex = 9;
            this.picColor.TabStop = false;
            this.picColor.Click += new System.EventHandler(this.picColor_Click);
            // 
            // frmAddEvent
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(311, 178);
            this.ControlBox = false;
            this.Controls.Add(this.picColor);
            this.Controls.Add(this.lblColorTitle);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.txtPosition);
            this.Controls.Add(this.lblTimeTitle);
            this.Controls.Add(this.lblPositionTitle);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtLabel);
            this.Controls.Add(this.lblLabelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmAddEvent";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add event";
            ((System.ComponentModel.ISupportInitialize)(this.picColor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLabelTitle;
        private System.Windows.Forms.TextBox txtLabel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblPositionTitle;
        private System.Windows.Forms.Label lblTimeTitle;
        private System.Windows.Forms.TextBox txtPosition;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.Label lblColorTitle;
        private System.Windows.Forms.PictureBox picColor;
    }
}