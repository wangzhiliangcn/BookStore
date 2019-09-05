using System;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Threading;
namespace BookStore.WpfApp.Controls
{
    /// <summary>
    /// Loading.xaml 的交互逻辑
    /// </summary>
    public partial class Loading : UserControl
    {
        #region Data
        //private readonly DispatcherTimer timer;
        private readonly Timer timer;
        #endregion
        public Loading()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 100;
            //timer = new DispatcherTimer(DispatcherPriority.Send, Dispatcher);
            //timer.Interval = new TimeSpan(0, 0, 0, 0, 90);
        }
        #region Event
        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue)
                Start();
            else
                Stop();
        }
        private void Canvas_Loaded(object sender, RoutedEventArgs e)
        {
            const double offset = Math.PI;
            const double step = Math.PI * 2 / 10.0;
            SetPosition(C0, offset, 0.0, step);
            SetPosition(C1, offset, 1.0, step);
            SetPosition(C2, offset, 2.0, step);
            SetPosition(C3, offset, 3.0, step);
            SetPosition(C4, offset, 4.0, step);
            SetPosition(C5, offset, 5.0, step);
            SetPosition(C6, offset, 6.0, step);
            SetPosition(C7, offset, 7.0, step);
            SetPosition(C8, offset, 8.0, step);
        }
        private void Canvas_Unloaded(object sender, RoutedEventArgs e)
        {
            Stop();
        }
        #endregion        
        #region Function
        private void Start()
        {
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }
        private void Stop()
        {
            timer.Stop();
            timer.Elapsed -= Timer_Elapsed;
        }
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            SpinnerRotate.Dispatcher.BeginInvoke(new Action(() =>
            {
                SpinnerRotate.Angle = (SpinnerRotate.Angle + 36) % 360;
                UIDispatcher.DoEvents();
            }),
            DispatcherPriority.Send);
        }
        private void SetPosition(Ellipse ellipse, double offset, double posOffSet, double step)
        {
            ellipse.SetValue(Canvas.LeftProperty, 50.0 + Math.Sin(offset + posOffSet * step) * 50.0);
            ellipse.SetValue(Canvas.TopProperty, 50 + Math.Cos(offset + posOffSet * step) * 50.0);
        }
        #endregion
    }

    public class UIDispatcher
    {
        public static void DoEvents()
        {
            var frame = new DispatcherFrame();

            Dispatcher.CurrentDispatcher.BeginInvoke(
                DispatcherPriority.Background,
                new DispatcherOperationCallback(delegate (object obj)
                {
                    ((DispatcherFrame)obj).Continue = false;

                    return null;
                }),
                frame);
            Dispatcher.PushFrame(frame);
        }
    }
}
