using app.DL;
using app.DL.Home;
using app.ViewModel.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.BL
{
    public class HomeHandler
    {
        private HomeDataAccess _contactDataAccess;

        public HomeHandler(HomeDataAccess contactDataAddress)
        {
            _contactDataAccess = contactDataAddress;
        }

        public List<ProjectVM> GetProject(int pageNumber, int pageRows)
        {
            List<ProjectVM> result = new List<ProjectVM>();
            for (int i = 1; i <= pageRows; i++)
            {
                ProjectVM item = new ProjectVM();
                item.Id = i.ToString();
                item.Name = "Name " + item.Id;
                item.StartDate = "StartDate" + item.Id;
                item.EndDate = "EndDate" + item.Id;
                item.Status = "Status" + item.Id;
                result.Add(item);
            }            
            return result;
        }

        public List<IncidentVM> GetIncident(int pageNumber, int pageRows)
        {
            List<IncidentVM> result = new List<IncidentVM>();
            for (int i = 1; i <= pageRows; i++)
            {
                IncidentVM item = new IncidentVM();
                item.Id = i.ToString();
                item.Subject = "Subject " + item.Id;
                item.Description = "Description" + item.Id;
                item.Status = "Status" + item.Id;
                item.StartDate = "StartDate" + item.Id;
                item.EndDate = "EndDate" + item.Id;
                result.Add(item);
            }
            return result;
        }
    }
}