using System;

namespace BookStore.Domain.SharedKernel
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
