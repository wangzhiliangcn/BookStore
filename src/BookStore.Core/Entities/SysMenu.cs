using BookStore.Core.SharedKernel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Core.Entities
{
    [Table("SysMenu")]
    public partial class SysMenu : BaseEntity
    {
        [StringLength(100)]
        public string MenuCode { get; set; }

        [StringLength(100)]
        public string ParentMenuCode { get; set; }

        [Required]
        [StringLength(100)]
        public string MenuName { get; set; }

        [StringLength(500)]
        public string PagePath { get; set; }

        [StringLength(300)]
        public string IconPath { get; set; }

        public bool? IsDelete { get; set; }
    }
}
