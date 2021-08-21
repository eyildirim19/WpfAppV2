using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Models
{
    public class Orders : BaseEntity
    {
        public Nullable<DateTime> OrderDate { get; set; }

        public decimal Price { get; set; }
        public short DummyColumn { get; set; } // smallint
        public byte DummyColum1 { get; set; } // tinyint

        [NotMapped]
        public override string Name { get; set; }
    }
}
