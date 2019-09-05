using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace BookStore.WpfApp.Controls
{
    /// <summary>
    /// NumericBox.xaml 的交互逻辑
    /// </summary>
    public partial class NumericUpDown : UserControl
    {
        #region DependencyProperty

        public static readonly DependencyProperty ValueProperty =
        DependencyProperty.Register("Value", typeof(int?), typeof(NumericUpDown), new PropertyMetadata(new PropertyChangedCallback(InitProperty)));

        private static void InitProperty(DependencyObject dobject, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                var control = dobject as NumericUpDown;
                if (control != null)
                {
                    control.Value = Convert.ToInt32(e.NewValue);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
        public NumericUpDown()
        {
            InitializeComponent();
        }

        private int? _Value = 0;
        public int? Value
        {
            get
            {
                var _Value = (int?)GetValue(ValueProperty);
                if (_Value.HasValue)
                {
                    return _Value;
                }
                else
                {
                    _Value = 0;
                    this.ValueText.Text = "0";
                    return 0;
                }

            }

            set
            {
                _Value = value;
                SetValue(ValueProperty, _Value);
                this.ValueText.Text = _Value.ToString();
            }

        }

        private int _Increment = 1;
        public int Increment
        {
            get
            {
                return _Increment;
            }
            set
            {
                _Increment = value;
            }
        }

        private int _MaxValue = 100;
        public int MaxValue
        {
            get
            { return _MaxValue; }
            set
            {
                _MaxValue = value;
            }
        }

        private int _MinValue = 0;
        public int MinValue
        {
            get
            { return _MinValue; }
            set
            {
                _MinValue = value;
            }
        }
        private void DownButton_Click(object sender, RoutedEventArgs e)
        {
            int newValue = (Value.Value - Increment);

            if (newValue < MinValue)
            {
                Value = MinValue;
            }
            else
            {
                Value = newValue;
            }
        }

        private void UpButton_Click(object sender, RoutedEventArgs e)
        {
            int newValue = (Value.Value + Increment);

            if (newValue > MaxValue)
            {
                Value = MaxValue;
            }
            else
            {
                Value = newValue;
            }
        }

        private void ValueText_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(ValueText.Text))
                {
                    Value = int.Parse(ValueText.Text);
                }
            }
            catch
            {
                Value = 0;
            }
        }
    }

    [ValueConversion(typeof(double), typeof(string))]

    public class DoubleValueConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                return value.ToString();
            }
            catch (Exception)
            {
                return "0";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                return double.Parse((string)value);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        #endregion

    }
}
