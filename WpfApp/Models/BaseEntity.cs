using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Models
{
    public class BaseEntity
    {

        [Column(Order = 0)]
        public int ID { get; set; }

        [Column(Order = 1)]
        // virtual yaptık çünkü bu alanın sınıflara göre farklı davranmasını istedik. Aksini belirtmedikçe tablolara name alanı oluşturulsun ama belirttiğimizde oluşturulmasın. Örneğin Ordes sınıfında tepesine [NotMapped] yazdık. Propertyi virtual tanımladığımız için override ile yakaldık.
        public virtual string Name { get; set; }
    }
}
