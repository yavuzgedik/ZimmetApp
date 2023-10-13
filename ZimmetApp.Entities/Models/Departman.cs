using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZimmetApp.Entities.Models
{
    public class Departman : BaseEntity
    {
        public string DepartmanAdi { get; set; }
        public Guid? SubeId { get; set; }

        public virtual Sube Sube { get; set; }
    }
}
