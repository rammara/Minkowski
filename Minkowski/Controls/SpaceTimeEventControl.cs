using Minkowski.Code;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Minkowski.Controls
{
    public partial class SpaceTimeEventControl : UserControl
    {

        public event EventHandler DeleteClick;
        public event EventHandler ValueChanged;

        protected void OnDeleteClick()
        {
            this.DeleteClick?.Invoke(this, new EventArgs());
        } // OnDeleteClick

        protected void OnValueChanged()
        {
            this.ValueChanged?.Invoke(this, new EventArgs());
        } // OnValueChanged

        private SpaceTimeEvent m_event;
        public SpaceTimeEventControl(SpaceTimeEvent evt)
        {
            InitializeComponent();
            this.m_event = evt;
            UpdateValues();
        } // SpaceTimeEventControl ctor

        public string Label
        {
            get => this.m_event.Label;
            set { this.m_event.Label = value; UpdateValues(); }
        } // label

        public Color Color
        {
            get => this.m_event.Color;
            set { this.m_event.Color = value; UpdateValues(); }
        } // Color

        public Double Position
        {
            get => this.m_event.Position;
            set { this.m_event.Position = value; UpdateValues(); }
        } // Position

        public double Time
        {
            get => this.m_event.Time;
            set { this.m_event.Time = value; UpdateValues(); }
        } // Time

        public SpaceTimeEvent SpaceTimeEvent
        {
            get => this.m_event;
            set
            {
                this.m_event = value;
                UpdateValues();
            } // set
        } // Event

        protected void UpdateValues()
        {
            this.changedTime = null;
            this.changedPos = null;
            this.changedName = null;
            this.picColor.BackColor = this.m_event.Color;
            this.txtName.Text = this.m_event.Label;
            this.txtPosition.Text = this.m_event.Position.ToString("0.0000");
            this.txtTime.Text = this.m_event.Time.ToString("0.0000");
            this.btnApply.Visible = false;
            this.btnDiscard.Visible = false;
        } // void UpdateValues

        private void btnColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog dlg = new ColorDialog())
            {
                DialogResult ret = dlg.ShowDialog();
                if (DialogResult.OK == ret)
                {
                    this.picColor.BackColor = dlg.Color;
                    this.btnApply.Visible = true;
                    this.btnDiscard.Visible = true;
                }
            } // using
        } // btnColor_Click

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show($"Delete event {this.Name}?", "Event delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                OnDeleteClick();
            }
        } // btnDelete_Click

        private double? changedPos = null;
        private double? changedTime = null;
        private string changedName = null;

        private void Value_Validating(object sender, CancelEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            // Decimal point substitute
            string value = txt.Text.Replace(",",".");
            NumberStyles style = NumberStyles.Number;
            if (!double.TryParse(value, style, CultureInfo.InvariantCulture, out double val))
            {
                if (txt == this.txtPosition) this.txtPosition.Text = this.m_event.Position.ToString("0.0000");
                else if (txt == this.txtTime) this.txtTime.Text = this.m_event.Time.ToString("0.0000");
                this.btnApply.Visible = false;
                this.btnDiscard.Visible = false;
            }
            else
            {
                if (txt == this.txtPosition)
                {
                    this.changedPos = val;
                    this.txtPosition.Text = val.ToString("0.0000");
                }
                else if (txt == this.txtTime)
                {
                    this.changedTime = val;
                    this.txtTime.Text = val.ToString("0.0000");
                }
                this.btnApply.Visible = true;
                this.btnDiscard.Visible = true;
            }
        } // Value_Validating

        private void Value_Validated(object sender, EventArgs e)
        {
            if (((TextBox) sender) == this.txtName) this.changedName = this.txtName.Text; else this.changedName = null;
            this.btnApply.Visible = true;
            this.btnDiscard.Visible = true;
        } // Value_Validated

        private void btnApply_Click(object sender, EventArgs e)
        {
            this.m_event.Label = changedName ?? this.m_event.Label;
            this.m_event.Position = changedPos ?? this.m_event.Position;
            this.m_event.Time = changedTime ?? this.m_event.Time;
            this.m_event.Color = this.picColor.BackColor;
            OnValueChanged();
            UpdateValues();
        } // btnApply_Click

        private void btnDiscard_Click(object sender, EventArgs e)
        {
            UpdateValues();
        } // btnDiscard_Click

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            this.changedName = this.txtName.Text;
            this.btnApply.Visible = true;
            this.btnDiscard.Visible = true;
        } // txtName_TextChanged

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int) Keys.Return == e.KeyChar)
            {
                this.Value_Validating(sender, new CancelEventArgs());
            }
        } // txt_KeyPress
    } // class SpaceTimeEventControl
} // namespace
