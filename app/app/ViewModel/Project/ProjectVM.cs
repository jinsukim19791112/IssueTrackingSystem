﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.ViewModel.Home
{
    public class ProjectVM
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string StatusDropDownList { get; set; }
        public string Description { get; set; }
        public string SourceRespository { get; set; }
        public string ReleasedVersion { get; set; }

        public ProjectVM()
        {
            Id = "0";
        }
    }
}