using Hms.Utility;
using Hms.ViewModel;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Services
{
public interface IApplicationUserService

    {
        PagedResult<ApplicationUserViewModel> GetAll(int PageNumber, int PageSize);
        PagedResult<ApplicationUserViewModel> GetAllDoctor(int PageNumber, int PageSize);
        PagedResult<ApplicationUserViewModel> GetAllPatient(int PageNumber, int PageSize);
        void InsertUsers(ApplicationUserViewModel vm);
        PagedResult<ApplicationUserViewModel> SearchDoctor(int PageNumber, int PageSize, string Speciality);
    }
}
