using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.ViewModel.Home
{
    public class ProjectVM
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
    }
}