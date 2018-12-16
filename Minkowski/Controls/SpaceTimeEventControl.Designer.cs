namespace Minkowski.Controls
{
    partial class SpaceTimeEventControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblNameTitle = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblPosTitle = new System.Windows.Forms.Label();
            this.txtPosition = new System.Windows.Forms.TextBox();
            this.lblTimeTitle = new System.Windows.Forms.Label();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.picColor = new System.Windows.Forms.PictureBox();
            this.lblColorTitle = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnDiscard = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picColor)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.AutoSize = true;
            this.lblNameTitle.Location = new System.Drawing.Point(13, 15);
            this.lblNameTitle.Name = "lblNameTitle";
            this.lblNameTitle.Size = new System.Drawing.Size(36, 13);
            this.lblNameTitle.TabIndex = 0;
            this.lblNameTitle.Text = "Label:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(16, 32);
            this.txtName.MaxLength = 12;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(128, 20);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            this.txtName.Validated += new System.EventHandler(this.Value_Validated);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(156, 30);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblPosTitle
            // 
            this.lblPosTitle.AutoSize = true;
            this.lblPosTitle.Location = new System.Drawing.Point(14, 65);
            this.lblPosTitle.Name = "lblPosTitle";
            this.lblPosTitle.Size = new System.Drawing.Size(47, 13);
            this.lblPosTitle.TabIndex = 3;
            this.lblPosTitle.Text = "Position:";
            // 
            // txtPosition
            // 
            this.txtPosition.Location = new System.Drawing.Point(67, 62);
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.Size = new System.Drawing.Size(77, 20);
            this.txtPosition.TabIndex = 4;
            this.txtPosition.Text = "0.0000";
            this.txtPosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPosition.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            this.txtPosition.Validating += new System.ComponentModel.CancelEventHandler(this.Value_Validating);
            this.txtPosition.Validated += new System.EventHandler(this.Value_Validated);
            // 
            // lblTimeTitle
            // 
            this.lblTimeTitle.AutoSize = true;
            this.lblTimeTitle.Location = new System.Drawing.Point(13, 93);
            this.lblTimeTitle.Name = "lblTimeTitle";
            this.lblTimeTitle.Size = new System.Drawing.Size(33, 13);
            this.lblTimeTitle.TabIndex = 5;
            this.lblTimeTitle.Text = "Time:";
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(67, 90);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(77, 20);
            this.txtTime.TabIndex = 6;
            this.txtTime.Text = "0.0000";
            this.txtTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            this.txtTime.Validating += new System.ComponentModel.CancelEventHandler(this.Value_Validating);
            this.txtTime.Validated += new System.EventHandler(this.Value_Validated);
            // 
            // picColor
            // 
            this.picColor.Location = new System.Drawing.Point(67, 116);
            this.picColor.Name = "picColor";
            this.picColor.Size = new System.Drawing.Size(24, 24);
            this.picColor.TabIndex = 7;
            this.picColor.TabStop = false;
            this.picColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // lblColorTitle
            // 
            this.lblColorTitle.AutoSize = true;
            this.lblColorTitle.Location = new System.Drawing.Point(13, 122);
            this.lblColorTitle.Name = "lblColorTitle";
            this.lblColorTitle.Size = new System.Drawing.Size(34, 13);
            this.lblColorTitle.TabIndex = 9;
            this.lblColorTitle.Text = "Color:";
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(156, 88);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 10;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Visible = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnDiscard
            // 
            this.btnDiscard.Location = new System.Drawing.Point(156, 117);
            this.btnDiscard.Name = "btnDiscard";
            this.btnDiscard.Size = new System.Drawing.Size(75, 23);
            this.btnDiscard.TabIndex = 11;
            this.btnDiscard.Text = "Discard";
            this.btnDiscard.UseVisualStyleBackColor = true;
            this.btnDiscard.Visible = false;
            this.btnDiscard.Click += new System.EventHandler(this.btnDiscard_Click);
            // 
            // SpaceTimeEventControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDiscard);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.lblColorTitle);
            this.Controls.Add(this.picColor);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.lblTimeTitle);
            this.Controls.Add(this.txtPosition);
            this.Controls.Add(this.lblPosTitle);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblNameTitle);
            this.Name = "SpaceTimeEventControl";
            this.Size = new System.Drawing.Size(240, 158);
            ((System.ComponentModel.ISupportInitialize)(this.picColor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNameTitle;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblPosTitle;
        private System.Windows.Forms.TextBox txtPosition;
        private System.Windows.Forms.Label lblTimeTitle;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.PictureBox picColor;
        private System.Windows.Forms.Label lblColorTitle;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnDiscard;
    }
}
