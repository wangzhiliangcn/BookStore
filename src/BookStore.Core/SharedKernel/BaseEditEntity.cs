using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Core.SharedKernel
{
    public class BaseEditEntity : BaseEntity
    {
        public string Creater { get; set; }

        public DateTime? CreateTime { get; set; }

        public string Updater { get; set; }

        public DateTime? Updatetime { get; set; }

        public bool? IsDelete { get; set; }
    }
}
