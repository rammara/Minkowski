namespace Minkowski
{
    partial class frmMain
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
            this.picDisplay = new System.Windows.Forms.PictureBox();
            this.splitter = new System.Windows.Forms.SplitContainer();
            this.tblDisplayContainer = new System.Windows.Forms.TableLayoutPanel();
            this.pnlControls = new System.Windows.Forms.Panel();
            this.trackVelocity = new System.Windows.Forms.TrackBar();
            this.lblCTitle = new System.Windows.Forms.Label();
            this.txtVelocity = new System.Windows.Forms.TextBox();
            this.lblVelosityTitle = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.pnlTools = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblEventsTitle = new System.Windows.Forms.Label();
            this.flowEvents = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitter)).BeginInit();
            this.splitter.Panel1.SuspendLayout();
            this.splitter.Panel2.SuspendLayout();
            this.splitter.SuspendLayout();
            this.tblDisplayContainer.SuspendLayout();
            this.pnlControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackVelocity)).BeginInit();
            this.pnlTools.SuspendLayout();
            this.SuspendLayout();
            // 
            // picDisplay
            // 
            this.picDisplay.BackColor = System.Drawing.Color.Black;
            this.picDisplay.Cursor = System.Windows.Forms.Cursors.Cross;
            this.picDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picDisplay.Location = new System.Drawing.Point(3, 3);
            this.picDisplay.Name = "picDisplay";
            this.picDisplay.Size = new System.Drawing.Size(599, 511);
            this.picDisplay.TabIndex = 0;
            this.picDisplay.TabStop = false;
            this.picDisplay.Paint += new System.Windows.Forms.PaintEventHandler(this.picDisplay_Paint);
            this.picDisplay.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.picDisplay_MouseDoubleClick);
            this.picDisplay.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picDisplay_MouseDown);
            this.picDisplay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picDisplay_MouseMove);
            this.picDisplay.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picDisplay_MouseUp);
            this.picDisplay.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.PicDisplay_MouseWheel);
            // 
            // splitter
            // 
            this.splitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitter.Location = new System.Drawing.Point(0, 0);
            this.splitter.Name = "splitter";
            // 
            // splitter.Panel1
            // 
            this.splitter.Panel1.Controls.Add(this.pnlTools);
            this.splitter.Panel1MinSize = 128;
            // 
            // splitter.Panel2
            // 
            this.splitter.Panel2.Controls.Add(this.tblDisplayContainer);
            this.splitter.Panel2MinSize = 512;
            this.splitter.Size = new System.Drawing.Size(904, 645);
            this.splitter.SplitterDistance = 295;
            this.splitter.TabIndex = 1;
            // 
            // tblDisplayContainer
            // 
            this.tblDisplayContainer.ColumnCount = 1;
            this.tblDisplayContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblDisplayContainer.Controls.Add(this.picDisplay, 0, 0);
            this.tblDisplayContainer.Controls.Add(this.pnlControls, 0, 1);
            this.tblDisplayContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblDisplayContainer.Location = new System.Drawing.Point(0, 0);
            this.tblDisplayContainer.Name = "tblDisplayContainer";
            this.tblDisplayContainer.RowCount = 2;
            this.tblDisplayContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblDisplayContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.tblDisplayContainer.Size = new System.Drawing.Size(605, 645);
            this.tblDisplayContainer.TabIndex = 1;
            // 
            // pnlControls
            // 
            this.pnlControls.Controls.Add(this.btnReset);
            this.pnlControls.Controls.Add(this.trackVelocity);
            this.pnlControls.Controls.Add(this.lblCTitle);
            this.pnlControls.Controls.Add(this.txtVelocity);
            this.pnlControls.Controls.Add(this.lblVelosityTitle);
            this.pnlControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlControls.Location = new System.Drawing.Point(3, 520);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(599, 122);
            this.pnlControls.TabIndex = 1;
            // 
            // trackVelocity
            // 
            this.trackVelocity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackVelocity.Location = new System.Drawing.Point(162, 13);
            this.trackVelocity.Maximum = 100;
            this.trackVelocity.Minimum = -100;
            this.trackVelocity.Name = "trackVelocity";
            this.trackVelocity.Size = new System.Drawing.Size(428, 45);
            this.trackVelocity.TabIndex = 3;
            this.trackVelocity.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackVelocity.Scroll += new System.EventHandler(this.trackVelocity_Scroll);
            this.trackVelocity.Enter += new System.EventHandler(this.Control_Focus);
            this.trackVelocity.Leave += new System.EventHandler(this.Control_LostFocus);
            // 
            // lblCTitle
            // 
            this.lblCTitle.AutoSize = true;
            this.lblCTitle.Location = new System.Drawing.Point(143, 20);
            this.lblCTitle.Name = "lblCTitle";
            this.lblCTitle.Size = new System.Drawing.Size(13, 13);
            this.lblCTitle.TabIndex = 2;
            this.lblCTitle.Text = "c";
            // 
            // txtVelocity
            // 
            this.txtVelocity.Location = new System.Drawing.Point(79, 17);
            this.txtVelocity.Name = "txtVelocity";
            this.txtVelocity.ReadOnly = true;
            this.txtVelocity.Size = new System.Drawing.Size(58, 20);
            this.txtVelocity.TabIndex = 1;
            this.txtVelocity.Text = "0.00";
            this.txtVelocity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtVelocity.Enter += new System.EventHandler(this.Control_Focus);
            this.txtVelocity.Leave += new System.EventHandler(this.Control_LostFocus);
            // 
            // lblVelosityTitle
            // 
            this.lblVelosityTitle.AutoSize = true;
            this.lblVelosityTitle.Location = new System.Drawing.Point(26, 20);
            this.lblVelosityTitle.Name = "lblVelosityTitle";
            this.lblVelosityTitle.Size = new System.Drawing.Size(47, 13);
            this.lblVelosityTitle.TabIndex = 0;
            this.lblVelosityTitle.Text = "Velocity:";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(79, 43);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(58, 25);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // pnlTools
            // 
            this.pnlTools.Controls.Add(this.flowEvents);
            this.pnlTools.Controls.Add(this.lblEventsTitle);
            this.pnlTools.Controls.Add(this.btnClear);
            this.pnlTools.Controls.Add(this.btnAdd);
            this.pnlTools.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTools.Location = new System.Drawing.Point(0, 0);
            this.pnlTools.Name = "pnlTools";
            this.pnlTools.Size = new System.Drawing.Size(295, 645);
            this.pnlTools.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(174, 12);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblEventsTitle
            // 
            this.lblEventsTitle.AutoSize = true;
            this.lblEventsTitle.Location = new System.Drawing.Point(9, 54);
            this.lblEventsTitle.Name = "lblEventsTitle";
            this.lblEventsTitle.Size = new System.Drawing.Size(97, 13);
            this.lblEventsTitle.TabIndex = 3;
            this.lblEventsTitle.Text = "Spacetime evemts:";
            // 
            // flowEvents
            // 
            this.flowEvents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowEvents.AutoScroll = true;
            this.flowEvents.Location = new System.Drawing.Point(12, 70);
            this.flowEvents.Name = "flowEvents";
            this.flowEvents.Size = new System.Drawing.Size(271, 432);
            this.flowEvents.TabIndex = 4;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 645);
            this.Controls.Add(this.splitter);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmMain";
            this.Text = "Minkowski Diagrams";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).EndInit();
            this.splitter.Panel1.ResumeLayout(false);
            this.splitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitter)).EndInit();
            this.splitter.ResumeLayout(false);
            this.tblDisplayContainer.ResumeLayout(false);
            this.pnlControls.ResumeLayout(false);
            this.pnlControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackVelocity)).EndInit();
            this.pnlTools.ResumeLayout(false);
            this.pnlTools.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.PictureBox picDisplay;
        private System.Windows.Forms.SplitContainer splitter;
        private System.Windows.Forms.TableLayoutPanel tblDisplayContainer;
        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.TrackBar trackVelocity;
        private System.Windows.Forms.Label lblCTitle;
        private System.Windows.Forms.TextBox txtVelocity;
        private System.Windows.Forms.Label lblVelosityTitle;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Panel pnlTools;
        private System.Windows.Forms.Label lblEventsTitle;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.FlowLayoutPanel flowEvents;
    }
}

