﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RoundedRectangleAnnotation.cs" company="OxyPlot">
//   Copyright (c) 2014 OxyPlot contributors
// </copyright>
// <summary>
//   Represents an annotation that shows a rounded rectangle.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

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
        private OxyRect screenRectangle1;
        private OxyRect screenRectangle2;

        private OxyRect screenEllipse1;
        private OxyRect screenEllipse2;
        private OxyRect screenEllipse3;
        private OxyRect screenEllipse4;

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
            this.CornerRadius = 0;
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

            if (CornerRadius == 0)
            {
                DrawRegularRectangle(rc);
            }
            else
            {
                DrawRoundedRectangle(rc);
            }
        }

        private void DrawRoundedRectangle(IRenderContext rc)
        {
            double xMin = double.IsNaN(this.MinimumX) || this.MinimumX.Equals(double.MinValue)
                            ? this.ClipByXAxis
                                ? this.XAxis.ActualMinimum
                                : this.XAxis.InverseTransform(this.PlotModel.PlotArea.Left)
                            : this.MinimumX;
            double xMax = double.IsNaN(this.MaximumX) || this.MaximumX.Equals(double.MaxValue)
                            ? this.ClipByXAxis
                                ? this.XAxis.ActualMaximum
                                : this.XAxis.InverseTransform(this.PlotModel.PlotArea.Right)
                            : this.MaximumX;
            double yMin = double.IsNaN(this.MinimumY) || this.MinimumY.Equals(double.MinValue)
                            ? this.ClipByYAxis
                                ? this.YAxis.ActualMinimum
                                : this.YAxis.InverseTransform(this.PlotModel.PlotArea.Bottom)
                            : this.MinimumY;
            double yMax = double.IsNaN(this.MaximumY) || this.MaximumY.Equals(double.MaxValue)
                            ? this.ClipByYAxis
                                ? this.YAxis.ActualMaximum
                                : this.YAxis.InverseTransform(this.PlotModel.PlotArea.Top)
                            : this.MaximumY;

            

            this.screenRectangle1 = new OxyRect(this.Transform(xMin, yMin+CornerRadius), this.Transform(xMax, yMax-CornerRadius));
            this.screenRectangle2 = new OxyRect(this.Transform(xMin + CornerRadius, yMin), this.Transform(xMax - CornerRadius, yMax ));

            this.screenEllipse1 = new OxyRect(this.Transform(xMin, yMin), this.Transform(xMin + 2* CornerRadius, yMin + 2* CornerRadius));
            this.screenEllipse2 = new OxyRect(this.Transform(xMin, yMax), this.Transform(xMin + 2 * CornerRadius, yMax - 2 * CornerRadius));
            this.screenEllipse3 = new OxyRect(this.Transform(xMax, yMin), this.Transform(xMax - 2 * CornerRadius, yMin + 2 * CornerRadius));
            this.screenEllipse4 = new OxyRect(this.Transform(xMax, yMax), this.Transform(xMax - 2 * CornerRadius, yMax - 2 * CornerRadius));

            // clip to the area defined by the axes
            var clippingRectangle = OxyRect.Create(
                this.ClipByXAxis ? this.XAxis.ScreenMin.X : this.PlotModel.PlotArea.Left,
                this.ClipByYAxis ? this.YAxis.ScreenMin.Y : this.PlotModel.PlotArea.Top,
                this.ClipByXAxis ? this.XAxis.ScreenMax.X : this.PlotModel.PlotArea.Right,
                this.ClipByYAxis ? this.YAxis.ScreenMax.Y : this.PlotModel.PlotArea.Bottom);

            rc.DrawClippedRectangle(clippingRectangle,this.screenRectangle1,
                                            this.GetSelectableFillColor(this.Fill),
                                            this.GetSelectableColor(this.Stroke),
                                            this.StrokeThickness);

            rc.DrawClippedRectangle(clippingRectangle, this.screenRectangle2,
                                            this.GetSelectableFillColor(this.Fill),
                                            this.GetSelectableColor(this.Stroke),
                                            this.StrokeThickness);


            rc.DrawClippedEllipse(clippingRectangle, screenEllipse1, 
                                            this.GetSelectableFillColor(this.Fill), 
                                            this.GetSelectableColor(this.Stroke),
                                            this.StrokeThickness);

            rc.DrawClippedEllipse(clippingRectangle, screenEllipse2,
                                this.GetSelectableFillColor(this.Fill),
                                this.GetSelectableColor(this.Stroke),
                                this.StrokeThickness);

            rc.DrawClippedEllipse(clippingRectangle, screenEllipse3,
                                this.GetSelectableFillColor(this.Fill),
                                this.GetSelectableColor(this.Stroke),
                                this.StrokeThickness);

            rc.DrawClippedEllipse(clippingRectangle, screenEllipse4,
                                this.GetSelectableFillColor(this.Fill),
                                this.GetSelectableColor(this.Stroke),
                                this.StrokeThickness);
        }

        private void DrawRegularRectangle(IRenderContext rc)
        {
            double x0 = double.IsNaN(this.MinimumX) || this.MinimumX.Equals(double.MinValue)
                            ? this.ClipByXAxis
                                ? this.XAxis.ActualMinimum
                                : this.XAxis.InverseTransform(this.PlotModel.PlotArea.Left)
                            : this.MinimumX;
            double x1 = double.IsNaN(this.MaximumX) || this.MaximumX.Equals(double.MaxValue)
                            ? this.ClipByXAxis
                                ? this.XAxis.ActualMaximum
                                : this.XAxis.InverseTransform(this.PlotModel.PlotArea.Right)
                            : this.MaximumX;
            double y0 = double.IsNaN(this.MinimumY) || this.MinimumY.Equals(double.MinValue)
                            ? this.ClipByYAxis
                                ? this.YAxis.ActualMinimum
                                : this.YAxis.InverseTransform(this.PlotModel.PlotArea.Bottom)
                            : this.MinimumY;
            double y1 = double.IsNaN(this.MaximumY) || this.MaximumY.Equals(double.MaxValue)
                            ? this.ClipByYAxis
                                ? this.YAxis.ActualMaximum
                                : this.YAxis.InverseTransform(this.PlotModel.PlotArea.Top)
                            : this.MaximumY;

            this.screenRectangle = new OxyRect(this.Transform(x0, y0), this.Transform(x1, y1));

            // clip to the area defined by the axes
            var clippingRectangle = OxyRect.Create(
                this.ClipByXAxis ? this.XAxis.ScreenMin.X : this.PlotModel.PlotArea.Left,
                this.ClipByYAxis ? this.YAxis.ScreenMin.Y : this.PlotModel.PlotArea.Top,
                this.ClipByXAxis ? this.XAxis.ScreenMax.X : this.PlotModel.PlotArea.Right,
                this.ClipByYAxis ? this.YAxis.ScreenMax.Y : this.PlotModel.PlotArea.Bottom);

            rc.DrawClippedRectangle(
                clippingRectangle,
                this.screenRectangle,
                this.GetSelectableFillColor(this.Fill),
                this.GetSelectableColor(this.Stroke),
                this.StrokeThickness);



            if (!string.IsNullOrEmpty(this.Text))
            {
                var textPosition = this.GetActualTextPosition(() => this.screenRectangle.Center);
                rc.DrawClippedText(
                    clippingRectangle,
                    textPosition,
                    this.Text,
                    this.ActualTextColor,
                    this.ActualFont,
                    this.ActualFontSize,
                    this.ActualFontWeight,
                    this.TextRotation,
                    HorizontalAlignment.Center,
                    VerticalAlignment.Middle);
            }
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
