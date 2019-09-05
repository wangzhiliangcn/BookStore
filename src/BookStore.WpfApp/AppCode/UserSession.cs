using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.WpfApp.AppCode
{
    public class UserSession
    {
        /// <summary>
        /// 登录用户
        /// </summary>
        public static object CurrentUser { get; set; }

        /// <summary>
        /// 角色列表
        /// </summary>
        public static IEnumerable<object> RoleList { get; set; }

        /// <summary>
        /// 是否超级管理员
        /// </summary>
        public static bool IsSuper { get; set; }

        /// <summary>
        /// 登录时间
        /// </summary>
        public static DateTime LoginTime { get; set; }

        static UserSession()
        {
            IsSuper = false;
        }
    }
}
