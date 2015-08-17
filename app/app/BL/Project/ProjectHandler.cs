using app.DL;
using app.DL.Project;
using app.Models;
using app.ViewModel.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.BL.Project
{
    public class ProjectHandler
    {
        private ProjectDataAccess _projectDataAccess;
        private CommonDataAccess _commonDataAccess;
        private Dictionary<int, string> _statusDictionary;

        public ProjectHandler(ProjectDataAccess projectDataAccess, CommonDataAccess commonDataAccess)
        {
            _projectDataAccess = projectDataAccess;
            _commonDataAccess = commonDataAccess;
            _statusDictionary = commonDataAccess.GetConstant("Status");
        }

        public List<ProjectVM> GetProjectTable()
        {
            List<ProjectVM> result = new List<ProjectVM>();
            List<ProjectModel> projectModel = _projectDataAccess.GetProject();
            foreach(ProjectModel model in projectModel)
            {
                ProjectVM viewModel = new ProjectVM();
                viewModel.Id = model.Id.ToString();
                viewModel.Name = model.Subject;
                viewModel.StartDate = model.StartTime.ToShortDateString();
                viewModel.EndDate = model.EndTime.ToShortDateString();
                viewModel.Status = GetStatus(model.Status);
                result.Add(viewModel);
            }

            return result;
        }

        private string GetStatus(int key)
        {
            string status = string.Empty;
            if(_statusDictionary.ContainsKey(key))
            {
                status = _statusDictionary[key];
            }

            return status;
        }
    }
}