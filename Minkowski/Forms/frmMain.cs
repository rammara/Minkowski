using Minkowski.Code;
using Minkowski.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Minkowski
{
    public partial class frmMain : Form
    {

        /// <summary>
        /// Calculator object
        /// </summary>
        private Calc m_calc;

        /// <summary>
        /// Viewport
        /// </summary>
        private RectangleF ViewPort;
        private string DebugMessage { get; set; }

        private float ScrollStep { get; set; } = 0.5f;


        public frmMain()
        {
            InitializeComponent();
            this.m_calc = new Calc() { Velocity = 0 };
            this.m_calc.CollectionChanged += new EventHandler(this.Calc_CollectionChanged);

            this.ViewPort = new RectangleF(Settings.DefaultViewportLeft, Settings.DefaultViewportTop,
                                           Settings.DefaultViewportWidth, Settings.DefaultViewportHeight);
            
        } // frmMain constructor


        private void Calc_CollectionChanged(object sender, EventArgs e)
        {
            foreach (var ctl in this.flowEvents.Controls.OfType<SpaceTimeEventControl>())
            {
                ctl.DeleteClick -= this.Event_Deleted;
                ctl.ValueChanged -= this.Event_Changed;
                ctl.Dispose();
            }
            this.flowEvents.Controls.Clear();
            foreach (SpaceTimeEvent evt in this.m_calc)
            {
                SpaceTimeEventControl ctl = new SpaceTimeEventControl(evt);
                ctl.DeleteClick += new EventHandler(this.Event_Deleted);
                ctl.ValueChanged += new EventHandler(this.Event_Changed);
                this.flowEvents.Controls.Add(ctl);
            } // foreach
            this.picDisplay.Invalidate();
        } // Calc_CollectionChanged

        private void Event_Deleted(object sender, EventArgs e)
        {
            SpaceTimeEvent evt = ((SpaceTimeEventControl)sender).SpaceTimeEvent;
            this.m_calc.Delete(evt);
            this.picDisplay.Invalidate();
        } // EventDeleted

        private void Event_Changed(object sender, EventArgs e)
        {
            this.picDisplay.Invalidate();
        } // Event_Changed

        #region "Interface Events"
        private void trackVelocity_Scroll(object sender, EventArgs e)
        {
            double velocity = ((TrackBar)sender).Value / 100.0D;
            OnVelocityChanged(velocity);
        } // trackVelocity_Scroll

        private void txtVelocity_Validating(object sender, CancelEventArgs e)
        {
            string input = ((TextBox)sender).Text;
            // Replace delimiter comma with dot for custom locales
            input = input.Replace(',', '.');
            NumberStyles style = NumberStyles.Float;
            e.Cancel = !double.TryParse(input, style, CultureInfo.InvariantCulture, out double velocity);
            if (!e.Cancel) OnVelocityChanged(velocity);
        } // txtVelocity_Validating

        private void picDisplay_Paint(object sender, PaintEventArgs e)
        {
            DrawBoard(e.Graphics);
        } // picDisplay_Paint

        /// <summary>
        /// Crude replacement for this.ActiveControl 
        /// </summary>
        private Control FocusedControl { get; set; }
        private void Control_Focus(object sender, EventArgs e)
        {
            this.FocusedControl = (Control) sender;
        } // Textbox_Focus

        private void Control_LostFocus(object sender, EventArgs e)
        {
            this.FocusedControl = null;
        } // Textbox_LostFocus

        #region "Drag & Pan"
        private bool m_PicDrag = false;
        private PointF m_DragOrigin;
        private void picDisplay_MouseDown(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left == e.Button)
            {
                this.m_PicDrag = true;
                this.m_DragOrigin = new PointF(e.X, e.Y);
            }
        } // picDisplay_MouseDown

        private void picDisplay_MouseUp(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left == e.Button)
            {
                this.m_PicDrag = false;
            }
        } // picDisplay_MouseUp

        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left == e.Button && this.m_PicDrag)
            {
                PictureBox pic = (PictureBox)sender;
                float scaleX = ((float)this.ViewPort.Width) / pic.ClientSize.Width;
                float scaleY = -((float)this.ViewPort.Height) / pic.ClientSize.Height;
                float deltaX = (e.X - this.m_DragOrigin.X);
                float deltaY = (e.Y - this.m_DragOrigin.Y);
                this.ViewPort.X -= deltaX * scaleX;
                this.ViewPort.Y -= deltaY * scaleY;
                this.m_DragOrigin = new PointF(e.X, e.Y);
                pic.Invalidate();
            }
        } // picDisplay_MouseMove

        private void PicDisplay_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            float deltaX = (this.ViewPort.Width * Settings.ZoomPercent);
            float deltaY = (this.ViewPort.Height * Settings.ZoomPercent);

            if (e.Delta > 0)
            {
                this.ViewPort.X += deltaX / 2.0f;
                this.ViewPort.Width -= deltaX;
                this.ViewPort.Y -= deltaY / 2.0f;
                this.ViewPort.Height -= deltaY;
            }
            else
            {
                this.ViewPort.X -= deltaX / 2.0f;
                this.ViewPort.Width += deltaX;
                this.ViewPort.Y += deltaY / 2.0f;
                this.ViewPort.Height += deltaY;
            }
            this.picDisplay.Invalidate();
        } // PicDisplay_MouseWheel
        #endregion "Drag & Pan"

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            float stepSize = e.Shift ? this.ScrollStep / 10.0f : this.ScrollStep;
            if (null == this.FocusedControl)
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                    case Keys.NumPad8:
                        this.ViewPort.Y = this.ViewPort.Top - stepSize;
                        e.Handled = true;
                        break;
                    case Keys.Down:
                    case Keys.NumPad2:
                        this.ViewPort.Y = this.ViewPort.Top + stepSize;
                        e.Handled = true;
                        break;
                    case Keys.Left:
                    case Keys.NumPad4:
                        this.ViewPort.X = this.ViewPort.Left + stepSize;
                        e.Handled = true;
                        break;
                    case Keys.Right:
                    case Keys.NumPad6:
                        this.ViewPort.X = this.ViewPort.Left - stepSize;
                        e.Handled = true;
                        break;
                    case Keys.Home:
                        this.ViewPort = new RectangleF(Settings.DefaultViewportLeft, Settings.DefaultViewportTop,
                                                        Settings.DefaultViewportWidth, Settings.DefaultViewportHeight);
                        break;
                }
                this.picDisplay.Invalidate();
            }
        } // frmMain_KeyDown
        private void btnReset_Click(object sender, EventArgs e)
        {
            this.trackVelocity.Value = 0;
            OnVelocityChanged(0d);
        }
        #endregion "Interface events"


        private void OnVelocityChanged(double vel)
        {
            if (vel == 1D) vel = 0.99999999D;
            else if (vel == -1D) vel = -0.99999999D;

            this.txtVelocity.Text = vel.ToString("0.00", CultureInfo.InvariantCulture);
            this.m_calc.Velocity = vel;
            this.picDisplay.Invalidate();
        } // OnVelocityChanged

        private void DrawBoard(Graphics g)
        {
            if (null != this.DebugMessage)
            {
                g.DrawString(this.DebugMessage, this.Font, Brushes.White, new Point(0, 0));
            }


            // Invert Y axis
            float scaleX = g.ClipBounds.Width / this.ViewPort.Width;
            float scaleY = g.ClipBounds.Height / this.ViewPort.Height;


            float PixelWidth = Math.Max(1/scaleX, 1/scaleY);
            Pen pixelPen = new Pen(Settings.BaseAxiiColor, PixelWidth * 1.5f);

            Font baseFont = new Font(this.Font.FontFamily, Settings.FontSize * PixelWidth);
            Font italicFont = new Font(this.Font.FontFamily, Settings.FontSize * PixelWidth, FontStyle.Italic);

            // Set up transformations
            g.ScaleTransform(scaleX, -scaleY);
            g.TranslateTransform(-this.ViewPort.X, -this.ViewPort.Y);


            if (Settings.ShowGrids)
            {
                // Draw basic Grid
                pixelPen.DashStyle = DashStyle.Solid;
                pixelPen.Color = Settings.BaseGridColor;
                float sX, sY;
                for (double x = Math.Floor(this.ViewPort.X) ; x < (this.ViewPort.X + this.ViewPort.Width) ; x += 1f)
                {
                    sX = Convert.ToSingle(x);
                    g.DrawLine(pixelPen, sX, this.ViewPort.Y, sX, this.ViewPort.Y - this.ViewPort.Height);
                    if (this.m_calc.Velocity != 0)
                    {
                        List<PointF> points = new List<PointF>();
                        for (double y = Math.Floor(this.ViewPort.Y) ; y > (this.ViewPort.Y - this.ViewPort.Height) ; y -= 1f)
                        {
                            sY = Convert.ToSingle(y);
                            points.Add(this.m_calc.TransformPoint(new PointF(sX, sY)));
                        }
                        pixelPen.Color = Settings.RelativisticGridColor;
                        g.DrawCurve(pixelPen, points.ToArray());
                    }
                } // for x
                pixelPen.Color = Settings.BaseGridColor;
                for (double y = Math.Floor(this.ViewPort.Y) ; y > (this.ViewPort.Y - this.ViewPort.Height) ; y -= 1f)
                {
                    sY = Convert.ToSingle(y);
                    g.DrawLine(pixelPen, this.ViewPort.X, sY, this.ViewPort.X + this.ViewPort.Width, sY);
                    if (this.m_calc.Velocity != 0)
                    {
                        List<PointF> points = new List<PointF>();
                        for (double x = Math.Floor(this.ViewPort.X) ; x < (this.ViewPort.X + this.ViewPort.Width) ; x += 1f)
                        {
                            sX = Convert.ToSingle(x);
                            points.Add(this.m_calc.TransformPoint(new PointF(sX, sY)));
                        } // for x
                        pixelPen.Color = Settings.RelativisticGridColor;
                        g.DrawCurve(pixelPen, points.ToArray());
                    }
                } // for y
            }

            pixelPen.Color = Settings.BaseAxiiColor;
            // Arrow cap fox axii
            AdjustableArrowCap bigArrow = new AdjustableArrowCap(Settings.ArrowCapSize, Settings.ArrowCapSize);

            pixelPen.SetLineCap(LineCap.Flat, LineCap.ArrowAnchor, DashCap.Flat);
            pixelPen.CustomEndCap = bigArrow;

            // Draw a base spatial axis

            PointF startX = new PointF(this.ViewPort.X, 0f);
            PointF endX = new PointF(this.ViewPort.X + this.ViewPort.Width, 0f);
            g.DrawLine(pixelPen, startX, endX);

            // Draw a base time axis
            PointF startT = new PointF(0f, this.ViewPort.Y - this.ViewPort.Height);
            PointF endT = new PointF(0f, this.ViewPort.Y);
            g.DrawLine(pixelPen, startT, endT);

            pixelPen.Color = Settings.RelativisticAxiiColor;


            // Draw a transformed spatial axis
            startX = this.m_calc.TransformPoint(startX);
            endX = this.m_calc.TransformPoint(endX);

            // this.DebugMessage = $"from {startX.X}:{startX.Y} to {endX.X}:{endX.Y}";

            float tan = endX.Y / endX.X;
            endX.X = this.ViewPort.X + this.ViewPort.Width;
            endX.Y = endX.X * tan;

            startX.X = this.ViewPort.X;
            startX.Y = startX.X * tan;


            g.DrawLine(pixelPen, startX, endX);

            // Draw a transformed time axis
            startT = this.m_calc.TransformPoint(startT);
            endT = this.m_calc.TransformPoint(endT);

            tan = endT.X / endT.Y;
            endT.Y = this.ViewPort.Y;
            endT.X = endT.Y * tan;

            startT.Y = this.ViewPort.Y - this.ViewPort.Height;
            startT.X = startT.Y * tan;


            /*float ratioY = endT.Y / (this.ViewPort.Top);
            endT.Y = this.ViewPort.Top;
            endT.X = this.ViewPort.X * ratioY;*/

            g.DrawLine(pixelPen, startT, endT);

            pixelPen.SetLineCap(LineCap.Flat, LineCap.Flat, DashCap.Round);
            pixelPen.Color = Settings.LightConeColor;
            // Draw light cones

            float min = Math.Min(this.ViewPort.X, this.ViewPort.Y);
            float max = Math.Max(this.ViewPort.X + this.ViewPort.Width, this.ViewPort.Y - this.ViewPort.Height);
            pixelPen.Width = Convert.ToSingle(PixelWidth * 0.5f);
            g.DrawLine(pixelPen, new PointF(min, min), new PointF(max, max));
            g.DrawLine(pixelPen, new PointF(min, -min), new PointF(max, -max));

            string axisname = "space";
            SizeF labelsize = g.MeasureString(axisname, baseFont);
            // Pen textPen = new Pen(Color.White, PixelWidth * 1.5f);
            g.ScaleTransform(1f, -1f);
            g.DrawString(axisname, italicFont, new SolidBrush(Settings.BaseAxiiColor), this.ViewPort.X + this.ViewPort.Width - labelsize.Width, 0f);

            axisname = "time (ct)";
            g.DrawString(axisname, italicFont, new SolidBrush(Settings.BaseAxiiColor), 0.05f, -this.ViewPort.Y);
            g.ScaleTransform(1f, -1f);


            // Draw Original events
            if (this.m_calc.Velocity != 0)
            {
                foreach (SpaceTimeEvent evt in this.m_calc)
                {
                    Color newColor = Color.FromArgb(128, evt.Color.R, evt.Color.G, evt.Color.B);
                    g.DrawEllipse(new Pen(newColor, PixelWidth),
                        Convert.ToSingle(evt.Position - (Settings.DotSize / 2.0f) * PixelWidth),
                        Convert.ToSingle(evt.Time - (Settings.DotSize / 2.0f) * PixelWidth),
                        Settings.DotSize * PixelWidth,
                        Settings.DotSize * PixelWidth);
                    if (Settings.ShowEventNames)
                    {
                        Brush textColor = new SolidBrush(newColor);
                        g.ScaleTransform(1f, -1f);
                        g.DrawString(evt.Label, baseFont, textColor, Convert.ToSingle(evt.Position + 3 * PixelWidth), Convert.ToSingle(-evt.Time + 3 * PixelWidth));
                        g.ScaleTransform(1f, -1f);
                    }
                } // foreach original evetn
            }

            // Draw transformed events
            foreach (SpaceTimeEvent evt in this.m_calc.Select(_event => this.m_calc.Transform(_event)))
            {
                g.FillEllipse(new SolidBrush(evt.Color),
                    Convert.ToSingle(evt.Position - (Settings.DotSize / 2.0f) * PixelWidth),
                    Convert.ToSingle(evt.Time - (Settings.DotSize / 2.0f) * PixelWidth),
                    Settings.DotSize * PixelWidth,
                    Settings.DotSize * PixelWidth);
                if (Settings.ShowEventNames)
                {
                    Brush textColor = new SolidBrush(evt.Color);
                    g.ScaleTransform(1f, -1f);
                    g.DrawString(evt.Label, baseFont, textColor, Convert.ToSingle(evt.Position + 3 * PixelWidth), Convert.ToSingle(-evt.Time + 3 * PixelWidth));
                    g.ScaleTransform(1f, -1f);
                }
            } // foreach

            g.ResetTransform();
            string mstr = $"v = {this.m_calc.Velocity.ToString("0.00")} c";
            Font labelFont = new Font("Times New Roman", 12, FontStyle.Italic);
            SizeF labelSize = g.MeasureString(mstr, labelFont, this.picDisplay.ClientRectangle.Width);
            g.DrawString(mstr, labelFont, new SolidBrush(Color.White), Convert.ToSingle(this.picDisplay.ClientRectangle.Width * 0.75 - labelSize.Width / 2), 0.0f);



        } // Draw

        private void picDisplay_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            PictureBox pic = (PictureBox)sender;
            double ratioX = this.ViewPort.Width / pic.ClientRectangle.Width;
            double ratioY = this.ViewPort.Height / pic.ClientRectangle.Height;

            double pos = (ratioX * e.X) + this.ViewPort.X;
            double time  = (ratioY * (pic.ClientRectangle.Height - e.Y)) + (this.ViewPort.Y - this.ViewPort.Height);

            using (frmAddEvent frm = new frmAddEvent(pos, time))
            {                
                if (DialogResult.OK == frm.ShowDialog())
                {
                    this.m_calc.Add(frm.SpaceTimeEvent);
                }
            } // using frm  
        } // picDisplay_MouseDoubleClick

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (frmAddEvent frm = new frmAddEvent(0.0D, 0.0D))
            {
                if (DialogResult.OK == frm.ShowDialog())
                {
                    this.m_calc.Add(frm.SpaceTimeEvent);
                }
            } // using frm  
        } // btnAdd_Click

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Delete all spacetime events?", "Clear",  MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                this.m_calc.Clear();
            }
        } // btnClear_Click
    } // class frmMain
} // namespace
