using System;
using System.Configuration;

namespace BookStore.WpfApp.AppCode
{
    /// <summary>
    /// 操作配置文件（修改）
    /// </summary>
    public class AppSettings
    {
        /// <summary>
        /// 设置配置文件AppSettings节点的键名和值并持久化到文件
        /// </summary>
        /// <param name="key">节点名称</param>
        /// <param name="value">节点值</param>
        public static void SetConfig(string key, string value)
        {
            try
            {
                //打开配置文件流
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                AppSettingsSection section = config.AppSettings;

                if (section != null && section.Settings[key] != null)
                {
                    section.Settings[key].Value = value;
                }
                else
                {
                    section.Settings.Add(new KeyValueConfigurationElement(key, value));
                }

                //保存修改后的节点
                config.Save(ConfigurationSaveMode.Modified);

                //刷新节点，以便下次从 ConfigurationManager.AppSettings 中取值时，
                //重新从磁盘读取节点的值
                ConfigurationManager.RefreshSection("appSettings");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void SetConfigConnectionstring(string key, string value)
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                ConnectionStringsSection section = config.ConnectionStrings;

                if (section != null && section.ConnectionStrings[key] != null)
                {
                    section.ConnectionStrings[key].ConnectionString = value;
                }
                else
                {
                    section.ConnectionStrings.Add(new ConnectionStringSettings(key, value, "System.Data.SqlClient"));
                }

                config.Save(ConfigurationSaveMode.Modified);

                ConfigurationManager.RefreshSection("connectionStrings");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    /// <summary>
    /// 操作配置文件（读取）
    /// </summary>
    /// <typeparam name="T">返回什么类型的值</typeparam>
    public class AppSettings<T> : AppSettings
    {
        /// <summary>
        /// 读取节点的值
        /// </summary>
        /// <param name="key">节点名称</param>
        /// <param name="valType">配置类型：0 AppSettings，1 ConnnectionStrings</param>
        /// <returns></returns>
        public static T GetConfig(string key, byte valType = 0)
        {
            try
            {
                Type type = typeof(T);
                object result = null; //返回特定类型的值                
                object val = null; //配置节点的值

                if (valType == 0)
                    val = ConfigurationManager.AppSettings[key];
                else
                    val = ConfigurationManager.ConnectionStrings[key];

                if (type == typeof(int))
                    result = Convert.ToInt32(val);
                else if (type == typeof(string))
                    result = Convert.ToString(val);
                else if (type == typeof(double))
                    result = Convert.ToDouble(val);
                else
                    result = Convert.ChangeType(val, type);

                return (T)result;
            }
            catch
            {
                return default(T);
            }
        }
    }
}
