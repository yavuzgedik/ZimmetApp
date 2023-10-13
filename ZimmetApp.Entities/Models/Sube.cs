using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZimmetApp.Entities.Models
{
    public class Sube : BaseEntity
    {
        public string SubeAdi { get; set; }

        public virtual List<Departman> Departmens { get; set; }
    }
}
