using app.DL;
using app.DL.Project;
using app.Models;
using app.ViewModel.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            _statusDictionary = _commonDataAccess.GetConstant("Status");
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
                viewModel.StatusDropDownList = GetStatus(model.Status);
                result.Add(viewModel);
            }
            return result;
        }

        private string GetStatus(int key)
        {
            string status = string.Empty;
            if (_statusDictionary.ContainsKey(key))
            {
                status = _statusDictionary[key];
            }

            return status;
        }

        public ProjectVM GetProjectWithId(int id)
        {
            ProjectVM result = new ProjectVM();
            ProjectModel model = _projectDataAccess.GetProjectWithId(id);
            result.Id = model.Id.ToString();
            result.Name = model.Subject;
            result.StartDate = model.StartTime.ToShortDateString();
            result.EndDate = model.EndTime.ToShortDateString();
            result.Description = model.Description;
            result.SourceRespository = model.SourceRespository;
            result.ReleasedVersion = model.ReleasedVersion;
            result.Description = model.Description;
            return result;
        }

        public List<SelectListItem> GetAllStatus()
        {
            List<SelectListItem> result = new List<SelectListItem>();
            foreach (var pair in _statusDictionary)
            {
                result.Add(new SelectListItem { Text = pair.Value, Value = pair.Key.ToString() });
            }
            return result;
        }

        public int UpsertProject(ProjectVM viewModel)
        {
            ProjectModel model = new ProjectModel();
            model.Id = int.Parse(viewModel.Id);
            model.Subject = viewModel.Name;
            model.ReleasedVersion = viewModel.ReleasedVersion;
            model.SourceRespository = viewModel.SourceRespository;
            model.Description = viewModel.Description;
            model.StartTime = DateTime.Parse(viewModel.StartDate);
            model.EndTime = DateTime.Parse(viewModel.EndDate);
            model.Status = int.Parse(viewModel.StatusDropDownList);
            model.UpdatedTimeStamp = DateTime.Now;            
            return _projectDataAccess.UpsertProject(model);
        }

        public int DeleteProject(int id)
        {
            return _projectDataAccess.DeleteProject(id);
        }
    }
}