using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZimmetApp.Entities.Models
{
    public class User : BaseEntity
    {
        public string UserCode { get; set; }
        public string UserPassword { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }

        public bool IsAdmin { get; set; }

        public Guid? SubeId { get; set; }
        public Guid? DepartmanId { get; set; }

        public virtual Sube Sube { get; set; }
        public virtual Departman Departman { get; set; }


        public virtual List<ZimmetLog> ZimmetLogs { get; set; }

        [NotMapped]
        public string FullName 
        { 
            get
            {
                return FirstName + " " + LastName;
            }
        }
        //public string FullName2 => FirstName + " " + LastName;

        public override string ToString()
        {
            return FullName + " (" + UserCode + ")";
        }
    }
}
