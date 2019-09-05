using BookStore.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace BookStore.Data.Migrations
{
    //internal sealed class Configuration : DbMigrationsConfiguration<TransportContext>

    internal sealed class Configuration : CreateDatabaseIfNotExists<IMSContext> //DropCreateDatabaseIfModelChanges��DropCreateDatabaseAlways
    {
        public Configuration()
        {
            //AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(IMSContext context)
        {
            #region ϵͳ��������

            new List<SysMenu>
            {
                new SysMenu{ MenuCode = "M10",   MenuName="��������",      ParentMenuCode = "",    IconPath="M10"},
                new SysMenu{ MenuCode = "M1001", MenuName="����ƻ�",      ParentMenuCode = "M10", PagePath=@"View\BasicInformation\Plans\Index"},
                new SysMenu{ MenuCode = "M1002", MenuName="װ����",        ParentMenuCode = "M10", PagePath=@"View\BasicInformation\LoadVan\Index"},
                new SysMenu{ MenuCode = "M1003", MenuName="ж����",        ParentMenuCode = "M10", PagePath=@"View\BasicInformation\UnLoadVan\Index"},
                new SysMenu{ MenuCode = "M1004", MenuName="���ʹ���",      ParentMenuCode = "M10", PagePath=@"View\BasicInformation\Equipment\Index"},

                new SysMenu{ MenuCode = "M20",   MenuName="����׼��",       ParentMenuCode = "",    IconPath="M20"},
                new SysMenu{ MenuCode = "M2001", MenuName="������Ϣ",       ParentMenuCode = "M20", PagePath=@"View\TransportPrepare\Van\Index"},
                new SysMenu{ MenuCode = "M2002", MenuName="������Ա",       ParentMenuCode = "M20", PagePath=@"View\TransportPrepare\Driver\Index"},
                new SysMenu{ MenuCode = "M2003", MenuName="����·�߹滮",   ParentMenuCode = "M20", PagePath=@"View\TransportPrepare\Routes\Index"},
                new SysMenu{ MenuCode = "M2004", MenuName="�����������",   ParentMenuCode = "M20", PagePath=@"View\TransportPrepare\TransferTask\Index"},
                
                new SysMenu{ MenuCode = "M30",   MenuName="������",        ParentMenuCode = "",   IconPath="M30"},
                new SysMenu{ MenuCode = "M3001", MenuName="����λ�ü��",    ParentMenuCode = "M30", PagePath=@"View\MonitorCenter\RealtimeMonitor"},
                new SysMenu{ MenuCode = "M3002", MenuName="�����켣�ط�",    ParentMenuCode = "M30", PagePath=@"View\MonitorCenter\HistoryReplay"},
                new SysMenu{ MenuCode = "M3003", MenuName="����״̬���",    ParentMenuCode = "M30", PagePath=@"View\MonitorCenter\EquipmentRecycle"},

                new SysMenu{ MenuCode = "M40",   MenuName="������¼",        ParentMenuCode = "",    IconPath="M40"},
                new SysMenu{ MenuCode = "M4001", MenuName="���ʶ�ʧ����",    ParentMenuCode = "M40", PagePath=@"View\EmergencyProcess\LossAlarmIndex"},
                
                new SysMenu{ MenuCode = "M60",   MenuName="ͳ�Ʒ���",        ParentMenuCode = "",    IconPath="M60"},                
                new SysMenu{ MenuCode = "M6001", MenuName="���䵥ͳ��",      ParentMenuCode = "M60", PagePath=@"View\StaticsReport\AllocateRecordsStatics"},

                new SysMenu{ MenuCode = "M90",   MenuName="ϵͳ����",        ParentMenuCode = "",    IconPath="M90"},
                new SysMenu{ MenuCode = "M9001", MenuName="��ɫ����",        ParentMenuCode = "M90", PagePath=@"View\SystemManage\SysRole\Index"},
                new SysMenu{ MenuCode = "M9002", MenuName="�û�����",        ParentMenuCode = "M90", PagePath=@"View\SystemManage\SysUser\Index"},
                new SysMenu{ MenuCode = "M9003", MenuName="��д������",      ParentMenuCode = "M90", PagePath=@"View\SystemManage\Reader\Index"},
                new SysMenu{ MenuCode = "M9004", MenuName="ϵͳ��־",        ParentMenuCode = "M90", PagePath=@"View\SystemManage\SysLog\Index"},
                new SysMenu{ MenuCode = "M9005", MenuName="�˵�ά��",        ParentMenuCode = "M90", PagePath=@"View\SystemManage\SysMenu\Index"},
            }.ForEach(a => context.SysMenu.Add(a));

            #endregion

            context.SaveChanges();
        }
    }
}
