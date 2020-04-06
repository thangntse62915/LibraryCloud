using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryCloud.Models
{
    public class ActionViewModel
    {
        private int StudentId { get; set; }
        private int StaffId { get; set; }
        private IEnumerable<int> BookIds { get; set; }
    }
}