using app.DL.User;
using app.Models;
using app.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.BL.User
{
    public class UserHandler
    {
        private UserDataAccess _userDataAccess;

        public List<UserVM> GetUsers()
        {
            List<UserVM> result = new List<UserVM>();
            List<UserModel> userModelList = _userDataAccess.GetUsers();
            foreach (UserModel model in userModelList)
            {
                UserVM viewModel = new UserVM();
                viewModel.Id = model.Id;
                viewModel.Name = model.Name;
                viewModel.Email = model.Email;
                viewModel.Dept = model.Dept;
                viewModel.Mobile = model.Mobile;
                viewModel.ImageUrl = model.ImageUrl;
                viewModel.Org = model.Org;
                result.Add(viewModel);
            }
            return result;
        }
    }
}