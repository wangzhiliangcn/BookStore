using BookStore.Data;
using BookStore.Domain;
using BookStore.WpfApp.AppCode;
using BookStore.WpfApp.Controls;
using BookStore.WpfApp.Converters;
using Fluent;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace BookStore.WpfApp
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        IMSContext _context = new IMSContext();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (UserSession.CurrentUser != null)
            {
                this.CurrUsertxt.Text = UserSession.CurrentUser.ToString();
            }

            //获取用户有权访问的菜单编码
            List<string> childMenuCodes = new List<string>();

            var menus = _context.SysMenu.Where(m => m.ParentMenuCode != "").Select(b => b.MenuCode);
            foreach (var code in menus)
                if (!childMenuCodes.Contains(code))
                    childMenuCodes.Add(code);

            //根据菜单编码加载子菜单信息
            List<SysMenu> childMenus = new List<SysMenu>();
            foreach (var childmenucode in childMenuCodes)
            {
                childMenus.Add(_context.SysMenu.Where(m => m.IsDelete != true && m.MenuCode == childmenucode).FirstOrDefault());
            }
            childMenus = childMenus.OrderBy(m => m.MenuCode).ToList();

            //根据子菜单来查找父菜单
            List<SysMenu> parentMenus = new List<SysMenu>();
            foreach (var childmenu in childMenus)
            {
                if (parentMenus.Count(m => m.MenuCode == childmenu.ParentMenuCode) == 0)
                    parentMenus.Add(_context.SysMenu.Where(m => m.IsDelete != true && m.MenuCode == childmenu.ParentMenuCode).FirstOrDefault());
            }
            parentMenus = parentMenus.OrderBy(m => m.MenuCode).ToList();

            //生成用户菜单
            GenerateMenu(parentMenus, childMenus);
        }

        /// <summary>
        /// 生成用户菜单
        /// </summary>
        private void GenerateMenu(List<SysMenu> parentMenus, List<SysMenu> childMenus)
        {
            StackPanel parentMenuContainer = new StackPanel();
            parentMenuContainer.Background = (Brush)(new BrushConverter()).ConvertFrom("#eaedf4");
            parentMenuContainer.SetBinding(IsEnabledProperty, new Binding(".") { Source = this.DataContext });

            foreach (var parent in parentMenus)
            {
                Expander expander = new Expander();

                //父菜单
                expander.Header = GetHeader(parent.IconPath, parent.MenuName);

                //子菜单
                StackPanel childMenuContainer = new StackPanel();
                childMenuContainer.Background = (Brush)(new BrushConverter()).ConvertFrom("WhiteSmoke");
                childMenuContainer.SetBinding(VisibilityProperty, new Binding("IconVisible") { Source = this.DataContext });
                foreach (var child in childMenus)
                {
                    if (child.ParentMenuCode == parent.MenuCode)
                    {
                        ImageRadioButton irb = new ImageRadioButton();
                        irb.Content = child.MenuName;
                        irb.GroupName = "Menu";
                        irb.SetBinding(ImageRadioButton.IsCheckedProperty,
                            new Binding("SelectedMenuId")
                            {
                                Source = this.DataContext,
                                Converter = new MenuConverter(),
                                ConverterParameter = child.Id
                            });

                        childMenuContainer.Children.Add(irb);
                    }
                }

                expander.Content = childMenuContainer;
                parentMenuContainer.Children.Add(expander);
            }

            //加载生成的菜单
            svMenu.Content = parentMenuContainer;
        }

        private ItemsControl GetHeader(string ficon, string menuName)
        {
            ItemsControl itemsControl = new ItemsControl();

            WrapPanel wrapPanel = new WrapPanel();

            TextBlock tbIcon = new TextBlock();
            tbIcon.FontSize = 18;
            tbIcon.Style = this.TryFindResource("FIcon") as Style;
            if (!string.IsNullOrWhiteSpace(ficon))
                tbIcon.Text = this.TryFindResource(ficon) as string;
            wrapPanel.Children.Add(tbIcon);

            TextBlock tbOther = new TextBlock();
            tbOther.Text = menuName;
            tbOther.Margin = new Thickness(8, 0, 8, 0);
            tbOther.FontSize = 15;
            tbOther.SetBinding(VisibilityProperty, new Binding("IconVisible") { Source = this.DataContext, Mode = BindingMode.TwoWay });
            wrapPanel.Children.Add(tbOther);

            itemsControl.Items.Add(wrapPanel);

            return itemsControl;
        }

        /// <summary>
        /// 关闭主界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult dr = Xceed.Wpf.Toolkit.MessageBox.Show("确定要退出系统吗？", "提示", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (dr == MessageBoxResult.OK)
            {
                System.Windows.Application.Current.Shutdown();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void WpUserInfo_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            gridUser.Visibility = Visibility.Visible;
        }

        private void WpUserInfo_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            gridUser.Visibility = Visibility.Collapsed;
        }

        private void BtnUserInfo_Click(object sender, RoutedEventArgs e)
        {
            string loginUser = "";

            if (UserSession.CurrentUser != null)
                loginUser = string.Format("用户名：{0}\r\n用户代码：{1}\r\n登录时间：{2}\r\n",
                    UserSession.CurrentUser,
                    UserSession.CurrentUser,
                    UserSession.LoginTime.ToString("yyyy-MM-dd HH:mm:ss"));

            Xceed.Wpf.Toolkit.MessageBox.Show(loginUser, "登录信息", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
