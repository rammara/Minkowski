using Minkowski.Code;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

namespace Minkowski
{
    public partial class frmAddEvent : Form
    {
        public SpaceTimeEvent SpaceTimeEvent { get; set; }
        public frmAddEvent(double space = 0.0D, double time = 0.0D)
        {
            InitializeComponent();
            this.SpaceTimeEvent = new SpaceTimeEvent() { Color = this.picColor.BackColor, Label = "<Label>", Position = space, Time = time };
            this.txtPosition.Text = space.ToString("0.0000", CultureInfo.InvariantCulture);
            this.txtTime.Text = time.ToString("0.0000", CultureInfo.InvariantCulture);
        } // frmAddEvent

        private void txtTime_Validating(object sender, CancelEventArgs e)
        {
            string input = ((TextBox)sender).Text.Replace(",", ".");
            if (double.TryParse(input, NumberStyles.Number, CultureInfo.InvariantCulture, out double newtime))
            {
                this.SpaceTimeEvent.Time = newtime;
            }
            else
            {
                e.Cancel = true;
            }
        } // txtTime_Validating

        private void txtPosition_Validating(object sender, CancelEventArgs e)
        {
            string input = ((TextBox)sender).Text.Replace(",", ".");
            if (double.TryParse(input, NumberStyles.Number, CultureInfo.InvariantCulture, out double newPosition))
            {
                this.SpaceTimeEvent.Position = newPosition;
            }
            else
            {
                e.Cancel = true;
            }
        } // txtPosition_Validating

        private void picColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog dlg = new ColorDialog())
            {
                DialogResult ret = dlg.ShowDialog();
                if (DialogResult.OK == ret)
                {
                    this.picColor.BackColor = dlg.Color;
                    this.SpaceTimeEvent.Color = dlg.Color;
                }
            } // using dlg
        } // picColor_Click

        private void txtLabel_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = ((TextBox) sender).Text.Length == 0;
        } // txtLabel_Validating

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.Validate())
            {
                this.DialogResult = DialogResult.OK;
            }
        } // btnOK_Click

        private void txtLabel_Validated(object sender, EventArgs e)
        {
            this.SpaceTimeEvent.Label = ((TextBox) sender).Text;
        } // txtLabel_Validated
    } // class frmAddEvent
} // namespace
