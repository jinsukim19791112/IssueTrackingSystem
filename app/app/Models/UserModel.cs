using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Dept { get; set; }
        public string Role { get; set; }
        public string Mobile { get; set; }
        public string ImageUrl { get; set; }
        public string Org { get; set; }
    }
}