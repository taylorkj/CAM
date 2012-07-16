using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CAM.Models
{
    public class IpAddressModel
    {
        public virtual string Id { get; set; }

        public virtual string Host { get; set; }

        public virtual string RangeId { get; set; }

        public virtual int SortOrder { get; set; }

        public string ExceptionMessage { get; set; }
    }
}