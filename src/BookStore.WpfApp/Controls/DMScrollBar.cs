using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace BookStore.WpfApp.Controls
{
    public class DMScrollBar: ScrollBar
    {
        #region 滑块默认颜色
        public SolidColorBrush themeBorderBrush
        {
            get { return (SolidColorBrush)GetValue(themeBorderBrushProperty); }
            set { SetValue(themeBorderBrushProperty, value); }
        }
        /// <summary>
        /// 滑块默认颜色
        /// </summary>
        public static readonly DependencyProperty themeBorderBrushProperty =
            DependencyProperty.Register("themeBorderBrush", typeof(SolidColorBrush), typeof(DMScrollBar), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(255, 200, 200, 200))));
        #endregion

        #region 滑块悬浮颜色
        public SolidColorBrush themeBorderBrushMouseOver
        {
            get { return (SolidColorBrush)GetValue(themeBorderBrushMouseOverProperty); }
            set { SetValue(themeBorderBrushMouseOverProperty, value); }
        }
        /// <summary>
        /// 滑块悬浮颜色
        /// </summary>
        public static readonly DependencyProperty themeBorderBrushMouseOverProperty =
            DependencyProperty.Register("themeBorderBrushMouseOver", typeof(SolidColorBrush), typeof(DMScrollBar), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(255, 180, 180, 180))));
        #endregion

        #region 滑块悬浮按下颜色
        public SolidColorBrush themeBorderBrushPressed
        {
            get { return (SolidColorBrush)GetValue(themeBorderBrushPressedProperty); }
            set { SetValue(themeBorderBrushPressedProperty, value); }
        }
        /// <summary>
        /// 滑块悬浮按下颜色
        /// </summary>
        public static readonly DependencyProperty themeBorderBrushPressedProperty =
            DependencyProperty.Register("themeBorderBrushPressed", typeof(SolidColorBrush), typeof(DMScrollBar), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(255, 190, 190, 190))));
        #endregion

        #region 圆角值X
        /// <summary>
        /// 圆角值X
        /// </summary>
        public double RadiusX
        {
            get { return (double)GetValue(RadiusXProperty); }
            set { SetValue(RadiusXProperty, value); }
        }
        public static readonly DependencyProperty RadiusXProperty =
            DependencyProperty.Register("RadiusX", typeof(double), typeof(DMScrollBar), new PropertyMetadata(2.0));
        #endregion

        #region 圆角值Y
        /// <summary>
        /// 圆角值Y
        /// </summary>
        public double RadiusY
        {
            get { return (double)GetValue(RadiusYProperty); }
            set { SetValue(RadiusYProperty, value); }
        }
        public static readonly DependencyProperty RadiusYProperty =
            DependencyProperty.Register("RadiusY", typeof(double), typeof(DMScrollBar), new PropertyMetadata(2.0));
        #endregion

        #region 滚动条大小
        /// <summary>
        /// 滚动条大小
        /// </summary>
        public double ScrollBarSize
        {
            get { return (double)GetValue(ScrollBarSizeProperty); }
            set { SetValue(ScrollBarSizeProperty, value); }
        }
        public static readonly DependencyProperty ScrollBarSizeProperty =
            DependencyProperty.Register("ScrollBarSize", typeof(double), typeof(DMScrollBar), new PropertyMetadata(6.0));
        #endregion
    }
}
