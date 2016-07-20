namespace DataAccess.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PhoneEntity : BaseEntity
    {
        public int ContactId { get; set; }
        public string Phone { get; set; }
    }
}
