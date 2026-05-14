using Hms.Models;
using Hms.Repo.Interfaces;
using Hms.Utility;
using Hms.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hms.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ApplicationUserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public PagedResult<ApplicationUserViewModel> GetAll(
            int PageNumber,
            int PageSize)
        {
            var vm = new ApplicationUserViewModel();
            int totalCount = 0;

            List<ApplicationUserViewModel> vmList =
                new List<ApplicationUserViewModel>();

            try
            {
                int ExcludeRecords =
                    (PageSize * PageNumber) - PageSize;

                var modelList = _unitOfWork
                    .GenericRepository<ApplicationUser>()
                    .GetAll(x=>x.IsDoctor==true)
                    .Skip(ExcludeRecords)
                    .Take(PageSize)
                    .ToList();

                totalCount = _unitOfWork
                    .GenericRepository<ApplicationUser>()
                    .GetAll(x => x.IsDoctor == true)
                    .Count();

                vmList =
                    ConvertModelToViewModelList(modelList);
            }
            catch (Exception)
            {
                throw;
            }

            var result =
                new PagedResult<ApplicationUserViewModel>
                {
                    Data = vmList,
                    TotalItems = totalCount,
                    PageNumber = PageNumber,
                    PageSize = PageSize
                };

            return result;
        }

        public PagedResult<ApplicationUserViewModel>
            GetAllDoctor(int PageNumber, int PageSize)
        {
            {
                var vm = new ApplicationUserViewModel();
                int totalCount = 0;

                List<ApplicationUserViewModel> vmList =
                    new List<ApplicationUserViewModel>();

                try
                {
                    int ExcludeRecords =
                        (PageSize * PageNumber) - PageSize;

                    var modelList = _unitOfWork
                        .GenericRepository<ApplicationUser>()
                        .GetAll()
                        .Skip(ExcludeRecords)
                        .Take(PageSize)
                        .ToList();

                    totalCount = _unitOfWork
                        .GenericRepository<ApplicationUser>()
                        .GetAll()
                        .Count();

                    vmList =
                        ConvertModelToViewModelList(modelList);
                }
                catch (Exception)
                {
                    throw;
                }

                var result =
                    new PagedResult<ApplicationUserViewModel>
                    {
                        Data = vmList,
                        TotalItems = totalCount,
                        PageNumber = PageNumber,
                        PageSize = PageSize
                    };

                return result;
            }
        }

        public PagedResult<ApplicationUserViewModel>
            GetAllPatient(int PageNumber, int PageSize)
        {
            throw new NotImplementedException();
        }

        public void InsertUsers(ApplicationUserViewModel vm)
        {
            ApplicationUser model = new ApplicationUser()
            {
                Name = vm.Name,
                Email = vm.Email,
                UserName = vm.UserName,
                City = vm.City,
                Gender = vm.Gender,
                IsDoctor = vm.IsDoctor,
                Specialist = vm.Specialist
            };

            _unitOfWork
                .GenericRepository<ApplicationUser>()
                .Add(model);

            _unitOfWork.Save();
        }

        public PagedResult<ApplicationUserViewModel>
            SearchDoctor(
                int PageNumber,
                int PageSize,
                string Speciality)
        {
            throw new NotImplementedException();
        }

        private List<ApplicationUserViewModel>
            ConvertModelToViewModelList(
                List<ApplicationUser> modelList)
        {
            return modelList
                .Select(x => new ApplicationUserViewModel(x))
                .ToList();
        }
    }
}