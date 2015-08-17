using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.Models
{
    public class ProjectModel
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public string SourceRespository { get; set; }
        public string ReleasedVersion { get; set; }
        public DateTime UpdatedTimeStamp { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}