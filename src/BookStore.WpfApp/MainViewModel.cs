using BookStore.Data;
using BookStore.Domain;
using BookStore.WpfApp.AppCode;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BookStore.WpfApp
{
    public class MainViewModel : ViewModelBase
    {
        IMSContext _context = new IMSContext();

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
        }

        #region Dependency Propreties

        public string windowTitle = AppSettings<string>.GetConfig("AssemblyTitle");
        /// <summary>
        /// 标题
        /// </summary>
        public string WindowTitle
        {
            get { return windowTitle; }
        }

        public GridLength menuGridLenght = new GridLength(180);
        /// <summary>
        /// 折叠菜单的Grid的宽度
        /// </summary>
        public GridLength MenuGridLenght
        {
            get { return menuGridLenght; }
            set
            {
                menuGridLenght = value;
                RaisePropertyChanged("MenuGridLenght");
            }
        }

        public Thickness gsMargin = new Thickness(149, 7, 0, 0);
        /// <summary>
        /// 折叠菜单按钮的边距
        /// </summary>
        public Thickness GsMargin
        {
            get { return gsMargin; }
            set
            {
                gsMargin = value;
                RaisePropertyChanged("GsMargin");
            }
        }

        private string iconVisible = "Visible";
        /// <summary>
        /// 折叠菜单后只显示Icon
        /// </summary>
        public string IconVisible
        {
            get { return iconVisible; }
            set
            {
                iconVisible = value;
                RaisePropertyChanged("IconVisible");
            }
        }

        private bool isSpEnabled = true;
        /// <summary>
        /// 折叠菜单后只显示Icon
        /// </summary>
        public bool IsSpEnabled
        {
            get { return isSpEnabled; }
            set
            {
                isSpEnabled = value;
                RaisePropertyChanged("IsSpEnabled");
            }
        }

        #endregion

        private Page selectedPage = null;

        /// <summary>
        /// 当前页面
        /// </summary>
        public Page SelectedPage
        {
            get { return selectedPage; }
            set
            {
                selectedPage = value;
                RaisePropertyChanged("SelectedPage");
            }
        }

        private long _selectedMenuId;
        /// <summary>
        /// 选中的菜单
        /// </summary>
        public long SelectedMenuId
        {
            get { return _selectedMenuId; }
            set
            {
                _selectedMenuId = value;

                SelectedPage = GetPageByMenuId(value);
                RaisePropertyChanged("SelectedMenuId");
            }
        }

        /// <summary>
        /// 折叠菜单事件
        /// </summary>
        public ICommand CollapseCommand
        {
            get
            {
                return new RelayCommand(this.ExecuteCollapse);
            }
        }

        private void ExecuteCollapse()
        {
            if (IconVisible == "Visible")
            {
                IconVisible = "Collapsed";
                GsMargin = new Thickness(6, 7, 0, 0);
                IsSpEnabled = false;
                MenuGridLenght = new GridLength(42);
            }
            else
            {
                IconVisible = "Visible";
                GsMargin = new Thickness(149, 7, 0, 0);
                IsSpEnabled = true;
                MenuGridLenght = new GridLength(180);
            }
        }

        private Page GetPageByMenuId(long menuId)
        {
            try
            {
                Page page = null;

                SysMenu menu = _context.SysMenu.Where(m => m.Id == menuId).FirstOrDefault();
                if (menu == null) return page;

                Assembly curAssembly = Assembly.GetExecutingAssembly();

                string assemblyName = curAssembly.FullName.Substring(0, curAssembly.FullName.IndexOf(','));
                string menuPageType = assemblyName + "." + menu.PagePath.Replace("\\", ".");

                object obj = curAssembly.CreateInstance(menuPageType);

                if (obj == null) return page;

                return (Page)obj;
            }
            catch
            {
                return null;
            }
        }
    }
}
