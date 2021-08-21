using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Models
{
    public class Category : BaseEntity
    {
        [Column(Order = 2)]
        public string Description { get; set; }



        [NotMapped] // mapleme (hiç bir alan oluşturma veya eşleştirme)
        public string FullName { get; set; }
    }
}
