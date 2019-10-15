using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Application1
{
    public class MembershipType1
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public short Duration { get; set; }
        public double SignUpFree { get; set; }
        public short Discount { get; set; }
    }
}