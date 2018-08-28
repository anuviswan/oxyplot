// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RoundedRectangleAnnotation.cs" company="OxyPlot">
//   Copyright (c) 2014 OxyPlot contributors
// </copyright>
// <summary>
//   This is a WPF wrapper of OxyPlot.RoundedRectangleAnnotation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace OxyPlot.Wpf
{
    using System.Windows;

    /// <summary>
    /// This is a WPF wrapper of OxyPlot.RectangleAnnotation
    /// </summary>
    public class RoundedRectangleAnnotation : ShapeAnnotation
    {
        /// <summary>
        /// Identifies the <see cref="MaximumX"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty MaximumXProperty = DependencyProperty.Register(
            "MaximumX", typeof(double), typeof(RoundedRectangleAnnotation), new PropertyMetadata(double.MaxValue, DataChanged));

        /// <summary>
        /// Identifies the <see cref="MaximumY"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty MaximumYProperty = DependencyProperty.Register(
            "MaximumY", typeof(double), typeof(RoundedRectangleAnnotation), new PropertyMetadata(double.MaxValue, DataChanged));

        /// <summary>
        /// Identifies the <see cref="MinimumX"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty MinimumXProperty = DependencyProperty.Register(
            "MinimumX", typeof(double), typeof(RoundedRectangleAnnotation), new PropertyMetadata(double.MinValue, DataChanged));

        /// <summary>
        /// Identifies the <see cref="MinimumY"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty MinimumYProperty = DependencyProperty.Register(
            "MinimumY", typeof(double), typeof(RoundedRectangleAnnotation), new PropertyMetadata(double.MinValue, DataChanged));


        /// <summary>
        /// Identifies the <see cref="CornerRadius"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            "CornerRadius", typeof(double), typeof(RoundedRectangleAnnotation), new PropertyMetadata(double.MinValue, DataChanged));

        /// <summary>
        /// Initializes static members of the <see cref="RectangleAnnotation"/> class.
        /// </summary>
        static RoundedRectangleAnnotation()
        {
            TextColorProperty.OverrideMetadata(typeof(RoundedRectangleAnnotation), new FrameworkPropertyMetadata(MoreColors.Automatic, AppearanceChanged));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RectangleAnnotation" /> class.
        /// </summary>
        public RoundedRectangleAnnotation()
        {
            this.InternalAnnotation = new Annotations.RoundedRectangleAnnotation();
        }

        /// <summary>
        /// Gets or sets the Maximum X.
        /// </summary>
        public double MaximumX
        {
            get
            {
                return (double)this.GetValue(MaximumXProperty);
            }

            set
            {
                this.SetValue(MaximumXProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the Maximum Y.
        /// </summary>
        public double MaximumY
        {
            get
            {
                return (double)this.GetValue(MaximumYProperty);
            }

            set
            {
                this.SetValue(MaximumYProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the Minimum X.
        /// </summary>
        public double MinimumX
        {
            get
            {
                return (double)this.GetValue(MinimumXProperty);
            }

            set
            {
                this.SetValue(MinimumXProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the Minimum Y.
        /// </summary>
        public double MinimumY
        {
            get
            {
                return (double)this.GetValue(MinimumYProperty);
            }

            set
            {
                this.SetValue(MinimumYProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the Corner Radius
        /// </summary>
        public double CornerRadius
        {
            get
            {
                return (double)this.GetValue(CornerRadiusProperty);
            }
            set
            {
                this.SetValue(CornerRadiusProperty, value);
            }
        }

        /// <summary>
        /// Creates the internal annotation object.
        /// </summary>
        /// <returns>The annotation.</returns>
        public override Annotations.Annotation CreateModel()
        {
            this.SynchronizeProperties();
            return this.InternalAnnotation;
        }

        /// <summary>
        /// Synchronizes the properties.
        /// </summary>
        public override void SynchronizeProperties()
        {
            base.SynchronizeProperties();
            var a = (Annotations.RoundedRectangleAnnotation)this.InternalAnnotation;

            a.MinimumX = this.MinimumX;
            a.MaximumX = this.MaximumX;
            a.MinimumY = this.MinimumY;
            a.MaximumY = this.MaximumY;
            a.CornerRadius = this.CornerRadius;
        }
    }
}
