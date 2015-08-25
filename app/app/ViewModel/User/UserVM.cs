using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.ViewModel.Common
{
    public class UserVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Dept { get; set; }
        public string Role { get; set; }
        public string Mobile { get; set; }
        public string ImageUrl { get; set; }
        public string Org { get; set; }
    }
}