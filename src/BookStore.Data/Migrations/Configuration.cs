using BookStore.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace BookStore.Data.Migrations
{
    //internal sealed class Configuration : DbMigrationsConfiguration<TransportContext>

    internal sealed class Configuration : CreateDatabaseIfNotExists<IMSContext> //DropCreateDatabaseIfModelChanges、DropCreateDatabaseAlways
    {
        public Configuration()
        {
            //AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(IMSContext context)
        {
            #region 系统基础数据

            new List<SysMenu>
            {
                new SysMenu{ MenuCode = "M10",   MenuName="基础数据",      ParentMenuCode = "",    IconPath="M10"},
                new SysMenu{ MenuCode = "M1001", MenuName="运输计划",      ParentMenuCode = "M10", PagePath=@"View\BasicInformation\Plans\Index"},
                new SysMenu{ MenuCode = "M1002", MenuName="装车单",        ParentMenuCode = "M10", PagePath=@"View\BasicInformation\LoadVan\Index"},
                new SysMenu{ MenuCode = "M1003", MenuName="卸货单",        ParentMenuCode = "M10", PagePath=@"View\BasicInformation\UnLoadVan\Index"},
                new SysMenu{ MenuCode = "M1004", MenuName="物资管理",      ParentMenuCode = "M10", PagePath=@"View\BasicInformation\Equipment\Index"},

                new SysMenu{ MenuCode = "M20",   MenuName="运输准备",       ParentMenuCode = "",    IconPath="M20"},
                new SysMenu{ MenuCode = "M2001", MenuName="车辆信息",       ParentMenuCode = "M20", PagePath=@"View\TransportPrepare\Van\Index"},
                new SysMenu{ MenuCode = "M2002", MenuName="运输人员",       ParentMenuCode = "M20", PagePath=@"View\TransportPrepare\Driver\Index"},
                new SysMenu{ MenuCode = "M2003", MenuName="运输路线规划",   ParentMenuCode = "M20", PagePath=@"View\TransportPrepare\Routes\Index"},
                new SysMenu{ MenuCode = "M2004", MenuName="运输任务管理",   ParentMenuCode = "M20", PagePath=@"View\TransportPrepare\TransferTask\Index"},
                
                new SysMenu{ MenuCode = "M30",   MenuName="运输监控",        ParentMenuCode = "",   IconPath="M30"},
                new SysMenu{ MenuCode = "M3001", MenuName="车辆位置监控",    ParentMenuCode = "M30", PagePath=@"View\MonitorCenter\RealtimeMonitor"},
                new SysMenu{ MenuCode = "M3002", MenuName="车辆轨迹回放",    ParentMenuCode = "M30", PagePath=@"View\MonitorCenter\HistoryReplay"},
                new SysMenu{ MenuCode = "M3003", MenuName="物资状态监控",    ParentMenuCode = "M30", PagePath=@"View\MonitorCenter\EquipmentRecycle"},

                new SysMenu{ MenuCode = "M40",   MenuName="报警记录",        ParentMenuCode = "",    IconPath="M40"},
                new SysMenu{ MenuCode = "M4001", MenuName="物资丢失报警",    ParentMenuCode = "M40", PagePath=@"View\EmergencyProcess\LossAlarmIndex"},
                
                new SysMenu{ MenuCode = "M60",   MenuName="统计分析",        ParentMenuCode = "",    IconPath="M60"},                
                new SysMenu{ MenuCode = "M6001", MenuName="运输单统计",      ParentMenuCode = "M60", PagePath=@"View\StaticsReport\AllocateRecordsStatics"},

                new SysMenu{ MenuCode = "M90",   MenuName="系统管理",        ParentMenuCode = "",    IconPath="M90"},
                new SysMenu{ MenuCode = "M9001", MenuName="角色管理",        ParentMenuCode = "M90", PagePath=@"View\SystemManage\SysRole\Index"},
                new SysMenu{ MenuCode = "M9002", MenuName="用户管理",        ParentMenuCode = "M90", PagePath=@"View\SystemManage\SysUser\Index"},
                new SysMenu{ MenuCode = "M9003", MenuName="读写器管理",      ParentMenuCode = "M90", PagePath=@"View\SystemManage\Reader\Index"},
                new SysMenu{ MenuCode = "M9004", MenuName="系统日志",        ParentMenuCode = "M90", PagePath=@"View\SystemManage\SysLog\Index"},
                new SysMenu{ MenuCode = "M9005", MenuName="菜单维护",        ParentMenuCode = "M90", PagePath=@"View\SystemManage\SysMenu\Index"},
            }.ForEach(a => context.SysMenu.Add(a));

            #endregion

            context.SaveChanges();
        }
    }
}
