using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CAM.Models
{
    /// <summary>
    /// This view model is used with the IpAddress' Index page's AJAX Get method in order to map the return values to
    /// a JSON object that can be accessed in the result data.
    /// It was used previously by the IpAddressApiController to handle mapping the JSON data to and from request/result data.
    /// </summary>
    public class IpAddressModel
    {
        public virtual string Id { get; set; }

        public virtual string Host { get; set; }

        public virtual string RangeId { get; set; }

        public virtual int SortOrder { get; set; }

        public string ExceptionMessage { get; set; }
    }
}