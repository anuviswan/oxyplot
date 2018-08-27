// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RoundedRectangleAnnotation.cs" company="OxyPlot">
//   Copyright (c) 2014 OxyPlot contributors
// </copyright>
// <summary>
//   Represents an annotation that shows a rounded rectangle.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace OxyPlot.Annotations
{
    /// <summary>
    /// Represents an annotation that shows a rounded rectangle.
    /// </summary>
    public class RoundedRectangleAnnotation : ShapeAnnotation
    {
        /// <summary>
        /// The rectangle transformed to screen coordinates.
        /// </summary>
        private OxyRect screenRectangle;

        /// <summary>
        /// Initializes a new instance of the <see cref="RectangleAnnotation" /> class.
        /// </summary>
        public RoundedRectangleAnnotation()
        {
            this.MinimumX = double.MinValue;
            this.MaximumX = double.MaxValue;
            this.MinimumY = double.MinValue;
            this.MaximumY = double.MaxValue;
            this.TextRotation = 0;
            this.ClipByXAxis = true;
            this.ClipByYAxis = true;
        }

        /// <summary>
        /// Gets or sets the minimum X.
        /// </summary>
        /// <value>The minimum X.</value>
        public double MinimumX { get; set; }

        /// <summary>
        /// Gets or sets the maximum X.
        /// </summary>
        /// <value>The maximum X.</value>
        public double MaximumX { get; set; }

        /// <summary>
        /// Gets or sets the minimum Y.
        /// </summary>
        /// <value>The minimum Y.</value>
        public double MinimumY { get; set; }

        /// <summary>
        /// Gets or sets the maximum Y.
        /// </summary>
        /// <value>The maximum Y.</value>
        public double MaximumY { get; set; }


        /// <summary>
        /// Gets or sets the corner radius
        /// </summary>
        /// <value>The value of Corner Radius</value>
        public double CornerRadius { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to clip the annotation by the X axis range.
        /// </summary>
        /// <value><c>true</c> if clipping by the X axis is enabled; otherwise, <c>false</c>.</value>
        public bool ClipByXAxis { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to clip the annotation by the Y axis range.
        /// </summary>
        /// <value><c>true</c> if clipping by the Y axis is enabled; otherwise, <c>false</c>.</value>
        public bool ClipByYAxis { get; set; }

        /// <summary>
        /// Renders the rectangle annotation.
        /// </summary>
        /// <param name="rc">The render context.</param>
        public override void Render(IRenderContext rc)
        {
            base.Render(rc);

            
        }

        /// <summary>
        /// When overridden in a derived class, tests if the plot element is hit by the specified point.
        /// </summary>
        /// <param name="args">The hit test arguments.</param>
        /// <returns>
        /// The result of the hit test.
        /// </returns>
        protected override HitTestResult HitTestOverride(HitTestArguments args)
        {
            if (this.screenRectangle.Contains(args.Point))
            {
                return new HitTestResult(this, args.Point);
            }

            return null;
        }
    }
}
