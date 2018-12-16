using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minkowski.Code
{
    public class Calc : IEnumerable<SpaceTimeEvent>
    {
        private List<SpaceTimeEvent> m_objList = new List<SpaceTimeEvent>();



        /// <summary>
        /// Speed of Light
        /// </summary>
        public const double C = 299792458D;

        /// <summary>
        /// Squared speed of light
        /// </summary>
        public const double Csquared = 89875517873681764D;

        public event EventHandler CollectionChanged;

        public void OnCollectionChanged()
        {
            this.CollectionChanged?.Invoke(this, new EventArgs());
        } // OnCollectionChanged

        public void Clear()
        {
            this.m_objList.Clear();
            OnCollectionChanged();
        } // Clear

        public void Add(SpaceTimeEvent evt)
        {
            this.m_objList.Add(evt);
            OnCollectionChanged();
        } // Add

        public void Delete(SpaceTimeEvent evt)
        {
            this.m_objList.Remove(evt);
            OnCollectionChanged();
        } // Delete        

        /// <summary>
        /// Performs a Lorentz transform of a spacetime event
        /// </summary>
        /// <param name="v">velocity</param>
        /// <param name="e">spacetime event</param>
        /// <returns></returns>
        public SpaceTimeEvent Transform(SpaceTimeEvent e)
        {
            
            SpaceTimeEvent transformed = new SpaceTimeEvent()
            {
                Label = e.Label + "'",
                Position =  (this.m_gamma * (e.Position - this.Velocity * e.Time)),
                Time = (this.m_gamma * (e.Time - (this.Velocity * Csquared * e.Position) / Csquared)),
                Color = e.Color
            };
            return transformed;            
        } // Transform


        public PointF TransformPoint(float x, float y)
        {
            PointF result = new PointF(Convert.ToSingle(this.m_gamma * (x - this.Velocity * y)),
                Convert.ToSingle(this.m_gamma * (y - (this.Velocity * Csquared * x ) / Csquared)));
            return result;
        } // TransformPoint

        public PointF TransformPoint(PointF point)
        {
            return TransformPoint(point.X, point.Y);
        } // TransformPoint

        private double m_gamma = 0D;
        public double Gamma(double v)
        {
            v = v * C;
            double result = 1 / (Math.Sqrt(1 - v*v/Csquared));
            return result;
        } // gamma

        /// <summary>
        /// Gets or sets the velocity parameter for calculation
        /// </summary>
        private double m_velocity = 0D;
        public double Velocity
        {
            get => this.m_velocity;
            set
            {
                this.m_velocity = value;
                this.m_gamma = this.Gamma(value);
            }
        }



        #region "IEnumerable"
        public IEnumerator<SpaceTimeEvent> GetEnumerator()
        {
            return ((IEnumerable<SpaceTimeEvent>) this.m_objList).GetEnumerator();
        } // GetEnumerator

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<SpaceTimeEvent>) this.m_objList).GetEnumerator();
        } // GetEnumerator
        #endregion "IEnumerable"
    } // class Calc
} // namespace
