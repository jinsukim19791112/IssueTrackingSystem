using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.ViewModel.Home
{
    public class IncidentVM
    {
        public string Id { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string ManDay { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}